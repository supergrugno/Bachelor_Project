using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName = "Pickup Item")]
public class ItemTemplate : ScriptableObject
{
    public GameObject crafterPrefab;

    public string itemName;
    public float itemDurability;
    public Mesh itemMesh;
    public Mesh itemMeshCollider;
    public Material itemMaterial;

    public string itemDescription;
    public Sprite itemIcon;

    public bool isEdible;
}
