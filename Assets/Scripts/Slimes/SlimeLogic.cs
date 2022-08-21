using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeLogic : Enemy
{
    public float speed = 0.5f;
    [SerializeField]
    GameObject[] contains;

    public float itemsOffset = 0.1f;

    public bool listSlime = true;

    public bool bulletProf = false;

    Transform target;
    Animator anim;

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("base").transform;
        anim = GetComponent<Animator>();
        if(listSlime)slimeList.Add(this);
    }

    private void FixedUpdate()
    {
        if(target)
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("pickup") || collision.CompareTag("enemy")) return;
        if(bulletProf && collision.CompareTag("explode")) return;
        speed = 0;
        anim.SetTrigger("Dead");
    }

    public void Death()
    {
        AudioManager.Instance.PlaySound("Dead");
        foreach (GameObject inner in contains)
        {
            Vector3 offset = Vector3.zero;
            if (itemsOffset > 0f) 
            offset = new Vector2(Random.Range(-itemsOffset, itemsOffset), Random.Range(-itemsOffset, itemsOffset));

            Instantiate(inner, transform.position + offset, Quaternion.identity);
        }
        if (listSlime) slimeList.Remove(this);
        Destroy(gameObject);
    }
}
