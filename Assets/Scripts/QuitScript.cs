using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitScript : MonoBehaviour
{
    public void QuitGameFunction()
    {
        Debug.Log("Oyun Kapatılıyor..");
        Application.Quit();
    }
}
