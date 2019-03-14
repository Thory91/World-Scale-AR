using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public float beattempo;
    public bool hasStarted;

    // Start is called before the first frame update
    void Start()
    {
        beattempo = beattempo / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            hasStarted = true;
        }
    }
}
