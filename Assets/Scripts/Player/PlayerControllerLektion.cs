using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements.Experimental;

public class PlayerControllerLektion : MonoBehaviour
{
    Animator animator;
    bool walking = false;
    Vector2 moveInput = Vector2.zero;
    [SerializeField]
    float speed = 5;
    [SerializeField]
    float rotationSpeed = 5;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {


        transform.Rotate(Vector3.up, moveInput.x * rotationSpeed * Time.deltaTime);
        Vector3 movement = transform.forward * moveInput.y;




        if (moveInput.magnitude > 0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        GetComponent<CharacterController>().Move(movement * speed * Time.deltaTime);

        // transform.Translate(movement * speed * Time.deltaTime);


        // transform.Rotate(transform.up, moveInput.x);

    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}
