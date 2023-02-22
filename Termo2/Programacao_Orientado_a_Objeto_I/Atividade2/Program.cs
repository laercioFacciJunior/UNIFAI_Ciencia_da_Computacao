namespace Atividade2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nroConta = "123456", nome = "Laercio Junior";
            double saque, deposito;
            int Opcao = -1;

            Conta conta = new Conta();
            conta.setNumeroConta(nroConta);
            conta.setNome(nome);

            while(Opcao != 0)
            {
                Console.WriteLine($"\nConta: {conta.getNroConta()}  Nome: {conta.getNome()}");

                Console.WriteLine("DIGITE UMA OPCAO:");
                Console.WriteLine("1 Sacar, 2 Depositar, 3 Consultar Saldo ou 0 para sair ");
                Opcao = int.Parse(Console.ReadLine());

                switch (Opcao)
                {
                    case 0:
                        return;

                    case 1:
                        Console.Write("Digite o valor do Saque = ");
                        saque = double.Parse(Console.ReadLine());

                        if(!conta.Sacar(saque)) 
                           Console.WriteLine("O saque não pode ser negativo");
                    break;

                    case 2:
                        Console.Write("Digite o valor do Deposito = ");
                        deposito = double.Parse(Console.ReadLine());
                        
                        if(!conta.Depositar(deposito))
                          Console.WriteLine("O Deposito não pode ser negativo");
                        break;

                    case 3:
                        Console.WriteLine($"Saldo no valor de = {conta.Consultar()}");
                    break;
                }
            }           
        }
    }
}