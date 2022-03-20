using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDisplay : MonoBehaviour
{
    public ItemTemplate item;

    private MeshFilter thisItemMesh;
    private MeshCollider thisItemCollider;
    private Renderer thisItemMaterial;
    public float itemDurabilityRemaining;

    private void Start()
    {
        thisItemMesh = gameObject.GetComponent<MeshFilter>();
        thisItemMesh.mesh = item.itemMesh;

        thisItemCollider = gameObject.GetComponent<MeshCollider>();
        thisItemCollider.sharedMesh = item.itemMeshCollider;

        thisItemMaterial = gameObject.GetComponent<Renderer>();
        thisItemMaterial.material = item.itemMaterial;

        itemDurabilityRemaining = item.itemDurability;
    }

    public void ResetItem()
    {
        thisItemMesh = gameObject.GetComponent<MeshFilter>();
        thisItemMesh.mesh = item.itemMesh;

        thisItemCollider = gameObject.GetComponent<MeshCollider>();
        thisItemCollider.sharedMesh = item.itemMeshCollider;

        thisItemMaterial = gameObject.GetComponent<Renderer>();
        thisItemMaterial.material = item.itemMaterial;

        itemDurabilityRemaining = item.itemDurability;
    }
}
