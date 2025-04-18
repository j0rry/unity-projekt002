using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] public int health = 1;

    void Update()
    {
        if(health <= 0) {
            Destroy(gameObject);
            GameModeManager.Instance.numberOfCurrentSpawns--;
            GameModeManager.Instance.kills++;
        }
    }
}
