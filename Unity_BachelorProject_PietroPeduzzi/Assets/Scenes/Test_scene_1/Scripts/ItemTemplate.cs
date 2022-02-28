using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName = "Pickup Item")]
public class ItemTemplate : ScriptableObject
{
    public string itemName;
    public Mesh itemMesh;
    public Mesh itemMeshCollider;
    public Material itemMaterial;

    public string itemDescription;
}
