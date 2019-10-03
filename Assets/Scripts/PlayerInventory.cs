using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerInventory : Singleton<PlayerInventory>
{
    public List<InventoryEntry> inventory = new List<InventoryEntry>();
    public InventoryEntry activeItem;
    public int maxSpace = 20;
    public Dictionary<int, InventoryEntry> hotkeyItems = new Dictionary<int, InventoryEntry>();

    public int activeHotKey { get; private set; }

    private void Start()
    {
        for (int i = 0; i <= 9; i++)
        {
            hotkeyItems[i] = null;
        }
        activeHotKey = 1;

    }

    //Call the active item's Use script
    public void UseItem()
    {
        if (activeItem._amount <= 0)
        {
            Debug.Log("No items to use");
            return;
        }

        //Filter out non-Tool items and check if amount is > 0
        //Remove item if amount is < 0 after use
        if (activeItem._item.itemDefinition.itemType == ItemType.Building)
        {
            if (Player.instance.isBuilding)
            {
                activeItem._item.Use();
                if (activeItem._amount <= 0)
                {
                    inventory.Remove(activeItem);
                    hotkeyItems[activeHotKey] = null;
                    activeItem = null;
                    //TODO: Decide if new active item is assigned when current active item is used up and removed
                }
            }
            else
            {
                activeItem._item.Use();
            }
        }
    }

    //Store an item in inventory with the specified amount
    //If the item is already in inventory, current amount increases
    //If the item is not in inventory, item is added in specified amount
    public void StoreItem(Item itemToStore, int amountToStore)
    {
        InventoryEntry entry = new InventoryEntry(itemToStore, amountToStore);

        if (inventory.Count >= maxSpace)
        {
            Debug.Log("Maximum inventory space reached.");
            return;
        }

        //Checks if inventory already contains the item to store
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i]._item == itemToStore)
            {
                inventory[i]._amount += amountToStore;
                return;
            }
        }
        
        
        //Adds item to new inventory slot and searches for empty hotkey slot
        //Sets item to active if that hotkey slot is currently active
        inventory.Add(entry);

        for (int j = 0; j <= 9; j++)
        {
            if (hotkeyItems[j] == null)
            {
                hotkeyItems[j] = inventory.Last<InventoryEntry>();
                if (activeHotKey == j)
                {
                    activeItem = hotkeyItems[j];
                }
                return;
            }
        }
    }

    public void DecrementItem(InventoryEntry inventoryEntry, int amountToDecrement)
    {
        if (inventoryEntry._item.itemDefinition.ConsumeOnUse)
        {
            inventoryEntry._amount -= amountToDecrement;
        }
        else if (inventoryEntry._item.itemDefinition.DestroyOnUse)
        {
            inventoryEntry._amount = 0;
        }
    }

    public void ChangeActiveItem (int hotkey)
    {
        if (hotkeyItems[hotkey] == null)
        {
            activeItem = null;
        }
        activeItem = hotkeyItems[hotkey];
        activeHotKey = hotkey;
    }
}

[System.Serializable]
public class InventoryEntry
{
    public Item _item;
    public int _amount;

    public InventoryEntry(Item item, int amount)
    {
        _item = item;
        _amount = amount;
    }
}
