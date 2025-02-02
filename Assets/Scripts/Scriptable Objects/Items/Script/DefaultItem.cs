using System;
using UnityEngine;
[CreateAssetMenu(fileName = "New Item", menuName = "Items/Default")]
public class DefaultItem : ItemScriptable
{
    void Awake()
    {
        itemType = ItemType.Default;
    }
}
