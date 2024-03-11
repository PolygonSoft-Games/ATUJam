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

    public void CheckILose()
    {
        currentHealth--;
        if (currentHealth <= 0)
        {
            isDeath._isDeath = false;
            SceneManager.LoadScene(sceneBuildIndex: 3);
        }
    }

    public bool isGameOver()
    {
        return GameOver;
    }

}