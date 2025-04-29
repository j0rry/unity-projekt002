using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetSpawner : MonoBehaviour
{

    [SerializeField] GameObject TargetPrefab; 
    [SerializeField] Transform spawnBox;      
    [SerializeField] int numberOfSpawns = 5; 
    [SerializeField] Vector3 targetScale;

    Vector3 spawnBoxSize; // Volymen på spawn box

    void Start()
    {
        // Sparar spawnBoxens storlek i spawnBoxSize.
        spawnBoxSize = spawnBox.localScale;

        // sätter hur många spawns det ska vara
        GameModeManager.Instance.numberOfCurrentSpawns = numberOfSpawns;

        // spawnar alla targets 
        for (int i = 0; i < numberOfSpawns; i++)
        {
            SpawnRandomSphere();
        }
    }

    void Update()
    {
        // Om current spawns är mindre än spawns som ska vara 
        if(GameModeManager.Instance.numberOfCurrentSpawns < numberOfSpawns) {
            // Spawna måltavlor
            SpawnRandomSphere();
            // Lägger till en i current spawns
            GameModeManager.Instance.numberOfCurrentSpawns++;
        }
    }

    public void SpawnRandomSphere()
    {
        // Få en random position i spawnboxens volym.
        Vector3 randomPosition = new Vector3(
            Random.Range(-spawnBoxSize.x / 2, spawnBoxSize.x / 2),
            Random.Range(-spawnBoxSize.y / 2, spawnBoxSize.y / 2),
            Random.Range(-spawnBoxSize.z / 2, spawnBoxSize.z / 2)
        );

        // lägg till spawnboxens position till random position
        randomPosition += spawnBox.position;

        // Spawna måltavla
        GameObject target = Instantiate(TargetPrefab, randomPosition, Quaternion.identity);

        // ändra scale
        target.transform.localScale = targetScale;
    }
}
