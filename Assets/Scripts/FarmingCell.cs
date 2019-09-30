using UnityEngine;

public class FarmingCell : MonoBehaviour {

    public enum states {empty, hoed, occupied};
    public bool watered;

    FarmManager farmManager;
    states currentState;

    private void Awake()
    {
        currentState = states.empty;
        watered = false;
        transform.parent = FarmManager.farmManager.transform;
        farmManager.farmCells.Add(this);
    }
}
