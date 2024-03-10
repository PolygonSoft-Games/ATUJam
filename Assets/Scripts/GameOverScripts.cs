using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScripts : MonoBehaviour
{
    public int start;
    private void Awake()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    public void RestartButton()
    {

        SceneManager.LoadScene(start);

    }

    public void QuitButton()
    {
        Application.Quit();
    }

}
