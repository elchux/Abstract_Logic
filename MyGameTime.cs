using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyGameTime : MonoBehaviour
{
    int timeTemp;
    public Text timeScene;
    public bool TimesON;
    public Image infintumSet;
    public playController4 playController4_scriptMyGameTime;
    public CPU_AI cPU_AI_scriptMyGameTime;
    public IEnumerator TimeCount()
    {
        if (MyStaticData.nTime != 0) //si noes infinito
        {
            for (int i = MyStaticData.nTime; i >= 0; i--)
            {
                timeScene.text = (i).ToString();
                yield return new WaitForSeconds(1); //(para q cuente por segundos)
            }
            ///////////////////////////////////////////GAME OVER TIME´S UP!//////////////////////////////////////////////////////////
            playController4_scriptMyGameTime.turnoP1 = playController4_scriptMyGameTime.TurnToWP1(playController4_scriptMyGameTime.turnoP1);//alterna el turno si pierdes por timeout
            playController4_scriptMyGameTime.newPalitoAvailable = false; //para q no se pueda seguir jugando 
            cPU_AI_scriptMyGameTime.palitosRestantes = 1;            //invoko al gameover por medio del scriptCPU (q siempre esta pendiente de si solo queda un palito (update))
            ///////////////////////////////////////////GAME OVER TIME´S UP!//////////////////////////////////////////////////////////

        }
    }
    public void StartingTime()
    {

        timeTemp = MyStaticData.nTime;
        timeScene.text = (timeTemp).ToString();
        if (MyStaticData.nTime == 0)  //si no hay tiempo 
        {
            infintumSet.gameObject.SetActive(true); //activo la imagen del infinito
            this.gameObject.SetActive(false);       //desactivo el gameObject q contiene este script y me olvido del tiempo 
        }
    }
    private void Update()
    {
        if (TimesON == true)
        {
            TimesON = false;
            StartCoroutine(TimeCount());
        }
    }
}
