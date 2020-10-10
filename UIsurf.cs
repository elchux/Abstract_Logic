using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIsurf : MonoBehaviour
{
    
    public GameObject[] interfaces;
    //0MM/1GM/2START/3GS/4AS
    public Image  tutorial1, tutorial2, tutorial3;
    public Button goBack;
    MyStaticData myStaticData_scriptUI;
    public mediaPlayer mediaPlayer_scriptFXs;
    
    public void GoBack()
    {
        mediaPlayer_scriptFXs.MyAudioS1(3);
        if (interfaces[1].activeSelf == true)
        {
            interfaces[0].SetActive(true);
            interfaces[1].SetActive(false);
            goBack.gameObject.SetActive(false);
        }
        else if (interfaces[2].activeSelf ==true)
        {
            interfaces[1].SetActive(true);
            interfaces[2].SetActive(false);
            interfaces[3].SetActive(false);
        }
        else if (interfaces[4].activeSelf || interfaces[3].activeSelf == true)
        {
            myStaticData_scriptUI.AdjustSelectedAudio();
            interfaces[4].SetActive(false);
            interfaces[3].SetActive(false);
            interfaces[0].SetActive(true);
            goBack.gameObject.SetActive(false);
        }
    }
    //UI 1
    public void NewGame() {
        goBack.gameObject.SetActive(true);
        interfaces[1].SetActive(true);
        interfaces[0].SetActive(false);
        mediaPlayer_scriptFXs.MyAudioS1(9);
    }

    //1.2UI

    public void AudioSettings()
    {
        mediaPlayer_scriptFXs.MyAudioS1(9);
        goBack.gameObject.SetActive(true);
        interfaces[0].SetActive(false);
        interfaces[4].SetActive(true);

    }

     public void HowToPlay()
    {
        mediaPlayer_scriptFXs.MyAudioS1(9);
        tutorial3.gameObject.SetActive(true);
        tutorial2.gameObject.SetActive(true);
        tutorial1.gameObject.SetActive(true);
    }

    public void RowsNColumns()
    {
        mediaPlayer_scriptFXs.MyAudioS1(9);
        tutorial3.gameObject.SetActive(true);
        tutorial2.gameObject.SetActive(true);
        tutorial1.gameObject.SetActive(true);
    }
    public void MoreTips()
    {
        mediaPlayer_scriptFXs.MyAudioS1(9);
        tutorial3.gameObject.SetActive(true);
        tutorial2.gameObject.SetActive(true);
        tutorial1.gameObject.SetActive(true);
    }
    public void NextTutorial()
    { this.gameObject.SetActive(false);
        mediaPlayer_scriptFXs.MyAudioS1(18);
    }

    //UI 1.1
    public void Tplayer() 
    {
        mediaPlayer_scriptFXs.MyAudioS1(9);
        myStaticData_scriptUI.TPlayer(0);
    
    }
    public void SinglePlayer()
    {
        mediaPlayer_scriptFXs.MyAudioS1(9);
        myStaticData_scriptUI.SPlayer(1);
        interfaces[2].SetActive(true);
        interfaces[1].SetActive(false);
    }
    public void MultiPlayer()
    {
        mediaPlayer_scriptFXs.MyAudioS1(9);
        myStaticData_scriptUI.MPlayer(2);
        interfaces[2].SetActive(true);
        interfaces[1].SetActive(false);
    }
    public void GameSettings()
    {
       
        mediaPlayer_scriptFXs.MyAudioS1(9);
        goBack.gameObject.SetActive(true);
        interfaces[3].SetActive(true);
        interfaces[0].SetActive(false);
    }

    //PENDIENTE(mercy)
                         
                        

    void Start()
    {
        myStaticData_scriptUI = FindObjectOfType<MyStaticData>();
        mediaPlayer_scriptFXs = FindObjectOfType<mediaPlayer>();
    }

    void Update()
    {
        
    }
}
