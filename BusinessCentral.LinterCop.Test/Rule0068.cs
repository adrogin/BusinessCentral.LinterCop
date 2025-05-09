namespace BusinessCentral.LinterCop.Test;

public class Rule0068
{
    private string _testCaseDir = "";

    [SetUp]
    public void Setup()
    {
        _testCaseDir = Path.Combine(Directory.GetParent(Environment.CurrentDirectory)!.Parent!.Parent!.FullName,
            "TestCases", "Rule0068");
    }

    [Test]
    [TestCase("ProcedureCalls")]
    [TestCase("XmlPorts")]
    [TestCase("Queries")]
    [TestCase("Reports")]
    public async Task HasDiagnostic(string testCase)
    {
        var code = await File.ReadAllTextAsync(Path.Combine(_testCaseDir, "HasDiagnostic", $"{testCase}.al"))
            .ConfigureAwait(false);

        var fixture = RoslynFixtureFactory.Create<Rule0068CheckObjectPermission>();
        fixture.HasDiagnosticAtAllMarkers(code, DiagnosticDescriptors.Rule0068CheckObjectPermission.Id);
    }

    [Test]
    [TestCase("ProcedureCallsPermissionsProperty")]
    [TestCase("XmlPortPermissionsProperty")]
    [TestCase("QueryPermissionsProperty")]
    [TestCase("XmlPortInherentPermissions")]
    [TestCase("QueryInherentPermissions")]
    [TestCase("ReportPermissionsProperty")]
    [TestCase("ReportInherentPermissions")]
    [TestCase("ProcedureCallsInherentPermissionsProperty")]
    [TestCase("ProcedureCallsInherentPermissionsAttribute")]
    [TestCase("PageSourceTable")]
#if !LessThenSpring2024
    [TestCase("PageExtensionSourceTable")]
#endif
#if !LessThenFall2023RV1
    [TestCase("ProcedureCallsPermissionsPropertyFullyQualified")]
#endif
    // [TestCase("IntegerTable")]
    [TestCase("XMLPortWithTableElementProps")]
    [TestCase("PermissionsAsObjectId")]
    [TestCase("PermissionPropertyWithPragma")]
    [TestCase("PermissionPropertyWithComment")]
    [TestCase("MultiplePermissionsDifferentType")] 
    public async Task NoDiagnostic(string testCase)
    {
        var code = await File.ReadAllTextAsync(Path.Combine(_testCaseDir, "NoDiagnostic", $"{testCase}.al"))
            .ConfigureAwait(false);

        var fixture = RoslynFixtureFactory.Create<Rule0068CheckObjectPermission>();
        fixture.NoDiagnosticAtAllMarkers(code, DiagnosticDescriptors.Rule0068CheckObjectPermission.Id);
    }
}
