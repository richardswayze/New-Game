using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player> {

    public int placementDistance;
    public Item[] testItem;
    public bool isBuilding = false;
    public bool snapping = true;

    private void Update()
    {
        GetInputs();
    }

    private void GetInputs()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlayerInventory.instance.UseItem();            
        }

        if (Input.GetMouseButtonDown(1))
        {
            foreach (Item item in testItem)
            {
                PlayerInventory.instance.StoreItem(item, 10);
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            snapping = !snapping;
            Debug.Log("Snap  mode: " + (snapping == true ? "On" : "Off"));
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            PlayerInventory.instance.ChangeActiveItem(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayerInventory.instance.ChangeActiveItem(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlayerInventory.instance.ChangeActiveItem(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            PlayerInventory.instance.ChangeActiveItem(3);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            PlayerInventory.instance.ChangeActiveItem(4);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            PlayerInventory.instance.ChangeActiveItem(5);
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            PlayerInventory.instance.ChangeActiveItem(6);
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            PlayerInventory.instance.ChangeActiveItem(7);
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            PlayerInventory.instance.ChangeActiveItem(8);
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            PlayerInventory.instance.ChangeActiveItem(9);
        }
    }
    
    //TODO: Find a way to simplify the hotkey selection input
    //TODO: Implement mouse scroll to swap between hotkeys
    //TODO: Create inventory UI, hotkey UI
    //TODO: Implement item pick-ups
    //TODO: Create more items
}
