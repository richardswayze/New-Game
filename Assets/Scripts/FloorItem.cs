using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorItem : Item
{
    GameObject prefab = null;
    GameObject previewObject = null;

    public override void Use()
    {
        if (!Player.instance.isBuilding)
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(ray, out RaycastHit hit, Player.instance.placementDistance))
            {
                previewObject = Instantiate(itemDefinition.PrefabInstance, hit.point + new Vector3(0f, itemDefinition.PrefabInstance.transform.localScale.y / 2f, 0f), Quaternion.identity);
                prefab = previewObject.GetComponent<BuildingPreview>().prefabToBuild;
                Player.instance.isBuilding = true;
            }
        }
        else if (Player.instance.isBuilding && previewObject.GetComponent<BuildingPreview>().buildable)
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(ray, out RaycastHit hit, Player.instance.placementDistance))
            {
                Instantiate(prefab, previewObject.transform.position, Quaternion.identity);
                Destroy(previewObject);
                PlayerInventory.instance.DecrementItem(PlayerInventory.instance.activeItem, 1);
                previewObject = null;
                prefab = null;
                Player.instance.isBuilding = false;
            }
        }
    }
}
