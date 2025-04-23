using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using URPGlitch.Runtime.AnalogGlitch;   
using URPGlitch.Runtime.DigitalGlitch;
using UnityEngine;

public class MemoryPickup : MonoBehaviour
{
    public GameObject exitDoor; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (exitDoor != null)
            {
                
                SpriteRenderer sr = exitDoor.GetComponent<SpriteRenderer>();
                Collider2D col = exitDoor.GetComponent<Collider2D>();
                Animator ani = exitDoor.GetComponent<Animator>();
                

                if (sr != null) sr.enabled = true;
                if (col != null) col.enabled = true;
                if (ani != null) ani.enabled = true;
            }

            Destroy(gameObject);
        }
    }
}
