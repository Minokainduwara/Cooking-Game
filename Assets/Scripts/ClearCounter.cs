using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{

    [SerializeField]
    private Transform tomatoPrefab;

    [SerializeField]
    private Transform counterTop;
    public void Interact()
    {
        Debug.Log("Interact");
        //Instantiate(tomatoPrefab);
    }
}
