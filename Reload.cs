using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reload : MonoBehaviour
{
    public playController4 playController4_scriptsReload;
    public MyGameTime myGameTime_scriptReload;
    public mediaPlayer mediaPlayer_scriptReload;

    public void MyReload() 
    {
        mediaPlayer_scriptReload.MyAudioS2(7);
        myGameTime_scriptReload.StopAllCoroutines();
        playController4_scriptsReload.StopAllCoroutines();
        playController4_scriptsReload.turnoP1= playController4_scriptsReload.TurnToWP1(playController4_scriptsReload.turnoP1);
        for (int i = 0; i < playController4_scriptsReload.Palitos.Length; i++) 
        {
            playController4_scriptsReload.panel.transform.GetChild(i).gameObject.SetActive(false);

            playController4_scriptsReload.panel.transform.GetChild(i).gameObject.SetActive(true);
        }
        playController4_scriptsReload.StartingGame();

    }

    private void Start()
    {
        mediaPlayer_scriptReload = FindObjectOfType<mediaPlayer>();
    }
}
