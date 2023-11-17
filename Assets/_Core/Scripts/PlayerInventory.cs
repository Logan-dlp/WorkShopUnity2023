using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private int _maxObjectInList = 10;
    private List<GameObject> _inventoryList = new List<GameObject>();
    
    public bool AddObjectInIventory(GameObject gameObject)
    {
        if (_inventoryList.Count < _maxObjectInList)
        {
            _inventoryList.Add(gameObject);
            return true;
        }

        return false;
    }
}
