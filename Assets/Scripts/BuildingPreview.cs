using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPreview : MonoBehaviour
{
    [SerializeField] Material buildableMat;
    [SerializeField] Material notBuildableMat;

    public GameObject prefabToBuild;

    bool buildable = true;
    MeshRenderer meshRend;

    private void Awake()
    {
        meshRend = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        meshRend.material = buildable ? buildableMat : notBuildableMat;

        PerformRayCast();
    }

    private void OnTriggerEnter(Collider other)
    {
        buildable = false;
        Debug.Log(other.name);
    }

    private void OnTriggerExit(Collider other)
    {
        buildable = true;
    }

    private void PerformRayCast()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (Physics.Raycast(ray, out RaycastHit hit, Player.instance.placementDistance))
        {
            transform.position = hit.point + new Vector3(0f, transform.localScale.y / 2f, 0f);
        }
    }
}
