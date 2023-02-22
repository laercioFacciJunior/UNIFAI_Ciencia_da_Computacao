#include <iostream>
#include <stdlib.h>  /* malloc, free, rand */
#include <time.h>
#include <omp.h>
#include <conio.h>

using namespace std;

//=======================================================================
// Número inteiro aleatório entre i e n
int RandI(int i, int n) 
{
   return (rand() % n) + i;
}

//=======================================================================
// Número Float aleatório entre 0 e 1
float RandF() 
{
	return (float)rand() / (float)RAND_MAX; // ORIGINAL
}

//=======================================================================
// Número Float aleatório entre i e j
float RandF(float i, float j)  
{
	return i + RandF() * (j - i); 
}

//================================================================================================================================================================
float** AlocarMatrizFloat(int Linhas,int Colunas)
{  
  int i,j; 
 
  //Aloca uma Matriz de Ponteiros
  float **m = (float**)malloc(Linhas * sizeof(float*)); 
 
  //Percorre as linhas do Vetor de Ponteiros
  for (i = 0; i < Linhas; i++)
  { 
       //Aloca um Vetor de Float  para cada posição do Vetor de Ponteiros.
       m[i] = (float*) malloc(Colunas * sizeof(float)); 
       
       //Percorre o Vetor de Inteiros atual.
       for (j = 0; j < Colunas; j++)
       { 
            m[i][j] = 0; //Inicializa com 0.
       }
  }
  return m; //Retorna o Ponteiro para a Matriz Alocada
  
} // AlocarMatrizFloat



//=======================================================================
int main(int argc, char** argv) {
	
	
    setlocale(LC_ALL,""); //Alterando o charset para o padrão do sistema operacional //printf ("Localidade corrente: %s\n", setlocale(LC_ALL,NULL) );

	// definindo a semente para os números aleatórios
	//unsigned long int semente = (unsigned)time(0); // semente variada 	
	unsigned long int semente = 0; // semente fixa
	
	// recomenda-se utilizar apenas uma vez na execução do programa e antes de utilizar a função rand()
	srand( semente );  
	
	clock_t t0, tf;
	double tempo;
	
	int i, j, k;
/**
	int nlA = 2000;
	int ncA = 3000;		
	int nlB = 3000;
	int ncB = 4000;	
/**/
	int nlA = 1000;
	int ncA = 2000;		
	int nlB = 2000;
	int ncB = 1000;	

	
	int nlC = nlA;
	int ncC = ncB;	

	float **A, **B, **C;
	
	A = AlocarMatrizFloat(nlA, ncA);
	B = AlocarMatrizFloat(nlB, ncB);
	C = AlocarMatrizFloat(nlA, ncB);
	
	// Atribuindo valores para as matrizes A e B
	for(int i=0; i<nlA; i++)
	{
		for(int j=0; j<ncA; j++)
		{
			A[i][j]	= 1;
		}
	}
	
	for(i=0; i<nlB; i++)
	{
		for(j=0; j<ncB; j++)
		{
			B[i][j]	= 1;
		}
	}	
	
	for(i=0; i<nlC; i++)
	{
		for(j=0; j<ncC; j++)
		{
			C[i][j]	= 0;
		}
	}	

	printf("\n\nMultiplicando as matrizes...\n\n");

	t0 = clock();
	
	// Multiplicação das matrizes sem paralelismo ----------------------------------------------

	for(i=0; i<nlC; i++)
	{
		for(j=0; j<ncC; j++)
		{
			for(k=0; k<ncA; k++)
			{
				C[i][j] = C[i][j] + A[i][k] * B[k][j];
								
			} // k
			
		} // j	
		
	} // i
	
	tf = clock();	
	
   	tempo = ((double)(tf - t0)) / (double)CLOCKS_PER_SEC;   	

   	printf("\n\nTempo Computacional %10.5f segundos\n\n", tempo);
	
	
	return 0;
	
} // main()












