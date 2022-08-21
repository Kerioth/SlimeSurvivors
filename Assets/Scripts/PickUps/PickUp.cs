using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    Transform player;
    float pickSpeed = 1.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.transform;
        }
    }

    private void FixedUpdate()
    {
        if (player)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, pickSpeed * Time.fixedDeltaTime);
            StartCoroutine(WaitPick());
        }
        
    }

    IEnumerator WaitPick()
    {
        yield return new WaitForSeconds(0.2f);
        Pick();
    }

    protected virtual void Pick()
    {
        Destroy(gameObject);
    }
}
