using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MySortsAlgorithims : MonoBehaviour
{

    ///////////////////////////////////////////////////////////////SORT_BASICS/////////////////////////////////////////////////////////
    int[] sortArray = new int[10];
    public void PrintSort()
    {
        for (int i = 0; i < sortArray.Length; i++)
        {
            Debug.Log("sortArray[" + i + "] " + sortArray[i]);
        }
    }
    public void FillArray()
    {
        for (int i = 0; i < sortArray.Length; i++)
        {
            sortArray[i] = UnityEngine.Random.Range(0, 15);
        }
    }
    public void Printing()
    {
        FillArray();
        PrintSort();
        //MergeSort(sortArray, 0, sortArray.Length - 1);
        //Quick_Sort(sortArray, 0, sortArray.Length - 1);
        // PrintSort();
    }
    ///////////////////////////////////////////////////////////////MERGESORT/////////////////////////////////////////////////////////

    //FUNCION PARA DIVIDIR EN SUBARRAYS (RECURSIVIDAD)

    void MergeSort(int[] array, int start, int end)
    {
        if (start == end) { return; }
        int myM = (start + end) / 2;                                                                                                                                      //(mitad)
        MergeSort(array, start, myM); MergeSort(array, myM + 1, end);                                                                        //divido en 2 (recursividad hasta q no se pueda dividir)
        int[] aux = Merge(array, start, myM, myM + 1, end);                                                                                            //mezclo (ya ordenada(recursividad(!!!)))   (DE REGRESO)
        Array.Copy(aux, 0, array, start, aux.Length);                                                                                                       //VS    Array.Copy(aux, 0, array, start, end); ??? (copio a array auxiliar)
    }
    //FUNCION QUE MEZCLA Y ORDENA:
    public int[] Merge(int[] array, int S1, int F1, int S2, int F2)
    {
        int[] result = new int[(F1 - S1) + (F2 - S2) + 2];                            //((4-0)+(9-5))  +  (((2))) por el 0 y Length-1 => 10
        for (int i = 0; i < result.Length; i++)                                             // recorriendo todo el arreglo auxiliar 
        {
            if (S2 != array.Length)                                                             //si S2 no se ha salido de indice de array por el "S2++" ((array.Length-1)(++)=>array.Length)
            {
                if ((S1 > F1 && S2 <= F2))                                               //si S1 es mayor q el limite final (F1) es por q ya entro en un caso previamente en el (i)anterior (++) y por default entra de segundo el S2 (ordenando)
                {
                    result[i] = array[S2]; S2++;
                }
                if (S2 > F2 && S1 <= F1)                                                  //si S2 es mayor q el limite final (F2) es por q ya entro en un caso previamente en el (i)anterior (++) y por default entra de segundo el S1 (ordenando) 
                {
                    result[i] = array[S1]; S1++;
                }
                if (S1 <= F1 && S2 <= F2)                                                   // caso estandar (3 y 4) (limite inferior <= limite superior), se compara S2 < S1(caso 3) o... S1 < S2 (caso 4)
                {
                    if (array[S2] <= array[S1])
                    {
                        result[i] = array[S2]; S2++;
                    }
                    else
                    {
                        result[i] = array[S1]; S1++;                               // (...CASO 3, SINO, CASO 4) caso estandar (3 y 4) (limite inferior <= limite superior), se compara S2 < S1(caso 3) o... S1 < S2 (caso 4)
                    }
                }
            }
            else if (S1 <= F1)                                                                    // si S2 se salio de rango no queda mas q añadir el S1 a result
            {
                result[i] = array[S1]; S1++;                                        // y de ser posible seguir entrando en este caso mientras q S1<=F1 (S1++) de lo contrario se consume el for y culmina la llamada recursiva para proseguir con la anterior
            }
        }
        return result;
    }

    ///////////////////////////////////////////////////////////////MERGESORT/////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////QUICKSORT/////////////////////////////////////////////////////////

    int[] Swap(int[] array, int a, int b)
    {
        int aux = array[a];
        array[a] = array[b];
        array[b] = aux;
        return array;
    }
    int Sliver(int[] array, int ini, int fin)
    {
        int pivot = fin, iPivot = ini, index;

        if (array.Length <= 1) { return 0; }
        for (index = 0; index < array.Length; index++)
        {
            if (array[ini] < array[pivot]) { iPivot++; }
            if (array[index] < array[pivot]) { array = Swap(array, index, iPivot); iPivot++; }
        }
        Swap(array, pivot, iPivot); return iPivot;
    }
    void QuickS(int[] array, int ini, int fin)
    {
        if (ini >= fin) { return; }
        else
        {
            int ipivot = Sliver(array, ini, fin);
            QuickS(array, ini, ipivot - 1); QuickS(array, ipivot + 1, fin);
        }
        Array.Copy(array, 0, sortArray, 0, array.Length - 1);
    }

    ///////////////////////////////////////////////////////////////QUICKSORT/////////////////////////////////////////////////////////

    void Quick_Sort(int[] array, int ini, int fin)
    {
        if (ini < fin)
        {
            int pivot = Chunks(array, ini, fin);

            if (pivot > 1)
            {
                Quick_Sort(array, ini, pivot - 1);
            }
            if (pivot + 1 < fin)
            {
                Quick_Sort(array, pivot + 1, fin);
            }
        }
    }
    int Chunks(int[] array, int ini, int fin)
    {
        int pivot = array[ini];
        while (true)
        {

            while (array[ini] < pivot)
            {
                ini++;
            }

            while (array[fin] > pivot)
            {
                fin--;
            }

            if (ini < fin)
            {
                if (array[ini] == array[fin]) return fin;

                int temp = array[ini];
                array[ini] = array[fin];
                array[fin] = temp;

            }
            else
            {
                return fin;
            }
        }
    }

    ///////////////////////////////////////////////////////////////QUICKSORT/////////////////////////////////////////////////////////
    private void quicksort(int[] vector, int primero, int ultimo)
    {
        int i, j, temp, central = (primero + ultimo) / 2; ;
        double pivote = vector[central];
        i = primero; j = ultimo;
        do
        {
            while (vector[i] < pivote) i++;
            while (vector[j] > pivote) j--;
            if (i <= j)
            {
                temp = vector[i];
                vector[i] = vector[j];
                vector[j] = temp;
                i++; j--;
            }
        } while (i <= j);
        if (primero < j)
        {
            quicksort(vector, primero, j);
        }
        if (i < ultimo)
        {
            quicksort(vector, i, ultimo);
        }
    }


    ///////////////////////////////////////////////////////////////QUICKSORT/////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////SORTCOUNT/////////////////////////////////////////////////////////







    ///////////////////////////////////////////////////////////////SORTCOUNT/////////////////////////////////////////////////////////



    void Start()
    {
        //Printing();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
