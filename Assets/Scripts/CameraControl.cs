using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControl : MonoBehaviour
{   
    public float hasasiyetX = 10f; 
    public float hasasiyetY = 10f; 
    public float sinir = 80f; // Dikey  sınırı

    private Vector2 bakis; // Fare hareket girişi
    private float X; // Mevcut yatay açı
    private float Y; // Mevcut dikey açı

    [SerializeField] InputAction bakaksiyon; 

    private void OnEnable()
    {
        bakaksiyon.Enable();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        kamera_hareket();
    }

    void kamera_hareket()
    {
      // Fare hareketini doğrudan al
      bakis = Mouse.current.delta.ReadValue();

      // Yatay ve dikey açıları güncelle
      X += bakis.x * hasasiyetX * Time.deltaTime;
      Y -= bakis.y * hasasiyetY * Time.deltaTime;

      // Dikey açı için sınır 
      Y = Mathf.Clamp(Y, -sinir, sinir);

      // Kamera dönüşünü uygulayalım
      transform.localRotation = Quaternion.Euler(Y, X, 0);
    }
}