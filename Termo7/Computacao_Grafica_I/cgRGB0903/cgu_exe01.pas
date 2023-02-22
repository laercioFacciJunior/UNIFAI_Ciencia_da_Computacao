unit cgu_exe01;


interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls, Math;

type
  TForm1 = class(TForm)
    Button1: TButton;
    lblR: TLabel;
    lblG: TLabel;
    lblB: TLabel;
    img1: TImage;
    ImgR: TImage;
    ImgG: TImage;
    ImgB: TImage;
    imgBranco: TImage;
    Button2: TButton;
    Button3: TButton;
    edtX1: TEdit;
    edtY1: TEdit;
    edtX2: TEdit;
    edtY2: TEdit;
    procedure img1MouseMove(Sender: TObject; Shift: TShiftState; X,
      Y: Integer);
    procedure img1Mouseown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure Button1Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

procedure TForm1.img1MouseMove(Sender: TObject; Shift: TShiftState; X,
  Y: Integer);
begin
 lblR.Caption := intToStr(
              getRvalue(img1.canvas.pixels[x,y]));

       lblG.Caption := intToStr(
              getGvalue(img1.canvas.pixels[x,y]));

       lblB.Caption := intToStr(
              getBvalue(img1.canvas.pixels[x,y]));
end;

procedure TForm1.img1Mouseown(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
      img1.Canvas.Pixels[x,y] := RGB(0,0,0);
end;

procedure TForm1.Button1Click(Sender: TObject);
var x, y, cor : integer;
begin
   for x := 0 to img1.Width -1 do
      for Y := 0 to img1.Height -1 do
     begin
           cor := getRValue(img1.Canvas.Pixels[x,y]);
           imgR.Canvas.Pixels[x,y] := RGB(Cor, 0,0);

           cor := getRValue(img1.Canvas.Pixels[x,y]);
           imgG.Canvas.Pixels[x,y] := RGB(0, cor,0);


           cor := getRValue(img1.Canvas.Pixels[x,y]);
           imgB.Canvas.Pixels[x,y] := RGB(0, 0,cor);
     end;


end;

procedure TForm1.Button3Click(Sender: TObject);
var i, x1, x2, y1,y2, length :integer; dx,x, y, dy : double;
begin
      x1 := strToint(edtX1.Text);
      y1 := strToint(edtY1.Text);
      x2 := strToint(edtX2.Text);
      y2 := strToint(edtY2.Text);

      if(abs(x2 - x1)>= abs(y2 -y1) ) then
        length := abs(y2 -y1)

      else
        length := abs(x2 -x1);

        dx := (x2 - x1) / length;
        dy := (y2 - y1) / length;
        x :=  x1 + 0.5;
        y :=  y1 + 0.5;

        for i :=0  to length do

          begin
           imgBranco.Canvas.Pixels[trunc(x),trunc(y)] := RGB(0,0,0);
            x := x + dx;
            y := y + dy;
          end;

end;

end.
