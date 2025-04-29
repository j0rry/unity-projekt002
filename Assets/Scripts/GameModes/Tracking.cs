using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracking : MonoBehaviour
{
    [SerializeField] int targets = 1;
    [SerializeField] float speed = 5;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform[] waypoints;
    [SerializeField] bool isMovingTarget = false;
    [SerializeField] bool targetGodMode = false;

    void OnEnable()
    {
        // sätter currents spawns till hur många det ska vara på plan.
        GameModeManager.Instance.numberOfCurrentSpawns = targets;
        
        // Lägger ut enemys när gamemode cyclar till gamemode 
        if (waypoints.Length > 0)
        {
            for (int i = 0; i < targets; i++)
            {
                GameObject enemy = SpawnEnemy();

                SetWaypoints(enemy);
            }
        }
    }

    void SetWaypoints(GameObject enemy){
        // Sätter waypoints till enemy, så att den vet vart den ska gå.
        EnemyTarget enemyTarget = enemy.GetComponent<EnemyTarget>();
        if (enemyTarget != null && isMovingTarget)
        {
            enemyTarget.SetWaypoints(waypoints);
        }
    }

    void Update()
    {
        // Spawna Enemy om det finns waypoints och om spawnade enemy är mindre än targets som ska vara framme.
        if(waypoints.Length > 0 && GameModeManager.Instance.numberOfCurrentSpawns < targets){
            for (int i = 0; i < targets; i++)
            {
                GameObject enemy = SpawnEnemy();
                SetWaypoints(enemy); // Ge enemy waypoints
                GameModeManager.Instance.numberOfCurrentSpawns++; // öka current spawns
            }
        }
    }

    GameObject SpawnEnemy()
    {
        // Spawna enemy på en random waypoint
        GameObject enemy = Instantiate(enemyPrefab, waypoints[Random.Range(0, waypoints.Length)].position, Quaternion.identity);
        enemy.GetComponent<EnemyTarget>().godMode = targetGodMode;
        enemy.GetComponent<EnemyTarget>().moveSpeed = speed;
        return enemy;
    }

}
