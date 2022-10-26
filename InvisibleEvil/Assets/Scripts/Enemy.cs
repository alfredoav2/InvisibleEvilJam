using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float hp = 10;
    [SerializeField] protected float damage = 5;
    [SerializeField] protected string visibleTag;

    protected MeshRenderer mr;

    protected void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == visibleTag)
        {
            mr.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == visibleTag)
        {
            mr.enabled = false;
        }
    }

    public float GetDamage()
    {
        return damage;
    }
}
