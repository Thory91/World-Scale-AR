using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class ToggleScore : MonoBehaviour
{
    [SerializeField] public Text scoreText;
    [SerializeField] public GameObject menu;
    public static ToggleScore instance;

    public void Start()
    {
        instance = this;
        menu.SetActive(false);
    }
    public void Awake()
    {
        Assert.IsNotNull(scoreText);
    }

    public void togglemenu()
    {
        menu.SetActive(true);
    }
}
