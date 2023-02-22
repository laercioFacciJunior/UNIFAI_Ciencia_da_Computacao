#include <iostream>

/* run this program using the console pauser or add your own getch, system("pause") or input loop */

int main(int argc, char** argv) {

	int i, j,k;
	int const n = 2;
	float U[n][n], L[n][n], x[n], y[n];
	float numerador, denominador;
	
	for(int i=0; i<n; i++)
	{
		for(j=0; j<n; j++)
		{			
			U[i][j] = i+1;
			L[i][j] = i+1;
		}
	}	
	
	for(i=0; i<n; i++)
	{
		for(j=0; j<n; j++)
		{
			U[i][j] = A [i][j];
			
			if(i==j)
				L[i][j] = 1;
			else
			if( j > i )
				L[i][j] = 0;
			else
				L[i][j] = 0;
		}
	}
	
	for(k=0; k<n-1; k++)
	{
		for(i=k+1; i<n; i++)
		{
			numerador = U[i][k];
			denominador = U[k][k];
			
			L[i][k] = numerador/denominador;
			
			for(j=k; j<n; j++)
			{
				U[i][j] = U[i][j] - L[i][k] * U[k][j];
			}
		}
	}
	
	for(i=0; i<n; i++)
	{
		y[i] = b[i];
		
		for(j=0; j<=i-1; j++)
		{
			y[i] = y[i] - L[i][j] * y[j];
		}
	}
	
	for(i=n-1; i>=0; i--)
	{
		x[i] = y[i];
		
		for(j=n-1; j>=i+1; j--)
		{
			x[i] = x[i] - U[i][j] * x[j];
		}
		
		x[i] = x[i] / U[i][i];
	}
	

	
	return 0;
}
