using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestItem : Item
{
    //Item's specific behavior for Use
    public override void Use()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (Physics.Raycast(ray, out RaycastHit hit, Player.instance.placementDistance))
        {
            Instantiate(itemDefinition.PrefabInstance, hit.point + new Vector3(0f, itemDefinition.PrefabInstance.transform.localScale.y / 2f, 0f), Quaternion.identity);
        }
    }
}
