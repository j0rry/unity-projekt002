using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] int damage = 1;
    
    void OnFire(InputValue value)
    {
        if (value.isPressed)
        {
            Shoot();
        }
    }

    void Shoot() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if(hit.collider.GetComponent<Target>()){
                hit.collider.GetComponent<Target>().health -= damage;
            }
        }
    }
}
