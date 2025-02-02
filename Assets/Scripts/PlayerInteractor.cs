using System;
using UnityEngine;
using TMPro;
public class PlayerInteractor : MonoBehaviour
{
    private InventoryScriptable inventory;
    
    public GameObject RaycastPoint;
    public GameObject CameraTrackingPoint;
    public Camera PlayerCamera;
    public GameObject InteractionText;
    public float RayDistance = 5f;
    
    public bool ShowRay = false;
    public float DrawDuration = 0.1f;
    public Color RayColor = Color.red;
    
    private ObjectInteractor currentInteractable;

    public void Start()
    {
        var _inventory = gameObject.GetComponent<InventoryMono>();
        inventory = _inventory.inventory;
    }
    
    void Update()
    {
        ObjectInteractor interactable = Interactable();
        if (interactable)
        {
            if (interactable && interactable != currentInteractable)
            {
                currentInteractable = interactable;
                InteractionText.SetActive(true);
                TextMeshProUGUI textComponent = InteractionText.GetComponent<TextMeshProUGUI>();
                if (textComponent)
                {
                    textComponent.text = currentInteractable.GetInteractionText();
                }
            }
        }
        else
        {
            currentInteractable = null;
            InteractionText.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentInteractable?.Interact(inventory);
        }
    }
    public ObjectInteractor Interactable()
    {
        //ray 1
        Ray ray1 = new Ray(CameraTrackingPoint.transform.position, PlayerCamera.transform.forward);
        RaycastHit hit1;
        bool ray1Hit = Physics.Raycast(ray1, out hit1, RayDistance);
        
        //ray 2
        Ray ray2 = new Ray(RaycastPoint.transform.position, PlayerCamera.transform.forward);
        RaycastHit hit2;
        bool ray2Hit = Physics.Raycast(ray2, out hit2, RayDistance);
        
        //ray 3
        Vector3 cameradirection = (RaycastPoint.transform.position - PlayerCamera.transform.position).normalized;
        Ray ray3 = new Ray(RaycastPoint.transform.position, cameradirection);
        RaycastHit hit3;
        bool ray3Hit = Physics.Raycast(ray3, out hit3, RayDistance);
        
        if (ShowRay)
        {
            Debug.DrawRay(ray1.origin, ray1.direction * RayDistance, RayColor, DrawDuration);
            Debug.DrawRay(ray2.origin, ray2.direction * RayDistance, RayColor, DrawDuration);
            Debug.DrawRay(ray3.origin, ray3.direction * RayDistance, RayColor, DrawDuration);
        }
        
        if (ray1Hit)
        {
            ObjectInteractor interactableObject = hit1.collider.GetComponent<ObjectInteractor>();
            if (interactableObject)
            {
                return interactableObject;
            }
        }
        if (ray2Hit)
        {
            ObjectInteractor interactableObject = hit2.collider.GetComponent<ObjectInteractor>();
            if (interactableObject)
            {
                return interactableObject;
            }
        }
        if (ray3Hit)
        {
            ObjectInteractor interactableObject = hit3.collider.GetComponent<ObjectInteractor>();
            if (interactableObject)
            {
                return interactableObject;
            }
        }
        return null;
    }
}
