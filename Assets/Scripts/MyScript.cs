using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float speed = 3f;
    public float sprintSpeed = 1.75f;
    public Transform cameraTransform;
    public Transform playerTransform;
    float xMove, yMove;
    float gravity = -9.81f;
    Vector3 movement;
    CharacterController controller;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        xMove = Input.GetAxis("Horizontal") * speed;
        yMove = Input.GetAxis("Vertical") * speed;
        if (Keyboard.current.leftShiftKey.isPressed)
        {
            yMove *= sprintSpeed;
            Debug.Log(xMove);
        }
        movement = new Vector3(xMove, gravity, yMove);
        Quaternion targetRotation = Quaternion.Euler(0f, cameraTransform.rotation.eulerAngles.y, 0f);
        movement *= speed;
        movement = targetRotation * movement;
        playerTransform.rotation = Quaternion.Euler(0f, cameraTransform.rotation.eulerAngles.y, 0f);
        controller.Move(movement * Time.deltaTime);
    }
}
