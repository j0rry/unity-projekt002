using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracking : MonoBehaviour
{
    int targets = 1;
    [SerializeField] GameObject enemy;
    [SerializeField] Transform[] waypoints;

    void Start()
    {
        Instantiate(enemy);
    }

}
