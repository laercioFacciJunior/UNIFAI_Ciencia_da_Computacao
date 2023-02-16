//Implementem o algoritmo de ordenação por inserção simples aplicando em um vetor e analisando a
//complexidade e reduzindo o número de operações sempre que possível.
//Obs. Gere o vetor com valores aleatórios com pelo menos 1000 elementos.

//teste 1
//int valor = 1000;
//int[] vetor = new int[valor];

//for (int xi = 0; xi < vetor.Length; xi++)
//{
//    vetor[xi] = valor;
//    valor--;
//}

//teste2
int[] vetor = { 10, 30, 31, 15, 50, 60, 5, 22, 35, 14 };

Console.WriteLine("vetor original");
for (int ind = 0; ind < vetor.Length; ind++)
{
    Console.Write(" " + vetor[ind]);
}

Console.WriteLine("\n");

int k, y, i;
for (k = 1; k < vetor.Length; k++)
{
    y = vetor[k];

    for (i = k - 1; i >= 0 && vetor[i] > y; i--)
    {
        vetor[i + 1] = vetor[i];
    }
    vetor[i + 1] = y;

    for (int ind = 0; ind < vetor.Length; ind++)
    {
        Console.Write(" " + vetor[ind]);
    }
    Console.WriteLine("");
}

Console.WriteLine("\n\nVETOR ORDENADO");
for (int ind = 0; ind < vetor.Length - 1; ind++)
{
    Console.Write(" " + vetor[ind]);
}
