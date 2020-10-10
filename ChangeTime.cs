using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeTime : MonoBehaviour
{
    public MyTimeValue myTimeValue_scriptChangeTime;
    public void EditTime(int i) 
    {


        myTimeValue_scriptChangeTime.timeValue.text = (myTimeValue_scriptChangeTime.TValue(i)).ToString();
    }
}
