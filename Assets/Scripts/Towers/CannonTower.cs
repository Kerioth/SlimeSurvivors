using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CrabStuff;

public class CannonTower : Tower
{
    [SerializeField]
    GameObject bullet;
    Vector3 shootPosition;

    public float range = 5f;
    [SerializeField]
    Transform circle;

    public float shootTime = 0.5f;
    float shootTimer = 0;

    [SerializeField]
    Image healthBar;

    [SerializeField]
    int health = 10;
    int maxHealth;

    [SerializeField]
    Animator anim;

    bool canHit = false;
    bool canShot = true;

    void Awake()
    {
        shootPosition = transform.Find("ShootFrom").position;
        //Tower.towerList.Add(this);
    }

    private void Start()
    {
        float scale = range * 0.4f;
        //circle.localScale = new Vector3(scale, scale, 1);

        maxHealth = health;
        StartCoroutine(StartInvise());
    }

    IEnumerator StartInvise()
    {
        yield return new WaitForSeconds(0.5f);
        canHit = true;
    }

    // Update is called once per frame
    void Update()
    {
        shootTimer += Time.deltaTime;
        if(shootTimer >= shootTime && canShot)
        {
            Enemy target = GetClosestEnemy();
            if (target != null) Shoot(target.GetPosition());

            shootTimer = 0;
        }

        healthBar.fillAmount = (float)health/maxHealth;
        if (health <= 0) Death();

        canShot = GameStates.Instance.isPlay;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy") && canHit) Hit();
    }

    void ChangeHP(int change) => health += change;

    public void Hit() => ChangeHP(-1);

    void Shoot(Vector2 target)
    {
        Vector2 dir = target - new Vector2(transform.position.x, transform.position.y);
        anim.SetFloat("x", dir.x);
        anim.SetFloat("y", dir.y);
        GameObject gunshot = Instantiate(bullet, shootPosition, Quaternion.identity);
        gunshot.GetComponent<Bullet>().target = target;

        AudioManager.Instance.PlaySound("Shot");
    }

    private Enemy GetClosestEnemy()
    {
        return Enemy.GetClosest(transform.position, range);
    }
}
