using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDifficulty : MonoBehaviour
{
    public SelectionDif selectionDif_scriptChangeDifficulty;
    public void EditDiff(int aux) 
    {
        selectionDif_scriptChangeDifficulty.DiffValue(aux);
    }
}
