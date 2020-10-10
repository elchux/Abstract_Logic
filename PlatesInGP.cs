using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatesInGP : MonoBehaviour
{
    public Text  v1, plate2, v2;
    public int w1, w2;

    void Start()
    {
        v1.text = "0";
        v2.text = "0";
        if (MyStaticData.nPlayers == 0)
        { plate2.transform.parent.gameObject.SetActive(false); }
        else { plate2.transform.parent.gameObject.SetActive(true); }
        if (MyStaticData.nPlayers == 1)
        { plate2.text = "CPU"; }
        if (MyStaticData.nPlayers == 2)
        { plate2.text = "P2";}
        
    }

    public void RefreshWins(Text v) 
    {v.text = ((int.Parse(v.text)) + 1).ToString();
    }


}
