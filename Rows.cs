using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rows : MonoBehaviour
{
    public MyStaticData myStaticData_scriptRows;
    public Text rowsValue;

    public void EditRows(bool aux) 
    {
        if (aux==true)
        {

            rowsValue.text = "5";
            myStaticData_scriptRows.RowGet(5);
        }
        if (aux==false)
        {
            rowsValue.text = "4";
            myStaticData_scriptRows.RowGet(4);
        }
    }
    void Start()
    {
        rowsValue.text = myStaticData_scriptRows.RowSet();

    }
}
