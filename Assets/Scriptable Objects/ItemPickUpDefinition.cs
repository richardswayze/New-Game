using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Pick Up", menuName ="Create New Pick Up")]
public class ItemPickUpDefinition : ScriptableObject
{
    public Item ItemToPickUp;
    public Mesh ItemMesh;
    public int DecayTime;
    public int PickUpRange;
}
