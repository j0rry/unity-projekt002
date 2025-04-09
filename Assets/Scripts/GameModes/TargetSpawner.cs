using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetSpawner : MonoBehaviour
{

    [SerializeField] GameObject TargetPrefab; 
    [SerializeField] Transform spawnBox;      
    [SerializeField] int numberOfSpawns = 5; 
    [SerializeField] Vector3 targetScale;

    Vector3 spawnBoxSize;

    void Start()
    {
        spawnBoxSize = spawnBox.localScale;

        GameModeManager.Instance.numberOfCurrentSpawns = numberOfSpawns;

        for (int i = 0; i < numberOfSpawns; i++)
        {
            SpawnRandomSphere();
        }
    }

    void Update()
    {
        if(GameModeManager.Instance.numberOfCurrentSpawns < numberOfSpawns) {
            SpawnRandomSphere();
            GameModeManager.Instance.numberOfCurrentSpawns++;
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

        
        GameObject target = Instantiate(TargetPrefab, randomPosition, Quaternion.identity);
        target.transform.localScale = targetScale;
    }
}
