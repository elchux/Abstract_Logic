using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseBeetwenTurns : MonoBehaviour
{
    public Toggle pBtCheckBox;
    bool pauseBtActive;
    MyStaticData myStaticData_scriptPBTW;
  
    public void CheckPauseBTW() 
    {
        if (pBtCheckBox.isOn == false)
            pauseBtActive = false;
        else pauseBtActive = true;
        myStaticData_scriptPBTW.PauseBTWGet(pauseBtActive);
    }
    void Start()
    {
        myStaticData_scriptPBTW = FindObjectOfType<MyStaticData>();
        pauseBtActive = myStaticData_scriptPBTW.PauseBTWSet();
        
    }

}
