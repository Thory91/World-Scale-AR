using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleInfo : MonoBehaviour
{
    public GameObject infopanel;

    // Start is called before the first frame update

    public void openInfo()
    {
        infopanel.SetActive(true);
    }

    public void closeinfo()
    {
        infopanel.SetActive(false);
    }

}
