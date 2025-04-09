using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracking : MonoBehaviour
{
    int targets = 1;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform[] waypoints;

    void Start()
    {
        GameModeManager.Instance.numberOfCurrentSpawns = targets;
        
        if (waypoints.Length > 0)
        {
            GameObject enemy = Instantiate(enemyPrefab, waypoints[0].position, Quaternion.identity);

            EnemyTarget enemyTarget = enemy.GetComponent<EnemyTarget>();
            if (enemyTarget != null)
            {
                enemyTarget.SetWaypoints(waypoints);
            }
        }
    }

    void Update()
    {
        
    }

}
