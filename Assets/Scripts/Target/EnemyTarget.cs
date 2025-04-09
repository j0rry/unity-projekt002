using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
    [Header("Health")]
    public int headHealth = 100;
    public int bodyHealth = 100;
    public int TotalHealth => headHealth + bodyHealth;
    
    [Header("Fun")]
    public float moveSpeed = 3f;
    public bool godMode = false;

    [SerializeField] Transform[] waypoints;
    int currentWaypointIndex = 0;

    public void TakeDamage(string hitArea, int damage)
    {
        if(godMode) return;

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

        MoveEnemy();

    }

    void Die()
    {
        Destroy(gameObject);
    }

    void MoveEnemy() {
        if(waypoints == null || waypoints.Length == 0) return;

        Transform targetWaypoint = waypoints[currentWaypointIndex];
                transform.position = Vector3.MoveTowards(
            transform.position,
            targetWaypoint.position,
            moveSpeed * Time.deltaTime
        );

               
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }


    public void SetWaypoints(Transform[] waypoints){
        this.waypoints = waypoints;
    }

}
