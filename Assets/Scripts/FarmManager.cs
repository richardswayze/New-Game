using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmManager : MonoBehaviour {

    public static FarmManager farmManager;
    public List<FarmingCell> farmCells;

    private void Awake()
    {
        if (farmManager == null)
        {
            farmManager = this;
        } else
        {
            Destroy(this.gameObject);
        }
    }
}
