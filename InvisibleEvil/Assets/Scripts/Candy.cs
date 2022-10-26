using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    private Collider candyCollider;
    private void Start()
    {
        candyCollider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            candyCollider.enabled = false;
            transform.position = new Vector3(0, -1000, 0);
        }
    }
}
