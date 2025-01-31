using UnityEngine;

public class ItemTrigger : MonoBehaviour
{
    void OntriggerEnter(Collider other)
    {
        ItemScriptable item = gameObject.GetComponent<ItemScriptable>();
        var inventory = other.gameObject.GetComponent<InventoryMono>();
        if (inventory)
        {
            inventory.inventory.AddItem(item, 1);
        }
    }
}
