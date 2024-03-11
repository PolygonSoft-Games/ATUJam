using UnityEngine;
using UnityEngine.SceneManagement;

public class WinOrLose : MonoBehaviour
{
    [SerializeField] private GameObject win, lose;
    public bool check;
    [SerializeField] float t = 5f;
    [SerializeField] private int winIndex;
    [SerializeField] private int LoseIndex;
    private void Awake()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        check = isDeath._isDeath;
    }
    private void Start()
    {
        if (check)
        {
            t = 17;
            win.SetActive(true);
            lose.SetActive(false);
        }
        else
        {
            t = 10f;
            lose.SetActive(true);
            win.SetActive(false);
        }
    }
    private void Update()
    {
        t -= Time.deltaTime;
        if (t < 0)
        {
            if (check)
            {
                SceneManager.LoadScene(winIndex);
            }
            else
            {
                SceneManager.LoadScene(LoseIndex);
            }
        }
    }
}

public class isDeath
{
    public static bool _isDeath;
}