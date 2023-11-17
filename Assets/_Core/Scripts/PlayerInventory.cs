using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private int _maxObjectInArray = 10;
    private List<GameObject> _inventoryArray;

    public void AddObjectInIventory(GameObject gameObject)
    {
        if (_inventoryArray.Count + 1 < _maxObjectInArray)
        {
            _inventoryArray.Add(gameObject);
        }
    }
}
