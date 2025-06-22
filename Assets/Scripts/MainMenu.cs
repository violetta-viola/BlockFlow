using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Toggle muteToggle;
    public AudioSource music;

    private void Start()
    {
        // Загрузить предыдущее состояние звука
        bool isMuted = PlayerPrefs.GetInt("Muted", 0) == 1;
        AudioListener.pause = isMuted;
        muteToggle.isOn = isMuted;
    }

    public void OnStartGame()
    {
        SceneManager.LoadScene("Level1"); // Или другая игровая сцена
    }

    public void OnQuitGame()
    {
        Application.Quit();
    }

    public void OnMuteToggleChanged()
    {
        bool mute = muteToggle.isOn;
        AudioListener.pause = mute;
        PlayerPrefs.SetInt("Muted", mute ? 1 : 0);
        PlayerPrefs.Save();
    }
    public void ReturnToLastLevel()
    {
        int lastLevel = PlayerPrefs.GetInt("lastLevel", 1); // 1 — по умолчанию, если ничего не сохранено
        SceneManager.LoadScene(lastLevel);
    }
}

