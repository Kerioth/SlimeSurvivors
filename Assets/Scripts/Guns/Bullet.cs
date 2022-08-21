using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrabStuff;

public class Bullet : MonoBehaviour
{
    public GameObject explode;
    public float speed = 5f;
    public Vector2 target;

    void FixedUpdate()
    {
        Vector2 position = transform.position;
        if (target != null)
        {
            transform.position = Vector2.MoveTowards(position, target, speed * Time.fixedDeltaTime);
            Vector3 dir = (target - position).normalized;
            transform.eulerAngles = new Vector3(0, 0, Angle.GetFromVector(dir));
        }
          


        if (position == target)
        {
            Instantiate(explode, position, Quaternion.identity);
            Destroy(gameObject);
        }
            
    }
}
