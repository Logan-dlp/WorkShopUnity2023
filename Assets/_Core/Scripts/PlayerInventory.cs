using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NavigationController))]
public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private GameObject _canvasInventory;
    [SerializeField] private GameObject[] _parentItemDisplay = new GameObject[8];
    private int _maxObjectInList;
    private NavigationController _navigationController;
    private List<GameObject> _inventoryList = new List<GameObject>();
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

    private void DisplayItem(GameObject item)
    {
        GameObject newItem = item;
        newItem.AddComponent<CanvasRenderer>();
        RectTransform newItemRectTransform = newItem.AddComponent<RectTransform>();
        newItemRectTransform.localScale = new Vector3(200, 200, 200);
        newItemRectTransform.rotation = Quaternion.Euler(0, 0, 0);
        
        _inventoryList.Add(newItem);
        Instantiate(newItem, _parentItemDisplay[_inventoryList.IndexOf(newItem)].transform);
    }
    
    public bool AddObjectInIventory(GameObject newItem)
    {
        if (_inventoryList.Count < _maxObjectInList)
        {
            DisplayItem(newItem);
            return true;
        }

        return false;
    }
}