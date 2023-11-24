using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UpgradableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Image _image;
    private Transform _initialParent;

    public ItemType ItemType;
    [SerializeField] private ItemTypeSource _itemTypeSource;
    private PlayerInventory _inventory;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _inventory = GameObject.FindObjectOfType<PlayerInventory>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _initialParent = transform.parent;
        transform.SetParent(transform.root);
        _image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        List<RaycastResult> raycastResult = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raycastResult);
        GameObject ItemLevelUp;
        foreach (RaycastResult objectInRay in raycastResult)
        {
            if (objectInRay.gameObject.TryGetComponent<UpgradableItem>(out UpgradableItem ItemInRay))
            {
                if (ItemInRay.ItemType == ItemType && ItemType != ItemType.Daimond)
                {
                    ItemLevelUp = Instantiate(_itemTypeSource.ItemUiPrefabSource[(int)ItemType + 1], ItemInRay.transform.parent);
                    
                    _inventory.InventoryList.Remove(ItemInRay.gameObject);
                    Destroy(ItemInRay.gameObject);
                    
                    _inventory.InventoryList.Add(ItemLevelUp);
                    
                    _inventory.InventoryList.Remove(gameObject);
                    Destroy(gameObject);

                }
            }
        }
        
        _image.raycastTarget = true;
        transform.SetParent(_initialParent);
        transform.localPosition = Vector3.zero;
    }
}
