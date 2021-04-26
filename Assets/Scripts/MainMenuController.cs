using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{


    public Slider MusicVolume;
    public Slider EffectVolume;

    public GameObject HowToPlayPanel;
    public GameObject BackButton;

    public AudioSource MainMenuMusic;

    private void Start()
    {
        DynamicGI.UpdateEnvironment();
        MusicVolume.value = PlayerPrefs.GetFloat("Music", 1f);
        EffectVolume.value = PlayerPrefs.GetFloat("Effects", 0.25f);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenHowTo()
    {
        HowToPlayPanel.SetActive(true);
        BackButton.SetActive(true);
    }

    public void CloseHowTo()
    {
        HowToPlayPanel.SetActive(false);
        BackButton.SetActive(false);
    }

    public void Update()
    {
        PlayerPrefs.SetFloat("Music", MusicVolume.value);
        PlayerPrefs.SetFloat("Effects", EffectVolume.value);
        MainMenuMusic.volume = MusicVolume.value;
    }

}
