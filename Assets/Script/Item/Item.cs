using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName = "New Item/item")]

public class Item : ScriptableObject
{
    public string itemName;
    public ItemType itemType;
    public Sprite itemImage;
    public GameObject itemPrefab;

    public string Type;

    public enum ItemType
    {
        Used,
        ETC
    }
}
