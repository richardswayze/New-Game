using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public ItemPickUpDefinition pickUpDefinition;

    private void Awake()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh = pickUpDefinition.ItemMesh;

        SphereCollider collider = GetComponent<SphereCollider>();
        collider.radius = pickUpDefinition.PickUpRange;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerInventory.instance.StoreItem(pickUpDefinition.ItemToPickUp, 1);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Trigger " + collider.name);
        if (collider.gameObject.CompareTag("Player"))
        {
            PlayerInventory.instance.StoreItem(pickUpDefinition.ItemToPickUp, 1);
            Destroy(this.gameObject);
        }
    }
}
