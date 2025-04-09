using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracking : MonoBehaviour
{
    [SerializeField] int targets = 1;
    [SerializeField] float speed = 5;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform[] waypoints;

    void OnEnable()
    {
        GameModeManager.Instance.numberOfCurrentSpawns = targets;
        
        if (waypoints.Length > 0)
        {
            for (int i = 0; i < targets; i++)
            {
                GameObject enemy = SpawnEnemy();

                EnemyTarget enemyTarget = enemy.GetComponent<EnemyTarget>();
                if (enemyTarget != null)
                {
                    enemyTarget.SetWaypoints(waypoints);
                }
            }
        }
    }

    void Update()
    {
        if(waypoints.Length > 0 && GameModeManager.Instance.numberOfCurrentSpawns < targets){
            for (int i = 0; i < targets; i++)
            {
                SpawnEnemy();
                GameModeManager.Instance.numberOfCurrentSpawns++;
            }
        }
    }

    GameObject SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, waypoints[Random.Range(0, waypoints.Length)].position, Quaternion.identity);
        enemy.GetComponent<EnemyTarget>().godMode = true;
        enemy.GetComponent<EnemyTarget>().moveSpeed = speed;
        return enemy;
    }

}
