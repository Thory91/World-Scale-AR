using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapScore : MonoBehaviour
{
    public Transform successhit;
    public void OnMouseDown()
    {
        gameObject.SetActive(false);
        Instantiate(successhit, transform.position, successhit.rotation);
    }
}
