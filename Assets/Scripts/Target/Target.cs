using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] public int health = 1; // Targets nuvarande hp

    void Update()
    {
        if (health <= 0) // kollar om den lever
        {
            // Förstör target och ta bort nuvarande spawnade enemys och lägg till en i kills.
            Destroy(gameObject); 
            GameModeManager.Instance.numberOfCurrentSpawns--;
            GameModeManager.Instance.kills++;
        }
    }
}
