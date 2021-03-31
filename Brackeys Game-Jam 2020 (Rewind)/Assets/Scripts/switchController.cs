using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class switchController : MonoBehaviour
{

    Animator anim;
    public GameObject stoneGate;

    public void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            anim.SetBool("Player", true);
            Debug.Log("Trigger Switch");
        }
    }

    public void OpenGate()
    {
        Destroy(stoneGate);    
    }

}
