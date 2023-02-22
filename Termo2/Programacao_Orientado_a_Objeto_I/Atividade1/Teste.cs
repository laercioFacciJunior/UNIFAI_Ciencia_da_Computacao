using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade1
{
    internal class Teste
    {
        int valor1, valor2;

        public Teste() {}

        public int getValor1()
        {
            return valor1;
        }

        public void setValor1(int valor1)
        {
            this.valor1 = valor1;
        }

        public int getValor2()
        {
            return valor2;
        }

        public void setValor2(int valor1)
        {
            this.valor2 = valor1;
        }

        public int MaiorValor()
        {
            if (valor1 == valor2)
                return -1;
            else if (valor1 > valor2)
                return valor1;
            else 
                return valor2;
        }

        public int MenorValor()
        {
            if (valor1 <= valor2)
                return valor1;
            else
                return valor2;
        }   
        
        public int ComparaValor1(int v)
        {
            if (v > getValor1())
                return -1;
            else if (v == getValor1())
                return 0;
            else
                return 1;
        }
    }
}
