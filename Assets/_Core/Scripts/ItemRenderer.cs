using System;
using UnityEngine;

public class ItemRenderer : MonoBehaviour
{
    [SerializeField] private ItemTypeSource _itemTypeSource;
    [SerializeField] private ItemType _itemType;

    private void Start()
    {
        Instantiate(_itemTypeSource.ItemPrefabSource[(int)_itemType], transform);
    }
}
