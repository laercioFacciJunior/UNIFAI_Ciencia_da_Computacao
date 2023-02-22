using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade2
{
    internal class Conta
    {
        string nroConta, nome;
        double saldo = 0;
        public Conta() { }

        public string getNroConta()
        {  return nroConta; }

        public void setNumeroConta(string nroConta)
        { this.nroConta = nroConta; }

        public string getNome()
        { return nome; }

        public void setNome(string nome)
        { this.nome = nome; }

        public bool Sacar(double quantia)
        {
            if(quantia < 0)
                return false;
            
            this.saldo -= quantia;
            return true;
        }

        public bool Depositar(double quantia)
        {
            if (quantia < 0)
                return false;
                        
            this.saldo += quantia;
            return true;
        }

        public double Consultar()
        {
            return this.saldo;
        }
    }
}
