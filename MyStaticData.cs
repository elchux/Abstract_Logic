using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MyStaticData : MonoBehaviour
{
    public static int nTime=4, nPlayers, nDificulty=0, selectorEscena, nRows=4, nColumns;//STATIC
    public static bool rNColumns, pauseTurns,  inGame, mercy;//STATIC
    public static float  vMusic = 1, vFX=1;//STATIC
    public Image fadeO;
    public Slider musicVSlider, fxVSlider ;

    //scripts de los valores de la UI
    public fade fade_scriptMyStaticData;
    public MyTimeValue myTimeValue_script_MyStaticData;
    public mediaPlayer mediaPlayer_scriptVolume;
    public ChangeTime changeTime_scriptMyStaticData;
    //CONSTRUCTOR ESCENA
    public void SceneSelector() 
    {
        mediaPlayer_scriptVolume.MyAudioS1(25);
        if (inGame == false)
        {   if ( nPlayers<= 1)
                { if (nRows == 4)
                    {selectorEscena = 1;
                    }
                    else 
                    {selectorEscena = 3;
                    }     
            
                }else
                {   if (nRows == 4)
                     {selectorEscena = 2;
                     }
                     else
                     {selectorEscena = 4; 
                     }
                }   
        }
        
        
        else {selectorEscena = 0;
                  }         
        fade_scriptMyStaticData.FadeToBlack(selectorEscena);
    }
//    timeScene.text = (Mathf.RoundToInt(MyStaticData.nTime - Time.fixedTime)).ToString();

    public void SPlayer(int x)
    { nPlayers = x; }
    public void MPlayer(int x)
    { nPlayers = x; }
    public void TPlayer(int x) 
    { nPlayers = x;
        nTime = 0;
        //changeTime_scriptMyStaticData.EditTime(-(nTime));
        fade_scriptMyStaticData.FadeToBlack(1);
}

    //FIN CONSTRUCTOR ESCENA

    //MUSICA (invocada al cambiar de escena)

 


    public void VMusicVolume()
    {   vMusic= musicVSlider.value;
        mediaPlayer_scriptVolume.myAudioS[0].volume = vMusic;
    }
    public void VFXVolume()
    {
        mediaPlayer_scriptVolume.MyAudioS1(19);
        vFX = fxVSlider.value;
        mediaPlayer_scriptVolume.myAudioS[1].volume = vFX;
        mediaPlayer_scriptVolume.myAudioS[2].volume = vFX;

    }
    public void AdjustSelectedAudio()
    {  musicVSlider.value = vMusic;
        fxVSlider.value = vFX;
    }
    //FIN MUSICA

    //TIME
  
    public int TimeSet()
    {
        return nTime;
    }
  public void TimeGet(int x) {
        mediaPlayer_scriptVolume.MyAudioS1(17);
        nTime = x;
        } 
    //FIN TIME

    //DIF
    public int DiffSet()
    {   return nDificulty;         }
  public void DiffGet(int x )
    {
        mediaPlayer_scriptVolume.MyAudioS1(20);
        nDificulty = x;         }
    //END DIF


    //ROWS
    public string RowSet() 
    {   return nRows.ToString();   }

    public void RowGet(int x)
    {
        mediaPlayer_scriptVolume.MyAudioS1(16);
        nRows = x;
        if (x == 4) { nColumns = 7; }
        else if (x == 5) { nColumns = 9; }
    }
  

    //FIN ROWS

    //PAUSE BTW TURNS       

    public bool PauseBTWSet()
    { return pauseTurns; }
    public void PauseBTWGet(bool x)
    {
        mediaPlayer_scriptVolume.MyAudioS1(8);
        pauseTurns = x;        }

    //FIN PAUSE BTW TURNS


    public bool RNCSet()
    {   return rNColumns; }
    public void RNCGet(bool x)
    {
        mediaPlayer_scriptVolume.MyAudioS1(14);
        rNColumns = x; }

    public bool MyMercySet ()
    {   return mercy ;
    }
    public void MyMercyGet(bool x)
    {
        mediaPlayer_scriptVolume.MyAudioS1(23);
        mercy = x; }

    private void Awake()
    {
      //   DontDestroyOnLoad(this.gameObject);
    }

    public void Quitting() {
        Application.Quit();
        //EditorApplication.Exit (0);
        
    }
    void Start()
    {
        AdjustSelectedAudio();
        mediaPlayer_scriptVolume= FindObjectOfType<mediaPlayer>();
        fadeO.gameObject.SetActive(true);

    }

    void Update()
    {
    }
}
