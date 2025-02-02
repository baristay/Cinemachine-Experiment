using UnityEngine;
public enum ItemType
{
    Default,
    Key
}
public class ItemScriptable : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public ItemType itemType ;
}
