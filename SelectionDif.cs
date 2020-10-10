using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionDif : MonoBehaviour
{
    public int contadorDif;
    public bool aumento, disminuyo;
    string[] dificultad = new string[3] { "Easy", "Medium", "Hardcore" };
    public Text  difficulty;
    MyStaticData myStaticData_scriptSelectionDif;


    public void DiffValue(int d) 
    {
        difficulty.text = dificultad[contadorDif];
        if ((contadorDif + (d) >= 0) && (contadorDif + (d) <= 2))
        {
            contadorDif += (d);
            myStaticData_scriptSelectionDif.DiffGet(contadorDif);
            difficulty.text = (dificultad[contadorDif]).ToString();
        }
        else {
        //sonido de error
        }
    }
    
 
    void Start()
    {
        myStaticData_scriptSelectionDif=FindObjectOfType<MyStaticData>();
        contadorDif = myStaticData_scriptSelectionDif.DiffSet();    
        difficulty.text = dificultad[contadorDif];

    }



}
