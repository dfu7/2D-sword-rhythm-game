using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject OptionsMenu;
    [SerializeField] GameObject ControlsMenu;
    [SerializeField] AudioMixer masterAudioMixer;
    [SerializeField] GameObject Menu;

    public GameObject PlayButton;
    public GameObject QuitButton;
    public GameObject SoundButton;

    public void PlayGame()
    {
        PlayButton.GetComponent<Animator>().enabled = true;
        QuitButton.GetComponent<Animator>().enabled = true;
        SoundButton.GetComponent<Animator>().enabled = true;
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void OpenOptions()
    {
        OptionsMenu.SetActive(true);
        Menu.SetActive(false);
    }

    public void OpenControls()
    {
        ControlsMenu.SetActive(true);
        Menu.SetActive(false);
    }

    public void GoBack()
    {
        OptionsMenu.SetActive(false);
        ControlsMenu.SetActive(false);
        Menu.SetActive(true);

    }

    public void GoToStart()
    {
        SceneManager.LoadScene("Start");
        Debug.Log("Go back to start menu");
    }

    public void SetSFXVolume(float level) {
        // must convert values from db using log10
        masterAudioMixer.SetFloat("sfx-volume", Mathf.Log10(level) * 20);
        if (level == 0)
        {
            masterAudioMixer.SetFloat("sfx-volume", -80);
        }
    }

    public void SetMusicVolume(float level) {
        masterAudioMixer.SetFloat("music-volume", Mathf.Log10(level) * 20);
        if (level == 0)
        {
            masterAudioMixer.SetFloat("music-volume", -80);
        }
    }

    public void SetMasterVolume(float level)
    {
        masterAudioMixer.SetFloat("master-volume", Mathf.Log10(level) * 20);
        if (level == 0)
        {
            masterAudioMixer.SetFloat("master-volume", -80);
        }
    }

    public void ToggleMute(bool muted) {
        masterAudioMixer.SetFloat("master-volume", muted ? -80 : 0);
    }
}
