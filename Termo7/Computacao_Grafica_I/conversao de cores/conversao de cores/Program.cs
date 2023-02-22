using System;
using System.Drawing;

namespace conversao_de_cores
{
    class Program
    {
        static void Main(string[] args)
        {
            double R = 0; double G = 0; double B = 0;                //RGB
            double C = 0; double M = 0; double Y = 0; double K = 0;  //CMYK
            double H = 0; double S = 0; double V = 0;                //HSV

            //--Menu------------------------------------------------------------
            int menu = -1;

            while (menu != 0) {
                Console.WriteLine("1 - Conversões RGB para CMYK");
                Console.WriteLine("2 - Conversões CMYK para RGB ");
                Console.WriteLine("3 - Conversões RGB para HSV");
                Console.WriteLine("4 - Conversões HSV para RGB");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("Escolha o que deseja fazer: ");

                while (!(int.TryParse(Console.ReadLine(), out menu)))
                {
                    Console.Write("Opção não numerica, digite novamente: ");
                }
                switch (menu)
                {
                    case 1: RgbToCmyK(); break;
                    case 2: CmyKToRgb(); break;
                    case 3: RgbToHsv(); break;
                    case 4: HsvToRgb(); break;
                    case 0: Console.WriteLine("Finalizando..."); break;
                    default: Console.WriteLine("Nós não temos esta opção, escolhe novamente:"); break;
                }
                
                Console.WriteLine("\n---------------------------------\n");
            }
            //ENTRADA------------------------------------------------------------------
            void DigitarEntrada(int menu)
            {
                if (menu == 1 || menu == 3)
                {
                    Console.WriteLine("\nValor 0 a 255\n");
                    Console.Write("R = "); R = double.Parse(Console.ReadLine());
                    Console.Write("G = "); G = double.Parse(Console.ReadLine());
                    Console.Write("B = "); B = double.Parse(Console.ReadLine());
                }

                if (menu == 2)
                {
                    Console.WriteLine("\nValor 0 a 100%\n");
                    Console.Write("C = "); C = double.Parse(Console.ReadLine()) * 0.01;
                    Console.Write("M = "); M = double.Parse(Console.ReadLine()) * 0.01;
                    Console.Write("Y = "); Y = double.Parse(Console.ReadLine()) * 0.01;
                    Console.Write("K = "); K = double.Parse(Console.ReadLine()) * 0.01;
                }

                if (menu == 4)
                {
                    Console.WriteLine("\nValor H 0 a 360°, S e V 0 a 100%\n");
                    Console.Write("H = "); H = double.Parse(Console.ReadLine()) ;
                    Console.Write("S = "); S = double.Parse(Console.ReadLine()) * 0.01;
                    Console.Write("V = "); V = double.Parse(Console.ReadLine()) * 0.01;
                }
            }

            //---------------------------------------------------------------
            void CmyKToRgb()//CMYK para RGB
            {
                DigitarEntrada(2);
                R = (1 - C) * 255 * (1 - K);
                G = (1 - M) * 255 * (1 - K);
                B = (1 - Y) * 255 * (1 - K);

                Console.WriteLine($"\nR = {R.ToString("F0")} G = {G.ToString("F0")} B = {B.ToString("F0")}");
            }

            //----------------------------------------------------------------------
            void RgbToCmyK()//RGB para CMYK
            {
                DigitarEntrada(1);

                double r = R / 255; double g = G / 255; double b = B / 255;

                double rgbMaior = Math.Max(b,Math.Max(r, g));
                //double CMaior = Math.Max(rgMaior, b);

                K = 1 - rgbMaior;
                C = ((1 - r - K) / (1 - K)) * 100;
                M = ((1 - g - K) / (1 - K)) * 100;
                Y = ((1 - b - K) / (1 - K)) * 100;

                Console.WriteLine($"\nC = {C.ToString("F0")} M = {M.ToString("F0")} Y = {Y.ToString("F0")} K = {(K * 100).ToString("F0")}");
            }

            void RgbToHsv()//RGB para HSV
            {
                DigitarEntrada(3);

                double r = R / 255; double g = G / 255; double b = B / 255;

                double rgMaior = Math.Max(r, g);
                double CMax = Math.Max(rgMaior, b);

                double rgMin = Math.Min(r, g);
                double CMin = Math.Min(rgMin, b);

                double delta = CMax - CMin;

                V = CMax;

                //S = (CMax == 0) ? 0 : 1d - (1d * CMin / CMax);
                S = 1 - (CMin / CMax);

                if (delta == 0)
                    H = 0;
                else
                {
                    if (CMax == CMin)
                    {
                        H = 0;
                    }

                    if (CMax == r && g >= b)
                    {
                        H = 60 * ((g - b) / (delta));
                    }
                    else if (CMax == r && g < b)
                    {
                        H = 60 * ((g - b) / (delta)) + 360;
                    }
                    else if (CMax == g)
                    {
                        H = 60 * ((b - r) / (delta)) + 120;
                    }
                    else if (CMax == b)
                    {
                        H = 60 * ((b - g) / (delta)) + 240;
                    }
                }

                Console.WriteLine($"\nH = {H .ToString("F0")}°  S = {(S * 100).ToString("F1")}%  V = {(V*100).ToString("F1")}%");
            }
            //------------------------------------------------------------------------
            void HsvToRgb() // HSV para RGB
            {
                DigitarEntrada(4);

                double r = 0, g = 0, b = 0, h = 0, f = 0, j = 0, p = 0, t = 0, q = 0;

                V = V > 1 ? 1 : V ;
                H = H > 359 ? 359 : H;

                if (S == 0)
                    H = 0;

                h = Math.Round((H / 60) % 6,0) ;
                f = (H / 60) - h;
                p = V*(1 - S);
                q = V*(1 - (f*S));
                t = V*(1 - (1 - f)*S);

                if (h == 0)
                {
                    R = V; G = t; B = p;
                }
                if (h == 1)
                {
                   R = q; G = V; B = p;
                }
                if (h == 2)
                {
                   R = p; G = V; B = t;
                }
                if (h == 3)
                {
                  R = p; G = q; B = V; 
                }
                if (h == 4)
                {
                    R = t; G = p; B = V;
                }
                if (h == 5)
                {
                    R = V; G = p; B = q;
                }
                if (h == 6)
                {
                    R = V; G = p; B = S-q;
                }

                R *= 255;
                G *= 255;
                B *= 255;

                Console.WriteLine($"R = {R.ToString("F0")} G = {G.ToString("F0")} B = {B.ToString("F0")}");
            }
        }
    }
}


