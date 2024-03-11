using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMemu : MonoBehaviour
{
    public static bool ispaused;
    public GameObject menupanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ispaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
        menupanel.SetActive(false);
        Time.timeScale = 1f;
        ispaused = false;

    }

    public void Pause()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        menupanel.SetActive(true);
        Time.timeScale = 0f;
        ispaused = true;
    }

    public void Again()
    {
        SceneManager.LoadScene("StartScreen");
        Time.timeScale = 1f;
    }
}
