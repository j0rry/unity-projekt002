using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    public Transform playerBody;

    public float cs2Sensitivity = 2.0f;
    public int dpi = 800;

    float xRotation = 0f;
    float unitySensitivity;
    Vector2 lookInput;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnLook(InputValue value)
    {
        lookInput = value.Get<Vector2>();
    }

    void Update()
    {
       
        unitySensitivity = cs2Sensitivity * 0.022f * (dpi / 400f);

        Vector2 lookDelta = lookInput;
        float mouseX = lookDelta.x * unitySensitivity;
        float mouseY = lookDelta.y * unitySensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -89f, 89f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
