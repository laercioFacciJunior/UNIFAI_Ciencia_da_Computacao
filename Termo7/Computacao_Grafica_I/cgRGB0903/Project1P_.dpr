program Project1P_;

uses
  Forms,
  cgu_exe01 in 'cgu_exe01.pas' {Form1};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.
