using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int itemCount;
    [SerializeField] private int maxHealth;

    [Header("Scene Index")]
    [SerializeField] private int Index;

    [HideInInspector] public int currentItem;
    [HideInInspector] public int currentHealth;

    bool GameOver;

    private void Awake()
    {
        currentHealth = maxHealth;
        Instance = this;
    }

    public void checkIWinned()
    {
        currentItem++;
        if (itemCount == currentItem)
        {
            isDeath._isDeath = true;
            SceneManager.LoadScene(Index);
        }
    }

    public void CheckILose()
    {
        currentHealth--;
        if (currentHealth <= 0)
        {
            isDeath._isDeath = false;
            SceneManager.LoadScene(Index);
        }
    }

    public bool isGameOver()
    {
        return GameOver;
    }

}