using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPreview : MonoBehaviour
{
    [SerializeField] Material buildableMat;
    [SerializeField] Material notBuildableMat;
    [SerializeField] float collisionTolerance = .02f;
    [SerializeField] float collisionCushion = .002f;

    public GameObject prefabToBuild;
    public bool buildable = true;

    MeshRenderer meshRend;
    List<Collider> colliders = new List<Collider>();

    private void Awake()
    {
        meshRend = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        buildable = colliders.Count <= 0;
        meshRend.material = buildable ? buildableMat : notBuildableMat;

        PerformRayCast();

    }

    private void OnTriggerEnter(Collider other)
    {
        colliders.Add(other);
    }

    private void OnTriggerExit(Collider other)
    {
        colliders.Remove(other);
    }

    private void PerformRayCast()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (Physics.Raycast(ray, out RaycastHit hit, Player.instance.placementDistance))
        {
                transform.position = hit.point + new Vector3(0f, transform.localScale.y * .5f + collisionCushion, 0f);
        }
    }
}
