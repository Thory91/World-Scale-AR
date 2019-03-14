using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePause : MonoBehaviour
{
    public GameObject pausePanel;
    public static TogglePause instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        pausePanel.SetActive(false);
    }

    public void Pausegame()
    {
        Time.timeScale = 0;
        GameManager.instance.music.Pause();
        pausePanel.SetActive(true);
    }

    public void Unpausegame()
    {
        Time.timeScale = 1;
        GameManager.instance.music.Play();
        pausePanel.SetActive(false);
    }
}
