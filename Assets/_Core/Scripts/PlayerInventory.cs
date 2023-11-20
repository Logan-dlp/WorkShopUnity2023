using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NavigationController))]
public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private GameObject _canvasInventory;
    [SerializeField] private int _maxObjectInList = 10;
    private NavigationController _navigationController;
    private List<GameObject> _inventoryList = new List<GameObject>();
    private bool _isDisplay = false;

    private void Start()
    {
        _navigationController = GetComponent<NavigationController>();
        _canvasInventory.SetActive(_isDisplay);
    }

    private void Update()
    {
        DisplayInventory();
    }

    private void DisplayInventory()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _navigationController.enabled = _isDisplay;
            _isDisplay = !_isDisplay;
            _canvasInventory.SetActive(_isDisplay);
        }
    }
    
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
