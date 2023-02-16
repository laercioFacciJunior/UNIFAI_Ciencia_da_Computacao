//Implementem o algoritmo de ordenação por seleção direta aplicando em um vetor e analisando a
//complexidade e reduzindo o número de operações sempre que possível.
//Obs. Gere o vetor com valores aleatórios com pelo menos 1000 elementos.

//teste 1
int valor = 1000;
int[] vetor = new int[valor];

for (int xi = 0; xi < vetor.Length; xi++)
{
    vetor[xi] = valor;
    valor--;
}

//teste 2
//int[] vetor = { 44, 55, 12, 42, 94, 18, 06, 67 };

Console.WriteLine("VETOR ORIGINAL");
for (int id = 0; id < vetor.Length; id++)
{
    Console.Write($"{vetor[id]} ");
}

int i, j, menor, index, indexM, maior;

for (i = 0; i < vetor.Length - 1 - i; i++)
{
    menor = vetor[i];
    maior = vetor[vetor.Length - 1 - i];
    index = i;
    indexM = vetor.Length - 1 - i;

    if (menor > maior)
    {
        var aux = maior;
        maior = menor;
        menor = aux;

        vetor[indexM] = vetor[i];
        vetor[i] = menor;
    }

    for (j = i + 1; j < vetor.Length - i; j++)
    {
        if (vetor[j] < menor)
        {
            menor = vetor[j];
            index = j;

        }
        if (vetor[j] > maior)
        {
            maior = vetor[j];
            indexM = j;
        }
    }

    vetor[index] = vetor[i];
    vetor[i] = menor;

    vetor[indexM] = vetor[vetor.Length - i - 1];
    vetor[vetor.Length - i - 1] = maior;

    Console.WriteLine("\n");

    for (int id = 0; id < vetor.Length; id++)
    {
        Console.Write($"{vetor[id]} ");
    }
}

Console.WriteLine("\n\nVetor ordendado");
for (int id = 0; id < vetor.Length; id++)
{
    Console.Write($"{vetor[id]} ");
}


