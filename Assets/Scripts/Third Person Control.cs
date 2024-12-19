using UnityEngine;

public class ThirdPersonControl : MonoBehaviour
{
    public Transform cameraTransform;
    public Transform playerTransform;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        playerTransform.rotation = Quaternion.Euler(0f, cameraTransform.rotation.eulerAngles.y, 0f);
    }
}
