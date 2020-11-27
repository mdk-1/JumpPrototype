using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

//script to handle main menu, options and character select functions & events

public class MenuHandler : MonoBehaviour
{
    //reference to UI elements
    public AudioMixer masterAudio;
    public Slider musicSlider;
    public Slider sFXSlider;

    public GameObject inputField;
    public static string playerName;


    //Populate screen resolutions dropbox with available options
    //Load Playerprefs
    private void Start()
    {
        LoadPlayerPrefs();
    }
    /// <summary>
    /// method to change volume group from audiomixer
    /// this is for music
    /// </summary>
    /// <param name="volume"></param>
    public void ChangeVolume(float volume)
    {
        masterAudio.SetFloat("volume", volume);
    }
    /// <summary>
    /// method to change volume group from audiomixer
    /// this is for sound effects
    /// </summary>
    /// <param name="volume"></param>
    public void ChangeSfxVolume(float volume)
    {
        masterAudio.SetFloat("sfxvolume", volume);
    }
    /// <summary>
    /// method to mute audio, this mutes the master audio mixer group
    /// </summary>
    /// <param name="isMuted"></param>
    public void ToggleMute(bool isMuted)
    {
        if (isMuted)
        {
            masterAudio.SetFloat("isMutedVolume", -80);
        }
        else
        {
            masterAudio.SetFloat("isMutedVolume", 0);
        }
    }
    /// <summary>
    /// method to set screen resolution to chosen field in dropdown
    /// </summary>
    /// <param name="resolutionIndex"></param>
    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    /// <summary>
    /// method to quit unity editor runtime mode
    /// or quit the application if not in editor
    /// </summary>
    public void ExitToDesktop()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
    /// <summary>
    /// method to save the player preferences
    /// </summary>
    public void SavePlayerPrefs()
    {
        //save audio Sliders
        float musicVol;
        if (masterAudio.GetFloat("volume", out musicVol))
        {
            PlayerPrefs.SetFloat("volume", musicVol);
        }

        float SFXVol;
        if (masterAudio.GetFloat("sfxvolume", out SFXVol))
        {
            PlayerPrefs.SetFloat("sfxvolume", SFXVol);
        }
        PlayerPrefs.Save();
    }

    /// <summary>
    /// method to load from the player preferences
    /// </summary>
    public void LoadPlayerPrefs()
    {              
        //load audio Sliders
        float musicVol = PlayerPrefs.GetFloat("volume");
        musicSlider.value = musicVol;
        masterAudio.SetFloat("volume", musicVol);
        float SFXVol = PlayerPrefs.GetFloat("sfxvolume");
        sFXSlider.value = SFXVol;
        masterAudio.SetFloat("sfxvolume", SFXVol);
    }
    public void StoreName()
    {
        playerName = inputField.GetComponent<Text>().text;
        StartGame();
    }
    void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
