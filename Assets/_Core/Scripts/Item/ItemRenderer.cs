using UnityEngine;

public class ItemRenderer : MonoBehaviour
{
    public ItemTypeSource ItemTypeSource;
    public ItemType ItemType;

    private void Start()
    {
        if (transform.childCount < 1)
        {
            Instantiate(ItemTypeSource.ItemPrefabSource[(int)ItemType], transform);
        }
    }
}
