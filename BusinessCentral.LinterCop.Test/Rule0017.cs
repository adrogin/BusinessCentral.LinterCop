namespace BusinessCentral.LinterCop.Test;

public class Rule0017
{
    private string _testCaseDir = "";

    [SetUp]
    public void Setup()
    {
        _testCaseDir = Path.Combine(Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName,
            "TestCases", "Rule0017");
    }

    [Test]
    [TestCase("Assignment")]
    [TestCase("Validate")]
    public async Task HasDiagnostic(string testCase)
    {
        var code = await File.ReadAllTextAsync(Path.Combine(_testCaseDir, "HasDiagnostic", $"{testCase}.al"))
            .ConfigureAwait(false);

        var fixture = RoslynFixtureFactory.Create<Rule0017WriteToFlowField>();
        fixture.HasDiagnosticAtAllMarkers(code, DiagnosticDescriptors.Rule0017WriteToFlowField.Id);
    }

    [Test]
    [TestCase("AssignmentWithLeadingComment")]
    [TestCase("AssignmentWithTrailingComment")]
    [TestCase("ValidateWithLeadingComment")]
    //TODO: The HasExplainingComment method in the Rule0017WriteToFlowField class doesn't support this scenario currently
    // [TestCase("ValidateWithTrailingComment")]
    public async Task NoDiagnostic(string testCase)
    {
        var code = await File.ReadAllTextAsync(Path.Combine(_testCaseDir, "NoDiagnostic", $"{testCase}.al"))
            .ConfigureAwait(false);

        var fixture = RoslynFixtureFactory.Create<Rule0017WriteToFlowField>();
        fixture.NoDiagnosticAtAllMarkers(code, DiagnosticDescriptors.Rule0017WriteToFlowField.Id);
    }
}