codeunit 50100 MyCodeunit
{
    procedure MyProcedure()
    var
        MyCode: Code[2];
    begin
        [|MyCode[1] := 10|];
        [|MyCode[2] := 10|];
    end;
}