using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] int headHealth = 1;
    [SerializeField] int bodyHealth = 4;
    [SerializeField] int TotalHealth => headHealth + bodyHealth;

    
    [Header("Fun")]
    public float moveSpeed = 3f;
    public bool godMode = false;
    [SerializeField] GameObject canvas;

    [SerializeField] Transform[] waypoints;
    int currentWaypointIndex = 0;

    [SerializeField] Healthbar healthbar;
    int maxHealth;


    void Start(){
        maxHealth = TotalHealth;
        if (healthbar != null)
        {
            healthbar.InitializeHealthBar(TotalHealth);
            healthbar.UpdateHealthBar(TotalHealth);
        }
    }

    public void TakeDamage(string hitArea, int damage)
    {
        if(godMode) return;

        if (hitArea == "Head")
        {
            headHealth -= damage * 2;
        }
        else if (hitArea == "Body")
        {
            bodyHealth -= damage;
        }
        if (healthbar != null)
        {
            healthbar.UpdateHealthBar(TotalHealth);
        }

        if(TotalHealth < maxHealth) {
            canvas.SetActive(true);
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
        GameModeManager.Instance.numberOfCurrentSpawns--;
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
            currentWaypointIndex = Random.Range(0, waypoints.Length);
        }
    }


    public void SetWaypoints(Transform[] waypoints){
        this.waypoints = waypoints;
    }

}
