using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchSprite : MonoBehaviour
{
    public void OnMouseDown()
    {
        SceneManager.LoadScene("Song1");
    }
}
