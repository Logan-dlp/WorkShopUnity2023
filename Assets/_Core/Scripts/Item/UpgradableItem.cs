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
        foreach (RaycastResult objectInRay in raycastResult)
        {
            if (objectInRay.gameObject.TryGetComponent<UpgradableItem>(out UpgradableItem ItemInRay))
            {
                if (ItemInRay.ItemType == ItemType)
                {
                    // inventory...
                    Debug.Log("meme type");
                }
            }
        }
        
        _image.raycastTarget = true;
        transform.SetParent(_initialParent);
        transform.localPosition = Vector3.zero;
    }
}
