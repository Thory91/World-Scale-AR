using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailTap : MonoBehaviour
{
    public bool Canbepressed;
    public KeyCode keyCode;
    public Transform successhit;

    // Start is called before the first frame update
    void Start()
    {
        //position = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "Success1" || hit.transform.name == "Success2" || hit.transform.name == "Success3" || hit.transform.name == "Success4" || hit.transform.name == "Success5")
                {
                    if (Canbepressed)
                    {
                        gameObject.SetActive(false);
                        GameManager.instance.NoteHit();
                        Instantiate(successhit, transform.position, successhit.rotation);
                    }
                }
            }
        }
        
        //if(position.position.x == -1.135f)
        //{
        //    Input.GetKeyDown(KeyCode.Alpha1);
        //    if(Canbepressed)
        //    {
        //        gameObject.SetActive(false);
        //    }
        //}

        //if (position.position.x == -0.5699983f)
        //{
        //    Input.GetKeyDown(KeyCode.Alpha2);
        //    if (Canbepressed)
        //    {
        //        gameObject.SetActive(false);
        //    }
        //}
        //if (position.position.x == 0.005f)
        //{
        //    Input.GetKeyDown(KeyCode.Alpha3);
        //    if (Canbepressed)
        //    {
        //        gameObject.SetActive(false);
        //    }
        //}
        //if (position.position.x == 0.604f)
        //{
        //    Input.GetKeyDown(KeyCode.Alpha4);
        //    if (Canbepressed)
        //    {
        //        gameObject.SetActive(false);
        //    }
        //}
        //if (position.position.x == 1.234f)
        //{
        //    Input.GetKeyDown(KeyCode.Alpha5);
        //    if (Canbepressed)
        //    {
        //        gameObject.SetActive(false);
        //    }
        //}
        if (Input.GetKeyDown(keyCode) ||Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (Canbepressed)
            {
                gameObject.SetActive(false);
                GameManager.instance.NoteHit();
                Instantiate(successhit,transform.position,successhit.rotation);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Success1" || other.gameObject.name == "Success2" || other.gameObject.name == "Success3" || other.gameObject.name == "Success4" || other.gameObject.name == "Success5")
        {
            Canbepressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Success1" || other.gameObject.name == "Success2" || other.gameObject.name == "Success3" || other.gameObject.name == "Success4" || other.gameObject.name == "Success5")
        {
            Canbepressed = false;
            gameObject.SetActive(false);
            GameManager.instance.NoteMiss();
        }
    }
}
