using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Mercy : MonoBehaviour
{
    public bool mercyTemp;
    public MyStaticData myStaticData_scriptMercy;
    public Toggle myMercyT;

    public void MyMercyOn() 
    {
        myStaticData_scriptMercy.MyMercyGet(myMercyT.isOn);
    
    }
    private void Start()
    {
        mercyTemp = myStaticData_scriptMercy.MyMercySet();
    }

}
