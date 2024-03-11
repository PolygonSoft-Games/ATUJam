using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour
{
    public Slider slider;

     void Start()
    {
        slider.value = 1;
        if (PlayerPrefs.HasKey("musicVolumeLevel"))
        {
            PlayerPrefs.SetFloat("musicVolumeLevel", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

     public void ChangeMusic()
    {
        AudioListener.volume = slider.value;
        Save();
    }

    void Save()
    {
        PlayerPrefs.SetFloat("musicVolumeLevel", slider.value);
    }

    void Load()
    {
        slider.value = PlayerPrefs.GetFloat("musicVolumeLevel");
    }

}
