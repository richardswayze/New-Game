using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { Building, Tool, MiscPlaceable };

[CreateAssetMenu(fileName="New Item", menuName="Create New Item")]
public class ItemDefinition : ScriptableObject
{
    public string ItemName = "New Item";

    //Categorization for item
    public ItemType itemType;

    //Can item be stacked in inventory or only one amount per inventory slot
    public bool Stackable;

    //Consume one count of the item in inventory on use
    public bool ConsumeOnUse;

    //Removes item from inventory on use
    public bool DestroyOnUse;

    //Can item be crafted
    public bool Craftable;

    //Prefab represented by this ItemDefinition
    public GameObject PrefabInstance;
}
