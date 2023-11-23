using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NavigationController))]
public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private GameObject _canvasInventory;
    [SerializeField] private GameObject[] _parentItemDisplay = new GameObject[8];
    // public ? => get , set for upgradable item or initialise methode for change item
    private List<GameObject> _inventoryList = new List<GameObject>();
    private NavigationController _navigationController;
    private int _maxObjectInList;
    private bool _isDisplay = false;

    private void Start()
    {
        _maxObjectInList = _parentItemDisplay.Length;
        _navigationController = GetComponent<NavigationController>();
        _canvasInventory.SetActive(_isDisplay);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DisplayInventory();
        }
    }

    public void DisplayInventory()
    {
        _navigationController.enabled = _isDisplay;
        _isDisplay = !_isDisplay;
        _canvasInventory.SetActive(_isDisplay);
    }

    private void DisplayItem(GameObject item, ItemType itemType)
    {
        GameObject newItem = Instantiate(item);
        _inventoryList.Add(newItem);
        newItem.transform.SetParent(_parentItemDisplay[_inventoryList.IndexOf(newItem)].transform);
        newItem.transform.localPosition = Vector3.zero;
        newItem.transform.localScale = new Vector3(.7f, .7f, .7f);
        newItem.GetComponent<UpgradableItem>().ItemType = itemType;
    }
    
    public bool AddObjectInIventory(GameObject newItem, ItemType itemType)
    {
        if (_inventoryList.Count < _maxObjectInList)
        {
            DisplayItem(newItem, itemType);
            return true;
        }

        return false;
    }
}