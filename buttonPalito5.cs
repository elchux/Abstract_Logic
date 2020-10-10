using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class buttonPalito5 : MonoBehaviour
{
    public int palitoRemove5, xArray5 = 0, yArray5 = 0, filasTemp5 = 1, columnasTemp5 = 1, iterator5 = 0, aux5;
    playController5 playController_script5;
    // PointerEventData eventData;
    public void PalitoOut5()
    {
        if (Input.touchCount == 1 || Input.GetMouseButton(0) == true)
        {
            //(sonido de exito)                                                                                                                                             restantes                         restantes         
            this.gameObject.SetActive(false);                                              //(0314)              fila              colum                  fila                               columna
            palitoRemove5 = int.Parse(this.gameObject.transform.name);   //(primero)            0                  3                        1                                     4
            columnasTemp5 = palitoRemove5 % 10;
            palitoRemove5 /= 10;
            filasTemp5 = palitoRemove5 % 10;
            palitoRemove5 /= 10;
            yArray5 = palitoRemove5 % 10;
            xArray5 = palitoRemove5 / 10;
            playController_script5.palitosArray5[xArray5, yArray5] = 0;
            playController_script5.filasVar5[xArray5] -= 1;
            playController_script5.columnasVar5[yArray5] -= 1;
            playController_script5.palitosArrayF5[xArray5, yArray5] = new Vector2(0, filasTemp5 - 1);
            playController_script5.palitosArrayF_C5[xArray5, yArray5] = new Vector3(0, (filasTemp5 - 1), (columnasTemp5 - 1));
            RefreshArrayV2V3(xArray5, yArray5);
        }
    }//1233

    public void RefreshArrayV2V3(int x5, int y5)
    {
        for (int i5 = 0; i5 < 9; i5++)
        {
            if (i5 != y5 && playController_script5.palitosArrayF5[x5, i5].x != -1)
            {
                playController_script5.palitosArrayF5[x5, i5].y -= 1;
                playController_script5.palitosArrayF_C5[x5, i5].y -= 1;
            }
        }
        for (int i5 = 1; i5 < 4; i5++)
        {
            if (i5 != x5 && playController_script5.palitosArrayF_C5[i5, y5].x != -1)
            {
                playController_script5.palitosArrayF_C5[i5, y5].z -= 1;
            }
        }
    }


    /*public int[] filasVar = new int[4] { 1, 3, 5, 7,9 }*/
    void Start()
    {
        playController_script5 = FindObjectOfType<playController5>();
    }
    void Update()
    {


    }
}
