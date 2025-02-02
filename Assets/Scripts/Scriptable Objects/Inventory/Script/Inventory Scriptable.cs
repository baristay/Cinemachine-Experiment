using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Inventory")]
public class InventoryScriptable : ScriptableObject
{
    public List<InventorySlot> Items = new List<InventorySlot>();
    public void AddItem(ItemScriptable _item, int _amount)
    {
        InventorySlot existingSlot = Items.Find(slot => slot.item == _item);
        if (existingSlot != null)
        {
            existingSlot.AddAmount(_amount);
            return;
        }
        
        Items.Add(new InventorySlot(_item, _amount));
    }
    public bool HasItem(string itemname)
    {
        foreach (InventorySlot slot in Items)
        {
            if (slot.item.itemName == itemname)
            {
                return true;
            }
        }
        return false;
    }
}
[System.Serializable]
public class InventorySlot
{
    public ItemScriptable item;
    public int amount;

    public InventorySlot(ItemScriptable _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }
}