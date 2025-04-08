using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] public int health = 1;
    [SerializeField] public float scale = 1;

    void Start()
    {
        transform.localScale = new Vector3(scale, scale, scale);
    }

    void Update()
    {
        if(health <= 0) {
            Destroy(gameObject);
            --SpawnManager.Instance.numberOfCurrentSpawns;
            SpawnManager.Instance.kills++;
        }
    }
}
