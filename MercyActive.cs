using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MercyActive : MonoBehaviour
{
    bool mercyActivated;
    public playController4 playController4_script;
    public mediaPlayer mediaPlayer_scriptMercyActive;
    public void Mercyful()
    {

        if (playController4_script.nJugada > 1)
        {
            mediaPlayer_scriptMercyActive.MyAudioS2(6);
            for (int i = 0; i < playController4_script.panel.transform.childCount; i++)
            {
                if (playController4_script.Palitos[i] / 10000 == playController4_script.nJugada ||
                    playController4_script.Palitos[i] / 10000 == playController4_script.nJugada - 1)
                {
                    playController4_script.Palitos[i] = playController4_script.Palitos[i] % 10000;
                    playController4_script.panel.transform.GetChild(i).gameObject.SetActive(true);
                }
            }
            playController4_script.nJugada -= 2;
        }
    }
    void Start()
    {if (MyStaticData.mercy == false)
        {
            this.gameObject.SetActive(false);
            mediaPlayer_scriptMercyActive = FindObjectOfType<mediaPlayer>();
        }
    }

}
