using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMPTY : MonoBehaviour
{
    /*
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UIElements;

    public class CPU_AI : MonoBehaviour
    {

        public int dif, cpuFMayor, cpuFMenor=0, cpuNpalitos, indexPalitos, palitosRestantes;
        public playController4 SplayC4cpu;
        public buttonPalito4 buttonPalito4_scriptCPU_AI;

        public void Selec_ExecDifCPU(int d)             //ELIJO DIFICULTAD TO EXE
        { if (d == 0) { EASY_CPUFilas(); }     //if (d == 1) { MediumCPUFilas(); }       if (d == 2) { HardCPUFilas(); }
        }
        public int IndexByRow(int f)                            //DEFINO EL INDICE DE PANEL.CHILD() DESDE DONDE EMPIEZO A BUSCAR (FILA)
        { int aux = 0;
            if (f == 1) aux = 1; if (f == 2) aux = 4; if (f == 3) aux = 9; if (f == 4) aux = 16;
            return aux;
        }
        public bool NTFilasPar()        //TOTAL FILAS IMPAR(1-3-5) O PAR (2-4)
        { if (SplayC4cpu.filasT % 2 != 0)
            { return true; } else { return false; }
        }
        public void TUYOTU()
        {
            int aux = SplayC4cpu.filasVar[cpuFMayor];
            if (NTFilasPar())
            {
                aux = SplayC4cpu.filasVar[cpuFMayor] - 1;
            }
            indexPalitos = IndexByRow(cpuFMayor);
            NPalitosFila(aux, cpuFMayor, indexPalitos);
        }
        public void MatchSimpleSymmetry( int a, int b)
        {
         //   if ((SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[iteratorM + a]] - SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[iteratorM + b]]) != 0)
           // {
                indexPalitos = IndexByRow(a);
                NPalitosFila((SplayC4cpu.filasVar[a] - SplayC4cpu.filasVar[b]), a, indexPalitos);
            Debug.Log("la puta resta da= " + (SplayC4cpu.filasVar[a] - SplayC4cpu.filasVar[b]));
            //  }
          //  else { AloPendejo(); }
        }
        public void MatchDoubleSymmetry()
        {
            if ((SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMenor]] == SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMenor + 1]]) &&
                (SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMenor+2]] == SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMenor+3]]))
            {   AloPendejo(); 
            }
            else 
            {           if (SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMenor]] == SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMenor + 1]])
                        {   MatchSimpleSymmetry(cpuFMayor, SplayC4cpu.filasVarOrden[SplayC4cpu.filasVarOrden.Length-2]); Debug.Log("SIMETRIA EN 4 FILAS(1)");
                }
                        else if (SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMenor + 1]] == SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMenor + 2]])    //AQUI
                        {   MatchSimpleSymmetry(cpuFMayor, SplayC4cpu.filasVarOrden[cpuFMenor]); Debug.Log("SIMETRIA EN 4 FILAS(2)");
                }
                        else if (SplayC4cpu.filasVar[cpuFMayor] == SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMenor + 2]])
                        {MatchSimpleSymmetry(SplayC4cpu.filasVarOrden[cpuFMenor + 1], SplayC4cpu.filasVarOrden[cpuFMenor]); Debug.Log("SIMETRIA EN 4 FILAS(3)");
                }
            }
        }
        public void ObliterateRow(int o)
        {
            indexPalitos = IndexByRow(SplayC4cpu.filasVarOrden[o]);
            NPalitosFila(SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[o]], SplayC4cpu.filasVarOrden[o], indexPalitos);
        }

        public void AloPendejo()
        {
            int rRow = cpuFMayor - ((Random.Range(1, SplayC4cpu.filasT)) - 1); int rNP = Random.Range(1, SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[rRow]]);
            indexPalitos = IndexByRow(SplayC4cpu.filasVarOrden[rRow]);
            NPalitosFila(rNP, SplayC4cpu.filasVarOrden[rRow], indexPalitos);//1,2,4
            Debug.Log(" rRow" + rRow);
            Debug.Log("rNP"+ rNP);
            Debug.Log(" A LO PENDEJO (RANDOM)");   
        }
        /* public void MatchFirstPattern()
         { int aux;

             if (SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMenor]] == SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMenor + 1]])
             { aux = 1;
                 SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor]] -= (SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor]] - aux);
             }
             else if (SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMenor + 1]] != 2)
             { aux = 2;
                 SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor]] -= (SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor]] - aux);
             }
             else { aux = 3; }
             }*/

    /*                                                                                                                                                                                                  COÑO
public int TargetNumberToPattern(int x) //  ??????????????????????????????????????? 
{
    SplayC4cpu.filasVar[cpuFMayor] -= (SplayC4cpu.filasVar[cpuFMayor] - x);
    return 0;
}
public void EASY_CPUFilas()
{
    if (SplayC4cpu.filasT == 1)// UNA SOLA FILA=FILA-1
    {
        indexPalitos = IndexByRow(cpuFMayor);
        NPalitosFila(SplayC4cpu.filasVar[cpuFMayor] - 1, cpuFMayor, indexPalitos);
        Debug.Log("UNA SOLA FILA=FILA-1");
    }
    else if ((palitosRestantes >= 2) && (SplayC4cpu.filasVar[cpuFMayor] == 1))// (2 PALITOS 1FILA) O MAS PALITOS 1 SOLO X FILA = CUALQUIER PALITO (1)
    {
        indexPalitos = IndexByRow(cpuFMayor);
        NPalitosFila(1, cpuFMayor, indexPalitos);// checar
        Debug.Log("(2 PALITOS 1FILA) O MAS PALITOS 1 SOLO X FILA = CUALQUIER PALITO (1)");

    }
    else if ((palitosRestantes > 2) && (SplayC4cpu.filasVar[cpuFMayor] > 1) && (SplayC4cpu.filasVar[cpuFMayor - 1] == 1))
    {
        TUYOTU();           //  CALCULO PRECISO DE ITERACIONES... medium?
        Debug.Log("CALCULO PRECISO DE ITERACIONES");

    }
    else if ((SplayC4cpu.filasT == 2) && (SplayC4cpu.filasVar[cpuFMayor] != SplayC4cpu.filasVar[cpuFMayor]))//SIMETRIA EN 2 FILAS
    {
        MatchSimpleSymmetry(cpuFMayor, SplayC4cpu.filasVarOrden[cpuFMenor + 2]);                      //      MEDIUM
        Debug.Log("SIMETRIA EN 2 FILAS");

    }
    else if ((SplayC4cpu.filasT == 4) && ((SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMenor]] == SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMenor + 1]]) ||
        (SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMenor + 1]] == SplayC4cpu.filasVar[cpuFMenor + 2]) ||
        (SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMenor + 2]] == SplayC4cpu.filasVar[cpuFMenor + 3]))) //SIMETRIA EN 4 FILAS
    {
        MatchDoubleSymmetry();                              // MEDIUM... o hard?
    }
    else if ((SplayC4cpu.filasT == 3) && (SplayC4cpu.filasVar[cpuFMayor] == SplayC4cpu.filasVar[cpuFMayor - 1]))
    {
        ObliterateRow(cpuFMenor);
        //MATCHING Symmetry (ABB)          ======> HARD
        Debug.Log("MATCHING Symmetry (ABB)  ");
    }

    else if ((SplayC4cpu.filasT == 3) && (SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMenor]] == SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMenor + 1]]))
    {
        ObliterateRow(SplayC4cpu.filasVarOrden.Length - 1);
        Debug.Log("MATCHING Symmetry (AAB)  ");
        //MATCHING Symmetry (AAB)          ======> HARD

    }                                                                                       //MATCHING FIRST PATTERN (1-2-3)         ======> HARD
    /*   else if ((SplayC4cpu.filasT >= 3)&&((SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor-1]]<=3)&&(SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMenor]]<=2)))                                   
       {
           MatchFirstPattern();
       }*/
    /*                                                                                                                                   COÑO
 else
 {
     AloPendejo();
 }

}                                           //  1           2           4
public void NPalitosFila(int cpuN, int cpuF, int ind)           //QUITA N_PALITOS  DE X_FILA DESDE X_INDICE HASTA Y_INDICE ((int i =N°Palitos;) por fila (9-7-5-3-1))
{
 int top = ind + (2 * cpuF);// SplayC4cpu.filasVarOrden[cpuF]);
 for (int i = ind; i <= top; i++)
 {
     if (SplayC4cpu.panel.transform.GetChild(i).gameObject.activeSelf == true && cpuN > 0)
     {
         buttonPalito4_scriptCPU_AI = SplayC4cpu.panel.transform.GetChild(i).gameObject.GetComponent<buttonPalito4>();
         buttonPalito4_scriptCPU_AI.PalitoOutProcess();
         cpuN--;
     }
 }
}
void Start()
{
 dif = MyStaticData.nDificulty;
 cpuFMayor = MyStaticData.nRows - 1;
}
void Update()
{
 if (palitosRestantes == 1)
 {
     palitosRestantes = 0;
     SplayC4cpu.GameOver();
 }
}

}

//public void MediumCPUFilas() { }        public void HardCPUFilas() { }               


//////////////////////////////////////////EXTRA COÑO
///

 public void FilasVar_Orden_T_FMM_Maintenance(int x)
{
 if (filasVar[x] == 0)
 {
     filasT = filasT-1;
     filasVar[x] = -1;
 }
 int aux;
 // filasVar = new int[X] { 1, 3, 5, 7 };     X==>K
 // filasVarOrden = new int[4] { 0, 1, 2, 3 };
 // filasVar = new int[X] { 1, 3, 5, 4 };     X==>K
 // filasVarOrden = new int[4] { 0, 1, 3, 2 };
 // filasVar = new int[X] { 1, 3, 3, 4 };     X==>K
 // filasVarOrden = new int[4] { 0, 1, 2, 3 };
 if (x >= 1)
 {
     for (int o = 1; o < filasVarOrden.Length; o++) 
     {
         if (filasVarOrden[o] == x)
         {
             for (int i = o; i > 0; i--)
             {
                 if (filasVar[filasVarOrden[i]] < filasVar[filasVarOrden[i - 1]])
                 {
                     aux = filasVarOrden[i - 1];
                     filasVarOrden[i - 1] = filasVarOrden[i];
                     filasVarOrden[i] = aux;
                 }
                 else { i = 0; }
             }
         }
     }
 }

 for (int i = 0; i < filasVar.Length; i++)
 {
     if (filasVar[filasVarOrden[i]] != -1)
     {

                        cPU_AI_script.cpuFMenor =i;                               
         i = filasVarOrden.Length;
     }
 }
 cPU_AI_script.cpuFMayor = filasVarOrden[filasVarOrden.Length-1];


}








*/
}
