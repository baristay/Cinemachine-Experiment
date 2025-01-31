using System.Collections.Generic;
using UnityEngine;

public class InventoryMono : MonoBehaviour
{
    public InventoryScriptable inventory;
    public bool HasItem(string itemName)
    {
        foreach (InventorySlot slot in inventory.Items)
        {
            if (slot.item.itemName == itemName)
            {
                return true;
            }
        }
        return false;
    }
    
    private void Start()
    {
        Debug.Log("Inventory yüklendi. Mevcut öğe sayısı: " + inventory.Items.Count);
        if (HasItem("Key"))
        {
            Debug.Log("Envanterde 'Key' var!");
        }
        else
        {
            Debug.Log("Envanterde 'Key' bulunamadı.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var item = other.gameObject.GetComponent<ItemMono>();
        if (item)
        {
            inventory.AddItem(item.item, item.amount);
            Destroy(other.gameObject);
        }

        var required = other.gameObject.GetComponent<RequiredItems>();
        if (required)
        {
            bool hasReq = true;

            foreach (ItemScriptable a in required.reqIt)
            {
                if (!HasItem(a.itemName))
                {
                    hasReq = false;;
                }
            }
            if (hasReq)
            {
                Destroy(other.gameObject);
            }
        }
    }

    private void OnApplicationQuit()
    {
        inventory.Items.Clear();
    }
}
