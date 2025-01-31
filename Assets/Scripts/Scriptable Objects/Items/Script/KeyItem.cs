using System;
using UnityEngine;
[CreateAssetMenu(fileName = "New Item", menuName = "Items/Key")]
public class KeyItem : ItemScriptable
{
    void Awake()
    {
        itemType = ItemType.Key;
    }
}