using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] int headHealth = 100;
    [SerializeField] int bodyHealth = 100;
    public int TotalHealth => headHealth + bodyHealth;

    void Start()
    {
       
    }

    public void TakeDamage(string hitArea, int damage)
    {
        if (hitArea == "Head")
        {
            headHealth -= damage * 100;
        }
        else if (hitArea == "Body")
        {
            bodyHealth -= damage * 20;
        }
    }

    void Update()
    {
        
        if (TotalHealth <= 0)
        {
            Die();
        }

        if(headHealth <= 0 || bodyHealth <= 0) Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }




}
