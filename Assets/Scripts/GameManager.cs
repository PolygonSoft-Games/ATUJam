using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int tourchCount;
    [SerializeField] private int maxHealth;

    [Header("Scene Index")]
    [SerializeField] private int Index;

    [HideInInspector] public int currentTourch;
    [HideInInspector] public int currentHealth;

    bool GameOver;

    private void Awake()
    {
        currentHealth = maxHealth;
        Instance = this;
    }

    public void checkIWinned()
    {
        currentTourch++;
        if (tourchCount == currentTourch)
        {
            SceneManager.LoadScene(Index);
        }
    }

    public void CheckILose()
    {
        currentHealth--;
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(Index);
        }
    }

    public bool isGameOver()
    {
        return GameOver;
    }

}