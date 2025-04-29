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
        RaycastHit hit; // raycast för att checka

        if (Physics.Raycast(transform.position, transform.forward, out hit)) // om den träffar
        {
            EnemyTarget enemy = hit.collider.GetComponentInParent<EnemyTarget>(); // ta hit colliders enemytarget script
            if (enemy != null) // om den inte är null
            {
                string hitArea = hit.collider.tag; // få tag på vilken kroppsdel som träffades
                enemy.TakeDamage(hitArea, damage); // ta skada på enemy beroende på  vilken kroppsdel
            }

            
            Target target = hit.collider.GetComponent<Target>(); // Tar på hit ta Target script från collider
            if (target != null) // om den inte är null
            {
                target.health -= damage; // så ta skada
            }
        }
    }
}
