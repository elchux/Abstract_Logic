using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playController5 : MonoBehaviour
{
    public int[,] palitosArray5 = new int[5, 9] { {-1, -1, -1, -1, 1, -1, -1, -1, -1 }, { -1, -1, -1, 1, 1, 1, -1, -1, -1 }, { -1, -1, 1, 1, 1, 1, 1, -1, -1 }, { -1, 1, 1, 1, 1, 1, 1, 1, -1 }, { 1, 1, 1, 1, 1, 1, 1, 1, 1 } };
    public Vector2[,] palitosArrayF5 = new Vector2[5, 9];
    public Vector3[,] palitosArrayF_C5 = new Vector3[5, 9];
    public int[] filasVar5 = new int[5] { 1, 3, 5, 7,9 };
    public int[] columnasVar5 = new int[9] { 1, 2, 3, 4, 5,4, 3, 2, 1 };
    public int palitoRemove5, xArray5 = 0, yArray5 = 0, filasTemp5 = 1, columnasTemp5 = 1;
    public AudioClip[] sounds5 = new AudioClip[12];
    public Image fadeO5;
    /*audioClip[]:
     * [0] back
     * [1] back2
     * [2] bip+
     * [3] bip+2
     * [4] coindrop
     * [5] coindrop2
     * [6] coindrop3
     * [7] coindrop4
     * [8] coindrop_loading
     * [9] exit
     * [10] restart_mechanic
     * [11] select
         */

    //AI? BACKTRAKING??? TURNOS??? MANEJO DE ESCENAS???

    public void fillArray2_3()
    {
        for (xArray5 = 0; xArray5 < 5; xArray5++)
        {
            for (yArray5 = 0; yArray5 < 9; yArray5++)
            {
                if (palitosArray5[xArray5, yArray5] == -1)
                {
                    palitosArrayF5[xArray5, yArray5] = new Vector2(-1, -1);
                    palitosArrayF_C5[xArray5, yArray5] = new Vector3(-1, -1, -1);
                }
                else
                {                           //2              1                                       
                    palitosArrayF5[xArray5, yArray5] = new Vector2(1, filasVar5[xArray5]);
                    palitosArrayF_C5[xArray5, yArray5] = new Vector3(1, filasVar5[xArray5], (columnasVar5[yArray5]));
                }
            }
        }
    }
    //1334      2152        3172
    void Start()
    {
        fadeO5.gameObject.SetActive(true);
        fillArray2_3();
     /*   Debug.Log("vacio" + palitosArrayF_C5[0, 1] + " deberia dar (-1,-1,-1)");
        Debug.Log("segundo de la segunda fila" + palitosArrayF_C5[1, 4] + " deberia dar (1,3,5)");
        Debug.Log("primero de la tercera fila" + palitosArrayF_C5[2, 2] + " deberia dar (1,5,3)");
        Debug.Log("segundo de la cuarta fila" + palitosArrayF_C5[3, 2] + " deberia dar (1,7,3)");
        Debug.Log("cuarto de la quinta fila" + palitosArrayF_C5[4, 3] + " deberia dar (1,9,4)");
        Debug.Log("vacio" + palitosArrayF_C5[2, 6] + " deberia dar (-1,-1,-1)");
        */
    }
    void Update()
    {

    }
}
