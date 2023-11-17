using UnityEngine;

public class ItemRenderer : MonoBehaviour
{
    public ItemTypeSource ItemTypeSource;
    public ItemType ItemType;

    private void Start()
    {
        Instantiate(ItemTypeSource.ItemPrefabSource[(int)ItemType], transform);
    }
}
