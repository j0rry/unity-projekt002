using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetSpawner : MonoBehaviour
{

    [SerializeField] GameObject spherePrefab;  
    [SerializeField] Transform spawnBox;      
    [SerializeField] int numberOfSpawns = 5; 
    [SerializeField] Vector3 spawnBoxSize;
    [SerializeField] float targetScale = 1;

    void Start()
    {
        spawnBoxSize = spawnBox.localScale;

        GameModeManager.Instance.numberOfCurrentSpawns = numberOfSpawns;

        for (int i = 0; i < numberOfSpawns; i++)
        {
            SpawnRandomSphere(targetScale);
        }
    }

    void Update()
    {
        if(GameModeManager.Instance.numberOfCurrentSpawns < numberOfSpawns) {
            SpawnRandomSphere(targetScale);
            GameModeManager.Instance.numberOfCurrentSpawns++;
        }
    }

    public void SpawnRandomSphere(float scale)
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(-spawnBoxSize.x / 2, spawnBoxSize.x / 2),
            Random.Range(-spawnBoxSize.y / 2, spawnBoxSize.y / 2),
            Random.Range(-spawnBoxSize.z / 2, spawnBoxSize.z / 2)
        );

        
        randomPosition += spawnBox.position;

        
        GameObject target = Instantiate(spherePrefab, randomPosition, Quaternion.identity);
        target.transform.localScale = new Vector3(scale, scale, scale);
    }
}
