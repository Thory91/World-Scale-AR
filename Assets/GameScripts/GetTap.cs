using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTap : MonoBehaviour
{
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
            GetComponent<Rigidbody>().position = new Vector3(-1.127f, 0.48f, -8.25f);

            StartCoroutine(Revert());
        }
    }

    IEnumerator Revert()
    {
        yield return new WaitForSeconds(0.75f);
        GetComponent<Rigidbody>().position = new Vector3(-1.127f, 0.48f, -13.25f);
        //yield return new WaitForSeconds(0.75f);
        //GetComponent<Rigidbody>().position = new Vector3(-1.127f, 0.48f, -8.25f);
    }
}
