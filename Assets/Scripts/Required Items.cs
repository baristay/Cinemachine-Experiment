using System.Collections.Generic;
using UnityEngine;

public class RequiredItems : MonoBehaviour
{
    [SerializeField] public List<ItemScriptable> reqIt = new List<ItemScriptable>();

    public bool HasReqItem(InventoryScriptable inventory)
    {
        if (reqIt.Count == 0)
        {
            return true;
        }
        else if (inventory.Items.Count == 0)
        {
            return false;
        }
        foreach (ItemScriptable reqitems in reqIt)
        {
            if (!inventory.HasItem(reqitems.itemName))
            {
                return false;
            }
        }
        return true;
    }
}
