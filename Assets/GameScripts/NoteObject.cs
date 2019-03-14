using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{

    public bool Canbepressed;

    public KeyCode keyCode;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyCode))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Activator" )
        {
            Canbepressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Activator")
        {
            Canbepressed = false;
        }
    }
}
