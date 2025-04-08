using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance { get; set; }

    public GameObject spherePrefab;  
    public Transform spawnBox;      
    public int numberOfSpawns = 5; 
    private Vector3 spawnBoxSize;
    public int kills;

    public int numberOfCurrentSpawns = 5;



    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


    void Start()
    {
        spawnBoxSize = spawnBox.localScale;

        numberOfCurrentSpawns = numberOfSpawns;

        for (int i = 0; i < numberOfSpawns; i++)
        {
            SpawnRandomSphere();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SpawnRandomSphere();
        }

        if(Input.GetKeyDown(KeyCode.Escape)) Application.Quit();

        if(Input.GetKeyDown(KeyCode.P)) SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        if(numberOfCurrentSpawns < numberOfSpawns) {
            SpawnRandomSphere();
            numberOfCurrentSpawns++;
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
