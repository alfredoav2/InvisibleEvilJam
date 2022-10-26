using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : Enemy
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float movementRange = 5;

    private int direction = 1;
    private float maxDistance;
    private float minDistance;
    private bool canChangeDirections = true;

    private void Awake()
    {
        maxDistance = transform.position.x + movementRange;
        minDistance = transform.position.x - movementRange;
    }

    private void Update()
    {
        if ((transform.position.x >= maxDistance || transform.position.x <= minDistance) && canChangeDirections)
        {
            direction *= -1;
            canChangeDirections = false;
            StartCoroutine(WaitToChangeDirections());
        }

        transform.position += new Vector3(direction * speed * Time.deltaTime, 0, 0);
    }

    private IEnumerator WaitToChangeDirections()
    {
        yield return new WaitForSeconds(0.1f);
        canChangeDirections = true;
    }
}
