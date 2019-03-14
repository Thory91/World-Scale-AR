using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void RestartGame()
    {
        Time.timeScale = 1;
        GameManager.instance.tilenum = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }
}
