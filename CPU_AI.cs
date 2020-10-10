using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CPU_AI : MonoBehaviour
{

        public int dif, cpuFMayor = MyStaticData.nRows - 1, cpuFMenor=0, cpuNpalitos, indexPalitos, palitosRestantes;
        public playController4 SplayC4cpu;
        public buttonPalito4 buttonPalito4_scriptCPU_AI;

        public void Selec_ExecDifCPU(int d)             //ELIJO DIFICULTAD TO EXE
        { if (d == 0) { EASY_CPUFilas(); }     if (d == 1) { MEDIUM_CPUFilas(); }       if (d == 2) { HARD_CPUFilas(); }
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
        public void TUYOTU()        //CALCULA PARIDAD DE ITERACIONES ()
        {
            int aux = SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor]];
            if (NTFilasPar())
            {
                aux = SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor]] - 1;
            }
            indexPalitos = IndexByRow(SplayC4cpu.filasVarOrden[cpuFMayor]);
            NPalitosFila(aux, SplayC4cpu.filasVarOrden[cpuFMayor], indexPalitos);
        }
        public void MatchSimpleSymmetry(int iteratorM, int b)       //SIMPLE SYMMETRY
        {
         //   if ((SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[iteratorM + a]] - SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[iteratorM + b]]) != 0)
           // {
                indexPalitos = IndexByRow(SplayC4cpu.filasVarOrden[iteratorM]);
                NPalitosFila((SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[iteratorM]] - SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[(iteratorM + b)]]), SplayC4cpu.filasVarOrden[iteratorM], indexPalitos);
          //  }
          //  else { AloPendejo(); }
        }
            public void ObliterateRow(int o)                                        //ELIMINA FILA COMPLETA
        {
            indexPalitos = IndexByRow(o);
            NPalitosFila(SplayC4cpu.filasVar[o], o, indexPalitos);
        }

        public void GETLUCKY()                                                      
        {///////////////////////////////////////////////////////////////ALCANZA CRITERIO 1°PATRON (123)/////////////////////////////////////////////////////////////
            int lucky1 = 0, lucky2 = 0, lucky3 = 0, uni = 0;
            for (int i = 0; i < 3; i++)
            {
                if (SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor - i]] == 1) { lucky1++; }
                else if (SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor - i]] == 2) { lucky2++; }
                else if (SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor - i]] == 3) { lucky3++; }
                else { uni++; }
            }
            if (uni == 1 && lucky1 <= 1 && lucky2 <= 1 && lucky3 <= 1 && (((lucky1) + (lucky2) + (lucky3)) == 2))
            {
                Debug.Log("GET LUCKY!");
                if (lucky1 == 0) //23N
                {
                    indexPalitos = IndexByRow(SplayC4cpu.filasVarOrden[cpuFMayor]);
                    NPalitosFila(SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor]] - 1, SplayC4cpu.filasVarOrden[cpuFMayor], indexPalitos);
                }                      //1   
                if (lucky2 == 0) //13N
                {
                    indexPalitos = IndexByRow(SplayC4cpu.filasVarOrden[cpuFMayor]);
                    NPalitosFila(SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor]] - 2, SplayC4cpu.filasVarOrden[cpuFMayor], indexPalitos);
                }                      //2   
                if (lucky3 == 0) //12N
                {
                    indexPalitos = IndexByRow(SplayC4cpu.filasVarOrden[cpuFMayor]);
                    NPalitosFila(SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor]] - 3, SplayC4cpu.filasVarOrden[cpuFMayor], indexPalitos);
                }                     //3
            }
            else { AloPendejo(); }
        }///////////////////////////////////////////////////////////////FIN PATTERN 123 GO!/////////////////////////////////////////////////////////////    
        public void MatchDoubleSymmetry()       //SIMETRIA EN 4 FILAS
        {
            if ((SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMenor]] == SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMenor + 1]]) &&
                (SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor]] == SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor - 1]]))
            {   AloPendejo(); 
            }
            else 
            {           if (SplayC4cpu.filasVar[cpuFMenor] == SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor -2]])
                        {   MatchSimpleSymmetry(cpuFMayor,  -1); Debug.Log("SIMETRIA EN 4 FILAS(1)");
                }
                        else if ((SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor - 2]] == SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor - 1]]))    //AQUI
                        {   MatchSimpleSymmetry(cpuFMayor,  -3); Debug.Log("SIMETRIA EN 4 FILAS(2)");
                }
                        else if (SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor]] == SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor - 1]])
                        {MatchSimpleSymmetry((cpuFMenor+1), -1); Debug.Log("SIMETRIA EN 4 FILAS(3)");
                }
            }
        }
    public int ChekingSymmetryfor5()
    {
        int misfit = 0;
        int twins = 0;
        for (int i = 0; i < 4; i++)
        {
            if (SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor - i]] == SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor - (i - 1)]])
            {
                twins++;
                i++;
            }
            else { misfit = cpuFMayor - i; }
        }
        if (twins == 2)
        {
            Debug.Log("SIMETRIA EN 5 PERRA");
            return misfit;
        }
        else return -1;
    }
    public void AloPendejo()                        //FUNCION RANDOM
        {
            int rRow = cpuFMayor - ((Random.Range(1, SplayC4cpu.filasT)) - 1); int rNP = Random.Range(1,4);
            indexPalitos = IndexByRow(rRow);
            NPalitosFila(rNP, rRow, indexPalitos);
            Debug.Log(" A LO PENDEJO (RANDOM)");
        }
        public void AloMedioPendejo()                        //FUNCION RANDOM
        {
            int rRow = cpuFMayor - ((Random.Range(1, SplayC4cpu.filasT)) - 1); int rNP = Random.Range(1, 3);
            indexPalitos = IndexByRow(rRow);
            NPalitosFila(rNP, rRow, indexPalitos);
            Debug.Log(" A LO MEDIO PENDEJO (RANDOM)");
        }
        public void AloPendejoReloaded()                        //FUNCION RANDOM (Reloaded)
        {
            int rRow = cpuFMayor - ((Random.Range(1, SplayC4cpu.filasT)) - 1);
            indexPalitos = IndexByRow(rRow);
            NPalitosFila(1, rRow, indexPalitos);
            Debug.Log(" A LO PENDEJO (RANDOMReloaded)");
        }

        /////////////////////////////////////////////////////////////INICIO MODULO DIFICULTAD/////////////////////////////////////////////////////////////
        public void EASY_CPUFilas()
        {
            //EASY
            if (SplayC4cpu.filasT == 1)
            {                                                                       // UNA SOLA FILA=FILA-1
                indexPalitos = IndexByRow(SplayC4cpu.filasVarOrden[cpuFMayor]);
                NPalitosFila(SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor]] - 1, SplayC4cpu.filasVarOrden[cpuFMayor], indexPalitos);
                Debug.Log("UNA SOLA FILA=FILA-1");
            }//EASY
            else if ((palitosRestantes >= 2) && (SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor]] == 1))
            {                                                                           // (2 PALITOS 1FILA) O MAS PALITOS 1 SOLO X FILA = CUALQUIER PALITO (1)
                indexPalitos = IndexByRow(SplayC4cpu.filasVarOrden[cpuFMayor]);
                NPalitosFila(1, SplayC4cpu.filasVarOrden[cpuFMayor], indexPalitos);// checar
                Debug.Log("(2 PALITOS 1FILA) O MAS PALITOS 1 SOLO X FILA = CUALQUIER PALITO (1)");
            }//EASY
            else if ((palitosRestantes > 2) && (SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor]] > 1) && (SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor - 1]] == 1))
            {                                                                          //  CALCULO PRECISO DE ITERACIONES... medium?
                TUYOTU();
                Debug.Log("CALCULO PRECISO DE ITERACIONES");
            }
            else
            {                                                                               //RANDOM! A LO WEY
                AloPendejo();
            }
        }       /////////////////////////////////////////////////////////////FIN MODULO    DIFICULTAD/////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////INICIO MODULO DIFICULTAD/////////////////////////////////////////////////////////////
        public void MEDIUM_CPUFilas()
        {
            //EASY
            if (SplayC4cpu.filasT == 1)
            {                                                                       // UNA SOLA FILA=FILA-1
                indexPalitos = IndexByRow(SplayC4cpu.filasVarOrden[cpuFMayor]);
                NPalitosFila(SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor]] - 1, SplayC4cpu.filasVarOrden[cpuFMayor], indexPalitos);
                Debug.Log("UNA SOLA FILA=FILA-1");
            }//EASY
            else if ((palitosRestantes >= 2) && (SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor]] == 1))
            {                                                                           // (2 PALITOS 1FILA) O MAS PALITOS 1 SOLO X FILA = CUALQUIER PALITO (1)
                indexPalitos = IndexByRow(SplayC4cpu.filasVarOrden[cpuFMayor]);
                NPalitosFila(1, SplayC4cpu.filasVarOrden[cpuFMayor], indexPalitos);// checar
                Debug.Log("(2 PALITOS 1FILA) O MAS PALITOS 1 SOLO X FILA = CUALQUIER PALITO (1)");
            }//EASY
            else if ((palitosRestantes > 2) && (SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor]] > 1) && (SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor - 1]] == 1))
            {                                                                          //  CALCULO PRECISO DE ITERACIONES... medium?
                TUYOTU();
                Debug.Log("CALCULO PRECISO DE ITERACIONES");
            }//MEDIUM
            else if ((SplayC4cpu.filasT == 2) && (SplayC4cpu.filasVar[cpuFMenor] != SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor]]))
            {                                                                           //SIMETRIA EN 2 FILAS
                MatchSimpleSymmetry(cpuFMayor, -1);                      //      MEDIUM
                Debug.Log("SIMETRIA EN 2 FILAS");
            }//MEDIUM
            else if ((SplayC4cpu.filasT == 3) && (SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor]] == SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor - 1]]))
            {                                                                           //MATCHING Symmetry (ABB)          ======> MEDIUM
                ObliterateRow(cpuFMenor);
                Debug.Log("MATCHING Symmetry (ABB)  ");
            }//MEDIUM
            else if ((SplayC4cpu.filasT == 3) && (SplayC4cpu.filasVar[cpuFMenor] == SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor - 1]]))
            {                                                                           //MATCHING Symmetry (AAB)          ======> MEDIUM
                ObliterateRow(SplayC4cpu.filasVarOrden[cpuFMayor]);
                Debug.Log("MATCHING Symmetry (AAB)  ");

            }//EASY
            else
            {                                                                               //RANDOM! A LO WEY
                AloMedioPendejo();
            }

        }       /////////////////////////////////////////////////////////////FIN MODULO    DIFICULTAD/////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////INICIO MODULO DIFICULTAD/////////////////////////////////////////////////////////////
        public void HARD_CPUFilas()
        {
        //EASY
        if (SplayC4cpu.filasT == 1)
        {                                                                       // UNA SOLA FILA=FILA-1
            indexPalitos = IndexByRow(SplayC4cpu.filasVarOrden[cpuFMayor]);
            NPalitosFila(SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor]] - 1, SplayC4cpu.filasVarOrden[cpuFMayor], indexPalitos);
            Debug.Log("UNA SOLA FILA=FILA-1");
        }//EASY
        else if ((palitosRestantes >= 2) && (SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor]] == 1))
        {                                                                           // (2 PALITOS 1FILA) O MAS PALITOS 1 SOLO X FILA = CUALQUIER PALITO (1)
            indexPalitos = IndexByRow(SplayC4cpu.filasVarOrden[cpuFMayor]);
            NPalitosFila(1, SplayC4cpu.filasVarOrden[cpuFMayor], indexPalitos);// checar
            Debug.Log("(2 PALITOS 1FILA) O MAS PALITOS 1 SOLO X FILA = CUALQUIER PALITO (1)");
        }//EASY
        else if ((palitosRestantes > 2) && (SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor]] > 1) && (SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor - 1]] == 1))
        {                                                                          //  CALCULO PRECISO DE ITERACIONES... medium?
            TUYOTU();
            Debug.Log("CALCULO PRECISO DE ITERACIONES");
        }//MEDIUM
        else if ((SplayC4cpu.filasT == 2) && (SplayC4cpu.filasVar[cpuFMenor] != SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor]]))
        {                                                                           //SIMETRIA EN 2 FILAS
            MatchSimpleSymmetry(cpuFMayor, -1);                      //      MEDIUM
            Debug.Log("SIMETRIA EN 2 FILAS");
        }//MEDIUM
        else if ((SplayC4cpu.filasT == 3) && (SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor]] == SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor - 1]]))
        {                                                                           //MATCHING Symmetry (ABB)          ======> MEDIUM
            ObliterateRow(cpuFMenor);
            Debug.Log("MATCHING Symmetry (ABB)  ");
        }//MEDIUM
        else if ((SplayC4cpu.filasT == 3) && (SplayC4cpu.filasVar[cpuFMenor] == SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor - 1]]))
        {                                                                           //MATCHING Symmetry (AAB)          ======> MEDIUM
            ObliterateRow(SplayC4cpu.filasVarOrden[cpuFMayor]);
            Debug.Log("MATCHING Symmetry (AAB)  ");

        }//HARD
        else if ((SplayC4cpu.filasT == 3) && (SplayC4cpu.filasVar[cpuFMenor] <= 2) && (SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor - 1]] >= 2) &&
            (SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor - 1]] <= 3) && (SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor]] >= 3))
        {                                                                                 //PATTERN 123 GO!
            GETLUCKY();

        }//HARD
        else if (((SplayC4cpu.filasT == 4) && ((SplayC4cpu.filasVar[cpuFMenor] == SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor - 2]]) ||
    (SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor - 2]] == SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor - 1]]) ||
    (SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor]] == SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor - 1]]))))
        {                                                                               //SIMETRIA EN 4 FILAS
            MatchDoubleSymmetry();                              // MEDIUM... o hard?
            Debug.Log("SIMETRIA EN 4 FILAS(2)");
        }//HARD
        else if ((SplayC4cpu.filasT == 4) && ((SplayC4cpu.filasVar[cpuFMenor] == 1) && (SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor - 2]] == 2) &&
             (SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor - 2]] == 2) && (SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor - 1]] == 3) &&
             (SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor]] > 3)))
        {                                                                               //LUCKY 123!
            Debug.Log("Lucky123");
            ObliterateRow(SplayC4cpu.filasVarOrden[cpuFMayor]);
        } else if (SplayC4cpu.filasT == 5)
            
            {

            if ((SplayC4cpu.filasVar[cpuFMenor] != SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor - 3]]) && (SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor - 3]] != SplayC4cpu.filasVar[SplayC4cpu.filasVarOrden[cpuFMayor - 2]]))
            { AloPendejoReloaded(); }
            else
            {
                int aux = ChekingSymmetryfor5();
                if (aux == -1)
                {
                    AloPendejoReloaded();
                }
                else {
            ObliterateRow(SplayC4cpu.filasVarOrden[aux]);
                }
            }
        }    
        
            else
            {                                                                               //RANDOM! A LO WEY
                AloPendejoReloaded();
            }

        }       /////////////////////////////////////////////////////////////FIN MODULO    DIFICULTAD/////////////////////////////////////////////////////////////



        //QUITA N_PALITOS  DE X_FILA DESDE X_INDICE HASTA Y_INDICE ((int i =N°Palitos;) por fila (9-7-5-3-1))   
        public void NPalitosFila(int cpuN, int cpuF, int ind)           //MAIN FUNCTION (palitoOut!)
        {
            int top = ind + (2 * cpuF);
            for (int i = ind; i <= top; i++)
            {
                if (SplayC4cpu.panel.transform.GetChild(i).gameObject.activeSelf == true && cpuN > 0)
                {
                    buttonPalito4_scriptCPU_AI = SplayC4cpu.panel.transform.GetChild(i).gameObject.GetComponent<buttonPalito4>();
                    buttonPalito4_scriptCPU_AI.PalitoOutProcess();
                    cpuN--;
                }
            }
        }                   //FIN FUNCION PRINCIPAL (palitoOut!)
        void Start()
        {   dif = MyStaticData.nDificulty;


        }
         void Update()
        {   if   (palitosRestantes == 1) 
            {      palitosRestantes = 0;
                    SplayC4cpu.GameOver();
            }
        }
    }

//public void MediumCPUFilas() { }        public void HardCPUFilas() { }               