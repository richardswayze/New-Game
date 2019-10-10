using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPreview : MonoBehaviour
{
    enum PieceType { Floor, Wall};

    [SerializeField] Material buildableMat;
    [SerializeField] Material notBuildableMat;
    [SerializeField] float colliderReduction;

    public GameObject prefabToBuild;
    public bool buildable = true;

    MeshRenderer meshRend;
    List<Collider> colliders = new List<Collider>();

    //TODO: Refactor collider code to grab any shape collider
    BoxCollider box;

    private void Awake()
    {
        meshRend = GetComponent<MeshRenderer>();

        //Reduce size of collider to allow buildings to touch when building
        box = GetComponent<BoxCollider>();
        box.size *= colliderReduction;
    }

    private void Update()
    {
        //Sets the buildable bool based on if the colliders list has any items
        //Material then applied based on buildable bool
        buildable = colliders.Count <= 0;
        meshRend.material = buildable ? buildableMat : notBuildableMat;

        PerformRayCast();
    }

    //Adds objects to collider list as triggers occur
    private void OnTriggerEnter(Collider other)
    {
        colliders.Add(other);
    }

    //Removes objects from collider list as triggers end
    private void OnTriggerExit(Collider other)
    {
        colliders.Remove(other);
    }

    //Raycast from player to place preview objects
    private void PerformRayCast()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (Physics.Raycast(ray, out RaycastHit hit, Player.instance.placementDistance))
        {
            //Check with player if snap mode is on
            if (Player.instance.snapping)
            {
                Vector3 previewPosition = new Vector3(hit.point.x, hit.point.y + transform.localScale.y * 0.5f, hit.point.z);
                if (hit.collider.gameObject.layer != LayerMask.NameToLayer("World"))
                {
                    previewPosition.x = hit.collider.transform.position.x + (((hit.collider.transform.localScale.x / 2f) + (transform.localScale.x / 2f)) * hit.normal.x);
                    previewPosition.y = hit.collider.transform.position.y + (((hit.collider.transform.localScale.y / 2f) + (transform.localScale.y / 2f)) * hit.normal.y);
                    previewPosition.z = hit.collider.transform.position.z + (((hit.collider.transform.localScale.z / 2f) + (transform.localScale.z / 2f)) * hit.normal.z);
                }

                transform.position = previewPosition + offset;
            }
            else
            {
                //Position the preview object with an offset based on
                //difference between RaycastHit and the position of the hit object.
                //If the hit object is on the "World" layer, offset is not applied.
                Vector3 previewPosition = hit.point;

                if (hit.collider.gameObject.layer != LayerMask.NameToLayer("World"))
                {
                    Vector3 xzOffset = hit.point - hit.collider.transform.position;
                    previewPosition.x += xzOffset.x;
                    previewPosition.z += xzOffset.z;
                }
                transform.position = previewPosition;
            }              
        }
    }
}
