using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] int headHealth = 100;
    [SerializeField] int bodyHealth = 100;
    [SerializeField] int totalHealth;

    void Start()
    {
        totalHealth = headHealth + bodyHealth;
    }

    
}
