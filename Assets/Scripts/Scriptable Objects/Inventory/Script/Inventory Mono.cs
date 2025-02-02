using System.Collections.Generic;
using UnityEngine;

public class InventoryMono : MonoBehaviour
{
    public InventoryScriptable inventory;
    private void OnTriggerEnter(Collider other)
    {
        var required = other.gameObject.GetComponent<RequiredItems>();
        if (required)
        {
            if (required.HasReqItem(inventory))
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
