using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour {

    [SerializeField] GameObject branch;
    [SerializeField] float growthScaleXZ;
    [SerializeField] float growthScaleY;

    GameObject childBranch;

    const float PHI = 1.618f;

    private void Start()
    {
        GameObject newBranch = Instantiate(branch, transform.position, Quaternion.identity);
        newBranch.transform.parent = transform;
        childBranch = newBranch;
    }

    private void Update()
    {
        childBranch.transform.Translate(0f, growthScaleY * Time.deltaTime, 0f);
        childBranch.transform.localScale += new Vector3(growthScaleXZ, growthScaleY, growthScaleXZ) * Time.deltaTime;
    }

    //Create IEnumerator to control growth speed and end growth. Create random rotation vector on Instantiation.
}
