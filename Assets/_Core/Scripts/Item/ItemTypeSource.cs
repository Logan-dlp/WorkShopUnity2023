using System;
using UnityEngine;

public enum ItemType
{
    Wood,
    Stone,
    Coal,
    Iron,
    Gold,
    Daimond,
}

[CreateAssetMenu(fileName = "new_ItemTypeSource", menuName = "Items/ItemTypeSource")]
public class ItemTypeSource : ScriptableObject
{
    [SerializeField] private GameObject[] _itemPrefabSource = new GameObject[Enum.GetValues(typeof(ItemType)).Length];
    public GameObject[] ItemPrefabSource => _itemPrefabSource;

    [SerializeField] private GameObject[] _itemUiPrefabSource = new GameObject[Enum.GetValues(typeof(ItemType)).Length];
    public GameObject[] ItemUiPrefabSource => _itemUiPrefabSource;
}
