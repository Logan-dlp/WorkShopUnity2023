using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NavigationController))]
public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private GameObject _canvasInventory;
    [SerializeField] private GameObject[] _parentItemDisplay = new GameObject[8];
    
    [HideInInspector] public List<GameObject> InventoryList { get => _inventoryList; set => _inventoryList = value; }
    private List<GameObject> _inventoryList = new List<GameObject>();
    
    private NavigationController _navigationController;
    private GameObject _parentItem;
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
            _navigationController.enabled = _isDisplay;
            _isDisplay = !_isDisplay;
            _canvasInventory.SetActive(_isDisplay);
        }
    }

    private void DisplayItem(GameObject item, ItemType itemType)
    {
        GameObject newItem = Instantiate(item);
        InventoryList.Add(newItem);
        foreach (GameObject parentObject in _parentItemDisplay)
        {
            if (parentObject.transform.childCount < 1)
            {
                _parentItem = parentObject;
                break;
            }
        }
        newItem.transform.SetParent(_parentItem.transform);
        newItem.transform.localPosition = Vector3.zero;
        newItem.transform.localScale = new Vector3(.7f, .7f, .7f);
        newItem.GetComponent<UpgradableItem>().ItemType = itemType;
    }
    
    public bool AddObjectInIventory(GameObject newItem, ItemType itemType)
    {
        if (InventoryList.Count < _maxObjectInList)
        {
            DisplayItem(newItem, itemType);
            return true;
        }

        return false;
    }
}