using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public class MyTimeValue : MonoBehaviour
{
    public Text timeValue;
    MyStaticData myStaticData_scriptMyTimeValue;
    public Image infinitum;
    
    public int TValue(int t)
    {
        if (int.Parse(timeValue.text) == 0)
        {
            timeValue.enabled = true;
            infinitum.gameObject.SetActive(false);
            if (t > 0)
            {
                myStaticData_scriptMyTimeValue.TimeGet(2);
                return 2;
            }
                else 
                myStaticData_scriptMyTimeValue.TimeGet(10); 
                return 10;
        }
        else if ((int.Parse(timeValue.text) + (t)) == 1 || (int.Parse(timeValue.text) + (t)) == 11)
        {
            timeValue.enabled = false;
            infinitum.gameObject.SetActive(true);
            myStaticData_scriptMyTimeValue.TimeGet(0);
            return (0);
        }
        else 
            myStaticData_scriptMyTimeValue.TimeGet((int.Parse(timeValue.text) + (t)));
            return (int.Parse(timeValue.text) + (t));
    }
    void Start()
    {
        myStaticData_scriptMyTimeValue=FindObjectOfType<MyStaticData>();
        timeValue.text = (myStaticData_scriptMyTimeValue.TimeSet()).ToString();

    }


}
