using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeManager : MonoBehaviour
{
    public static GameModeManager Instance { get; set; }

    [SerializeField] Transform[] gamemodes;

    public int kills;
    public int numberOfCurrentSpawns = 5;

    private int currentGamemodeIndex = 0;

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
        ActivateGamemode(currentGamemodeIndex);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            CycleGamemode();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void CycleGamemode()
    {
        numberOfCurrentSpawns = 0;

        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");
        foreach (GameObject target in targets)
        {
            Destroy(target);
        }

        gamemodes[currentGamemodeIndex].gameObject.SetActive(false);

        currentGamemodeIndex = (currentGamemodeIndex + 1) % gamemodes.Length;
        ActivateGamemode(currentGamemodeIndex);
    }

    void ActivateGamemode(int index)
    {
        for (int i = 0; i < gamemodes.Length; i++)
        {
            gamemodes[i].gameObject.SetActive(i == index);
        }
    }
}