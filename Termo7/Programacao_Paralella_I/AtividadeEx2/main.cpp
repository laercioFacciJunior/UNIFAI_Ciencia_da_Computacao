#include <iostream>
#include <omp.h>
using namespace std;


//--->> 1. Implemente a geração da sequência de Fibonacci recursiva e paralela

/*/=============== SEQUENCIA DE FIBONACCI RECURSIVA (Versão Single)================
long double Fibonacci(int n)
{
  if( n < 1 ) return 0;

  if(n== 1 || n == 2)return 1;

  else
    return Fibonacci (n-1) + Fibonacci(n-2);
} // int Fibonacci(int n).

int main(int argc, char** argv) {
  
  double t0, tf;
  int n;
  long double fibo;

  cout << "Informe qual elemento de da sequencia de Fibonacci deseja: ";
  cin >> n;

  t0 = omp_get_wtime(); // tempo inicial
  fibo = Fibonacci(n);
  tf = omp_get_wtime(); // tempo final

  printf("\n\nA sequencia %d de Fibonacci eh %.0Lf", n, fibo);
  printf("\n\nTempo: %.2f segundos", tf-t0);
  
  printf("\n\n\n");
  
  return 0;
} // main()
*/

//=============== SEQUENCIA DE FIBONACCI PARALELA ===================================
long double Fibonacci(int n)
{
  long double i = 0, j = 0;

  if( n < 1) return 0;
  
  if(n == 1 || n == 2) return 1;
  else if( n < 40 )
    return Fibonacci (n-1) + Fibonacci (n-2);
  else
  {
    #pragma omp task 
    {
      i = Fibonacci(n-1);
    }

    #pragma omp task 
    {
      j = Fibonacci(n-2);
    }

    #pragma omp taskwait
    {
      return i + j;
    }
  } // int Fibonacci(int n)
}

int main(int argc, char** argv) {
  double t0, tf;
  int n;
  long double fibo;

  cout<<"Informe qual elemento de da sequencia de Fibonacci deseja: ";
  //cin>>n;
   n=40;
  t0 = omp_get_wtime(); // tempo inicial
  
  #pragma omp parallel
  {
    #pragma omp single
    {
      fibo = Fibonacci(n);
    }
  }

  tf = omp_get_wtime(); // tempo final

  printf("\n\nA sequencia %d de Fibonacci eh %.0Lf", n, fibo);
  printf("\n\nTempo: %.2f segundos", tf-t0);

  printf("\n\n\n");

  return 0;
} // main()
//=================================================================================*/






//--->> 2. Considerando o seguinte algoritmo recursivo de busca sequencial em vetor, implemente sua versão paralelizada

/*/===================== BUSCA SEQUENCIAL RECURSIVA ================================
int BuscaSeq(int *vetor, int pesquisa, int i, int n)
{
  if(i < n )
  {
    if(vetor[i] == pesquisa ) 
    {
      return i;
    }
    return BuscaSeq(vetor, pesquisa, i+1, n);
  }
  else
  {
    return -1;
  } 
}// BuscaSeq

int main(int argc, char** argv) 
{
  int n = 3000, i;
  int vet[n];
  int pesquisa;

 
  for(int aux=0; aux<n; aux++)
  {
  	vet[aux] = aux+1;
  }
 
  printf("\n\nTOTAL DE NECLEOS: %d", omp_get_max_threads());

  printf("\n\nInforme o valor a ser pesquisado: ");
  cin >> pesquisa;
  
  double t0, tf;
  t0 = omp_get_wtime(); // tempo inicial
  i = BuscaSeq(vet, pesquisa, 0, n);
  tf = omp_get_wtime(); // tempo final



  if( i != -1)
  {
    printf("\n\nValor %d encontrado na posicao %i", pesquisa, i);
    printf("\n\nTempo: %.4f segundos", tf-t0);
  }
  else
  {
    printf("\n\nValor %d NAO encontrado!", pesquisa);
  	printf("\n\nTempo: %.4f segundos", tf-t0);
  }
  printf("\n\n\n");

  return 0;
} // main()
*/

/*/===================== BUSCA SEQUENCIAL PARALELA ==================================
int BuscaSeq(int *vetor, int pesquisa, int i, int n)
{
	long double r;
	
  if(i < n )
  {
    if(vetor[i] == pesquisa ) 
    {
      return i;
    }
    
    #pragma omp task shared(r)
    {
      r = BuscaSeq(vetor, pesquisa, i+1, n);
    }

    #pragma omp taskwait
    {
      return r;
    }
  }
  else
  {
    return -1;
  } 
}// BuscaSeq

int main(int argc, char** argv) 
{
  int n = 3000, i;
  int vet[n];
  int pesquisa;
  double t0, tf;
 
  for(int aux=0; aux<n; aux++)
  {
  	vet[aux] = aux+1;
  }
 
  printf("\n\nTOTAL DE NECLEOS: %d", omp_get_max_threads());

  printf("\n\nInforme o valor a ser pesquisado: ");
  cin >> pesquisa;
  
  t0 = omp_get_wtime(); // tempo inicial
  
  #pragma omp parallel
  {
    #pragma omp single
    {
      i = BuscaSeq(vet, pesquisa, 0, n);
    }
  }

  tf = omp_get_wtime(); // tempo final

  if( i != -1)
  {
    printf("\n\nValor %d encontrado na posicao %i", pesquisa, i);
    printf("\n\nTempo: %.4f segundos", tf-t0);
  }
  else
  {
    printf("\n\nValor %d NAO encontrado!", pesquisa);
  	printf("\n\nTempo: %.4f segundos", tf-t0);
  }
  printf("\n\n\n");

  return 0;
} // main()
//=================================================================================
*/
