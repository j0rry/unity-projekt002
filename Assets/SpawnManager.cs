using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject spherePrefab;  
    public Transform spawnBox;      
    public int numberOfSpawns = 5; 
    private Vector3 spawnBoxSize;

    void Start()
    {
        spawnBoxSize = spawnBox.localScale;

        for (int i = 0; i < numberOfSpawns; i++)
        {
            SpawnRandomSphere();
        }
    }

    public void SpawnRandomSphere()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(-spawnBoxSize.x / 2, spawnBoxSize.x / 2),
            Random.Range(-spawnBoxSize.y / 2, spawnBoxSize.y / 2),
            Random.Range(-spawnBoxSize.z / 2, spawnBoxSize.z / 2)
        );

        
        randomPosition += spawnBox.position;

        
        Instantiate(spherePrefab, randomPosition, Quaternion.identity);
    }

    
    public void SpawnOnShoot()
    {
        SpawnRandomSphere();
    }
}
