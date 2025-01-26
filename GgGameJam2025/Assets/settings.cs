using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class options : MonoBehaviour
{
    public AudioMixer mainMixer;
    public void setFullscreen(Boolean isFullscreen){
      Screen.fullScreen = isFullscreen;
    }
    public void Setquality(int qualityIndex){
       QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetVolume(float Volume){
        mainMixer.SetFloat("volumee", Volume);
    }
    public void Back()
    {
        SceneManager.LoadScene("mainmenu");
    }
}
