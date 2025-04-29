using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeManager : MonoBehaviour
{
    public static GameModeManager Instance { get; set; }

    [SerializeField] Transform[] gamemodes; // alla gamemodes så man kan cycla

    public int kills;
    public int numberOfCurrentSpawns = 5; // nuvarande spawnade objekt

    private int currentGamemodeIndex = 0; // Vilket gamemode

    void Awake()
    {
        // Används för att spara GameModeManager till andra scener
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
        ActivateGamemode(currentGamemodeIndex); // vid start så sätt gamemode till current gamemode index
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            CycleGamemode(); // byt gamemode
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void CycleGamemode()
    {
        // ta bort nuvarande spawnade targets / spawns
        numberOfCurrentSpawns = 0;

        // Ta bort alla targets som finns i scenen med tag
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");
        foreach (GameObject target in targets)
        {
            Destroy(target);
        }

        // Stänger av den nuvarande gamemode script
        gamemodes[currentGamemodeIndex].gameObject.SetActive(false);

        // ändra till nästa Gamemode
        currentGamemodeIndex = (currentGamemodeIndex + 1) % gamemodes.Length;
        ActivateGamemode(currentGamemodeIndex); // aktivera gamemode 
    }

    void ActivateGamemode(int index)
    {
        for (int i = 0; i < gamemodes.Length; i++)
        {
            gamemodes[i].gameObject.SetActive(i == index);
        }
    }
}