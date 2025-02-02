using UnityEngine;
using UnityEngine.Events;

public class ObjectInteractor : MonoBehaviour
{
    public string InteractionText = "Press E to Interact"; 
    public UnityEvent OnInteract;

    ItemScriptable item;
    int amount;

    private bool isItem = false;
    private void Start()
    {
        var itemmono = gameObject.GetComponent<ItemMono>();
        if (itemmono != null)
        {
            item = itemmono.item;
            amount = itemmono.amount;
            isItem = true;
        }
        else
        {
            Debug.Log("bu isnull amk");
        }
    }
    
    public string GetInteractionText()
    {
        if (isItem)
        {
            InteractionText = "Press E to pick up";
            return InteractionText;
        }
        return InteractionText;
    }

    public void Interact(InventoryScriptable inventory)
    {
        if (isItem)
        {
            inventory.AddItem(item, amount);
            Destroy(gameObject);
        }
        else
        {
            OnInteract.Invoke();
        }
    }
}
