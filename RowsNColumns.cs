using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RowsNColumns : MonoBehaviour
{
    public Toggle rNCCheckBox;
    bool pauseBtActive;
    MyStaticData myStaticData_scriptRowsNColumns;

    public void CheckRNC()
    {
        if (rNCCheckBox.isOn == false)
        { pauseBtActive = false; }
        else {pauseBtActive = true; }
        myStaticData_scriptRowsNColumns.RNCGet(pauseBtActive);
    }
    void Start()
    {
        myStaticData_scriptRowsNColumns =  FindObjectOfType<MyStaticData>();
        pauseBtActive = myStaticData_scriptRowsNColumns.RNCSet();

    }

}