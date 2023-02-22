namespace Atividade1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int v1 = 0, v2 = 0, v3 = 0;

            Console.Write("Digite Valor1 = ");
            v1 = int.Parse(Console.ReadLine());

            Console.Write("Digite Valor2 = ");
            v2 = int.Parse(Console.ReadLine());

            Teste teste = new Teste();
            teste.setValor1(v1);
            teste.setValor2(v2);

            Console.WriteLine("\nMAIOR VALOR = "+ teste.MaiorValor());

            Console.WriteLine("Menor VALOR = " + teste.MenorValor());

            Console.Write("\nDigite um Valor para comparar com Valor1 = ");
            v3 = int.Parse(Console.ReadLine());

            Console.WriteLine("comparar valor = "+ teste.ComparaValor1(v3)); 
        }
    }
}