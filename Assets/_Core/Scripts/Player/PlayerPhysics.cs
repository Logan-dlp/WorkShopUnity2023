using System;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody), typeof(PlayerInventory))]
public class PlayerPhysics : MonoBehaviour
{
    private Rigidbody _rb;
    private PlayerInventory _inventory;

    private void Start()
    {
        _inventory = GetComponent<PlayerInventory>();
        _rb = GetComponent<Rigidbody>();
        _rb.useGravity = false;
        _rb.freezeRotation = true;
    }

    private void OnTriggerEnter(Collider collision)
    {
        ItemRenderer collisionItemRenderer = collision.GetComponentInParent<ItemRenderer>();
        if (_inventory.AddObjectInIventory(collisionItemRenderer.gameObject))
        {
            Destroy(collisionItemRenderer.gameObject);
        }
    }
}