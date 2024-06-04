using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private SceneField tutorialScene;

    public void Start()
    {
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume", .5f);
        AudioManager.Instance?.SetMasterVolume(PlayerPrefs.GetFloat("MasterVolume", .5f));
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", .5f);
        AudioManager.Instance?.SetMusicVolume(PlayerPrefs.GetFloat("MusicVolume", .5f));
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", .5f);
        AudioManager.Instance?.SetSFXVolume(PlayerPrefs.GetFloat("SFXVolume", .5f));
    }

    public void StartGame()
    {
        SceneSwapManager.Instance.FadeOutAndChangeScene(tutorialScene);
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void MasterVolume()
    {
        AudioManager.Instance.SetMasterVolume(masterSlider.value);
        PlayerPrefs.SetFloat("MasterVolume", masterSlider.value);
        PlayerPrefs.Save();
    }

    public void MusicVolume()
    {
        AudioManager.Instance.SetMusicVolume(musicSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
        PlayerPrefs.Save();
    }

    public void SFXVolume()
    {
        AudioManager.Instance.SetSFXVolume(sfxSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);
        PlayerPrefs.Save();
    }

}
