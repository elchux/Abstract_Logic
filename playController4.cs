using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playController4 : MonoBehaviour
{
    public int[,] palitosArray;
    public Vector2[,] palitosArrayF;
    public Vector3[,] palitosArrayF_C;
    public int[] filasVar;
    public int[] filasVarOrden;
    public int[] columnasVar;
    public int[] Palitos;
    public Image fadeO;
    public GameObject panel;
    public MyGameTime myGameTime_scriptplayController4;
    public MercyActive mercyActive_scriptplayController4;
    public Text myTimeText;
    public bool palitoStill, newPalitoAvailable = true, turnoBegin, turnoP1, first;
    public int xArray, yArray, filasTemp, columnasTemp, palitojugado = -1, nJugada = 0, filasT;
    public string wins = "";
    public buttonPalito4 buttonPalito4_scriptTemp;
    public CPU_AI cPU_AI_script;
    public PlatesInGP pGP_script;
    public Image pauseNext;
    public Text pauseNP;
    public mediaPlayer mediaPlayer_scriptplayController4;
    //Fin variables

    //PENDIENTES:
    // M E N U !!!!
    //checar bug player turn
    //MERCY CPU
    //5 ROWS PLAYMODE
    //5 ROWS CPU_AI                     (CHECAR)

    //RNCOLUMNS GAMEPLAY

    //RNCOLUMNS CPU_AI
    //NO REPEAT MODE
    public void Paused()
    {
        Time.timeScale = 0;
        pauseNext.gameObject.SetActive(true);

    }
    public void Continue()
    {
        pauseNext.gameObject.SetActive(false);
        Time.timeScale = 1;
    }


    //CONSTRUCTOR INICIAL ESTRUCTURAL
    public void fillArray2_3()
    {
        Palitos = new int[panel.transform.childCount];
        for (int i = 0; i < panel.transform.childCount; i++)
        {
            Palitos[i] = int.Parse(panel.transform.GetChild(i).name);
        }
        first = true;/////////?????


        if (MyStaticData.nRows == 4)
        {
            filasVar = new int[4] { 1, 3, 5, 7 };
            filasVarOrden = new int[4] { 0, 1, 2, 3 };

            //falta para 5
            palitosArray = new int[4, 7] { { -1, -1, -1, 1, -1, -1, -1 }, { -1, -1, 1, 1, 1, -1, -1 }, { -1, 1, 1, 1, 1, 1, -1 }, { 1, 1, 1, 1, 1, 1, 1 } };
            palitosArrayF = new Vector2[4, 7];
            palitosArrayF_C = new Vector3[4, 7];
            columnasVar = new int[7] { 1, 2, 3, 4, 3, 2, 1 };
            xArray = 0; yArray = 0; filasTemp = 1; columnasTemp = 1;
            for (xArray = 0; xArray < 4; xArray++)
            {
                for (yArray = 0; yArray < 7; yArray++)
                {
                    if (palitosArray[xArray, yArray] == -1)
                    {
                        palitosArrayF[xArray, yArray] = new Vector2(-1, -1);
                        palitosArrayF_C[xArray, yArray] = new Vector3(-1, -1, -1);
                    }
                    else
                    {
                        palitosArrayF[xArray, yArray] = new Vector2(1, filasVar[xArray]);
                        palitosArrayF_C[xArray, yArray] = new Vector3(1, filasVar[xArray], (columnasVar[yArray]));
                    }
                }
            }
            //falta para 5
        }
        else if (MyStaticData.nRows == 5)
        {
            filasVar = new int[5] { 1, 3, 5, 7, 9 };
            filasVarOrden = new int[5] { 0, 1, 2, 3, 4 };
        }

        //data para reload
        cPU_AI_script.cpuFMenor = 0;                                                          //Reinicio aputador (cpuFMenor)
        filasT = MyStaticData.nRows;                                                            //UNA q se define para 5 =S
        cPU_AI_script.palitosRestantes = panel.transform.childCount;        //defino para CPU script numero de palitos restantes (inicio/reinicio) 
        mercyActive_scriptplayController4.gameObject.SetActive(false);  //reinicio mercy
    }// FIN CONSTRUCTOR

    //ACTUALIZO ESTRUCTURAS
    public void RefreshArrayV2V3(int x, int y, int fT, int cT)
    {
        for (int i = 0; i < MyStaticData.nColumns; i++)
        {
            if (i != y && palitosArrayF[x, i].x != -1)
            {
                palitosArrayF[x, i].y -= 1;
                palitosArrayF_C[x, i].y -= 1;
            }
        }
        for (int i = 0; i < MyStaticData.nRows; i++)
        {
            if (i != x && palitosArrayF_C[i, y].x != -1)
            {
                palitosArrayF_C[i, y].z -= 1;
            }
        }
        palitosArray[x, y] = 0;
        filasVar[x] -= 1;
        FilasVar_Orden_T_FMM_Maintenance(x);
        columnasVar[y] -= 1;
        palitosArrayF[x, y] = new Vector2(0, fT - 1);
        palitosArrayF_C[x, y] = new Vector3(0, (fT - 1), (cT - 1));
        cPU_AI_script.palitosRestantes = cPU_AI_script.palitosRestantes - 1;
    }//FIN DE LA ACTUALIZACION


    //MANTENGO EL ORDEN DE LAS FILAS Y OTRAS VARIABLES
    public void FilasVar_Orden_T_FMM_Maintenance(int x)
    {
        if (filasVar[x] == 0)
        {
            filasT = filasT - 1;
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

                cPU_AI_script.cpuFMenor = filasVarOrden[i];
                i = filasVarOrden.Length;
            }
        }

    }//FIN MANTENIMIENTO

    //GAME TURN REALTIME 
    IEnumerator IniciaTurno()
    { //  TurnToWP1(turnoP1);
        newPalitoAvailable = false;
        yield return new WaitForSeconds(1.50F);
        if (palitoStill == true)
        {
            palitoStill = false;
            StartCoroutine(WastingTime());
        }
    }
    public void GameOver()
    {

        StopAllCoroutines();
        palitoStill = false;
        wins = "WINS!";
        myGameTime_scriptplayController4.StopAllCoroutines();
        myGameTime_scriptplayController4.gameObject.SetActive(true);
        if ((MyStaticData.nPlayers == 1 || MyStaticData.nPlayers == 2) && turnoP1)
        {
            myGameTime_scriptplayController4.timeScene.text = "P1" + wins;
            if (MyStaticData.nDificulty == 0) { mediaPlayer_scriptplayController4.MyAudioS1(28); }
            if (MyStaticData.nDificulty == 1) { mediaPlayer_scriptplayController4.MyAudioS1(29); }
            if (MyStaticData.nDificulty == 2) { mediaPlayer_scriptplayController4.MyAudioS1(30); }
            pGP_script.RefreshWins(pGP_script.v1);
        }
        else if (MyStaticData.nPlayers == 2 && turnoP1 == false)
        {
            myGameTime_scriptplayController4.timeScene.text = "P2" + wins;
            pGP_script.RefreshWins(pGP_script.v2);
        }
        else if (MyStaticData.nPlayers == 1 && turnoP1 == false)
        {
            myGameTime_scriptplayController4.timeScene.text = "CPU" + wins;
            mediaPlayer_scriptplayController4.MyAudioS1(31);
            pGP_script.RefreshWins(pGP_script.v2);

        }
    }























    //TERMINA TURNO (TRANSISION ENTRE FIN/NUEVO TURNO)
    public IEnumerator WastingTime()
    {
        Debug.Log("turnoP1" + turnoP1);
        if (first == false)
        {
            GettingPlayMoves();
            turnoP1 = TurnToWP1(turnoP1);
        }
        else { yield return new WaitForSeconds(.5f); }
        myGameTime_scriptplayController4.gameObject.SetActive(true);
        if ((MyStaticData.nPlayers == 1 || MyStaticData.nPlayers == 2) && turnoP1)
        {
            myGameTime_scriptplayController4.infintumSet.gameObject.SetActive(false);
            if (MyStaticData.pauseTurns)
            { pauseNP.text = "P1 Next!"; Paused(); }
            myGameTime_scriptplayController4.timeScene.text = "P1";
            yield return new WaitForSeconds(1);
            if (MyStaticData.nTime == 0) { myGameTime_scriptplayController4.infintumSet.gameObject.SetActive(true); }
        }
        else if (MyStaticData.nPlayers == 2 && turnoP1 == false)
        {
            myGameTime_scriptplayController4.infintumSet.gameObject.SetActive(false);
            if (MyStaticData.pauseTurns)
            { pauseNP.text = "P2 Next!"; Paused(); }
            myGameTime_scriptplayController4.timeScene.text = "P2";
            yield return new WaitForSeconds(1);
            if (MyStaticData.nTime == 0) { myGameTime_scriptplayController4.infintumSet.gameObject.SetActive(true); }
        }
        else if (MyStaticData.nPlayers == 1 && turnoP1 == false)
        {//CPU 
            myGameTime_scriptplayController4.infintumSet.gameObject.SetActive(false);
            myGameTime_scriptplayController4.timeScene.text = "CPU";
            yield return new WaitForSeconds(1);
            myGameTime_scriptplayController4.timeScene.text = "";
            cPU_AI_script.Selec_ExecDifCPU(MyStaticData.nDificulty);

            yield return new WaitForSeconds(.5f);
            turnoP1 = TurnToWP1(turnoP1);
            myGameTime_scriptplayController4.timeScene.text = "P1";
            yield return new WaitForSeconds(1);
            if (MyStaticData.nTime == 0) { myGameTime_scriptplayController4.infintumSet.gameObject.SetActive(true); }
            //CPU end!!!
        }
        //yield return new WaitForSeconds(1);      <===OBJETIVO?

        myGameTime_scriptplayController4.timeScene.text = "";
        newPalitoAvailable = true;
        palitojugado = -1;
        if (first == true)
        {
            first = false;
            myGameTime_scriptplayController4.StartingTime();
        }
        myGameTime_scriptplayController4.TimesON = true;
    }


































    //RECOPILADOR DE JUGADAS
    public void GettingPlayMoves()
    {
        nJugada++;
        for (int i = 0; i < Palitos.Length; i++)
        {
            if ((panel.transform.GetChild(i).gameObject.activeSelf == false) && (panel.transform.GetChild(i).name == Palitos[i].ToString()))
            {
                Palitos[i] += (nJugada * 10000);
            }
        }
    }

    //IMPARIDAD DE TURNO/A QUIEN LE TOCA? QUIEN SALIO?
    public bool TurnToWP1(bool p1)
    {
        if (p1 == true) return false;
        return true;        //control para el definir turno a jugar ya sea P1 o P2(o CPU)
    }// FIN IMPARIDAD                                                       

    //SIGO JUGANDO INPUT==TRUE
    public void InputStill()       // ==>> palitoStill==true
    {
        if ((Input.touchCount == 0) && (Input.GetMouseButtonUp(0) == true))
        {
            palitoStill = false;
            StopCoroutine(IniciaTurno());
            StartCoroutine(WastingTime());
        }
    }//FIN SIGO JUGANDO

    // UPDATE!!!!!!!
    void Update()
    {
        if (turnoBegin)
        {
            turnoBegin = false;
            myGameTime_scriptplayController4.gameObject.SetActive(false);
            StartCoroutine(IniciaTurno());
        }
        if (palitoStill == true)
        {
            InputStill();
        }
        if (nJugada >= 2 && MyStaticData.mercy == true) { mercyActive_scriptplayController4.gameObject.SetActive(true); }

    }//FIN UPDATE

    public void StartingGame()
    {
        //TurnToWP1(turnoP1);                                 //HEREDA SI P1 JUGO PRIMERO EN EL TURNO ANTERIOR
        fillArray2_3();                                             //ESTRUCTURAS
        StartCoroutine(WastingTime());
    }

    //START!!!!!!!!!!!!!!
    void Start()
    {
        /*     //TurnToWP1(turnoP1);                                 //HEREDA SI P1 JUGO PRIMERO EN EL TURNO ANTERIOR
             fadeO.gameObject.SetActive(true);            //FADE TO ALPHA 
             fillArray2_3();                                             //ESTRUCTURAS
             myGameTime_scriptplayController4.TimesON = false;
             StartCoroutine(WastingTime());*/

        StartingGame();
        fadeO.gameObject.SetActive(true);            //FADE TO ALPHA 
        mediaPlayer_scriptplayController4 = FindObjectOfType<mediaPlayer>();
    }   //FIN START
}