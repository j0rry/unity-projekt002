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
            EnemyTarget enemy = hit.collider.GetComponentInParent<EnemyTarget>();
            if (enemy != null)
            {
                string hitArea = hit.collider.tag;
                enemy.TakeDamage(hitArea, damage);
            }

            
            Target target = hit.collider.GetComponent<Target>();
            if (target != null)
            {
                target.health -= damage;
            }
        }
    }
}
