#include <iostream>
#include <omp.h>
#include <math.h>

/* run this program using the console pauser or add your own getch, system("pause") or input loop */
using namespace std;

int main(int argc, char** argv) {
	
	//printf("\n\nOpemMp : Hello, world!!\n");
	
//	int n_threads = 0;
//	
//	n_threads = omp_get_max_threads();
	
//	printf("\nNumero de Therades (nucleos); %d \n\n",  n_threads);
	
//	#pragma omp parallel
//	{
//		int id_thread = omp_get_thread_num();
//		printf(" id %d", id_thread);
//	}
	
////////////////////////////////////////////////	
	
	int const n =50, nl = 2, nc =3;
	int A[nl][nc], B[nl][nc], C[nl][nc];
	int ID[n];
	
	
	
	
	for(int i=0 ;i<nl; i++){
		
		for(int j=0 ;j<nc; i++)
		{
		 A[i][j] = i+1 + j+1;
	     B[i][j]= i+1 + j+1;
	    }
		
	}
	
//	for(int i=0 ;i<n; i++){
//		C[i] = A[i]+ B[i];
//	}

/*#pragma omp parallel
	{
		int id = omp_get_thread_num();
		int nd = omp_get_num_threads();
		
		int tamanho = n/nd;
		
		int inicio = id * tamanho;
		int fim = inicio + tamanho -1;
		
		for(int i=inicio ;i<=fim; i++){
		 C[i] = A[i]+ B[i];
   	   }
	  
	}*/
	
//	printf(omp_get_num_threads())
/*
	#pragma omp parallel
        {
                int tamanho, inicio, fim;
                int id = omp_get_thread_num();
                int nt  = omp_get_num_threads();
                
                if(nt > n){
                        if(id <= n-1){
                                tamanho = 1;
                                inicio = id;
                                fim = id;
                        }
                        else{
                                inicio = 0;
                                fim = -1;        
                                tamanho = 0;
                        }
                }else{
                        tamanho = n/nt;
                        inicio = id * tamanho;
                        fim = inicio + tamanho -1;
                        
                        if(id == nt-1){
                                fim =  n-1;
                                tamanho = fim - inicio + 1;
                        }
                }
                
                for(int i = inicio; i<= fim; i++){
                        C[i] = A[i] + B[i];
        }
    }
      */ 
	    
#pragma omp parallel
        {  
            #pragma omp for
               for(int i =0; i<nl; i++)
			   {
               	for(int j =0; j<nc; j++){
                            C[i][j] = A[i][j] + B[i][j];
                           // ID[i] = omp_get_thread_num();
                    }
			   }           
        }
   

    printf("\nA=n");
	
	for(int i=0 ;i<nl; i++){
		
		for(int j=0 ;j<nc; i++)
		{
		   printf("%5d ", B[i][j]);
	    }
		printf("\n");
	}
	
	 printf("\n\nb=n");
	for(int i=0 ;i<nl; i++){
		
		for(int j=0 ;j<nc; i++)
		{
		   printf("%5d ", B[i][j]);
	    }
		printf("\n");
	}
	
	#pragma omp parallel
        {
            #pragma omp for
               for(int i =0; i<nl; i++)
			   {
               	for(int j =0; j<nc; j++){
                            C[i][j] = A[i][j] + B[i][j];
                           // ID[i] = omp_get_thread_num();
                    }
			   }
                        
        }
	
  // 	imprimindo o resultado
  
	printf("\n\nc = \n");
		for(int i=0 ;i<nl; i++){
		
		for(int j=0 ;j<nc; i++)
		{
		   printf("%5d ", B[i][j]);
	    }
		printf("\n");
	}
	
	return 0;
}
