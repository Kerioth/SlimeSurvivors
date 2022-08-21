using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseLogic : MonoBehaviour
{
    [SerializeField]
    int health = 100;
    int maxHP;
    [SerializeField]
    Image healthBar;

    [SerializeField]
    GameObject crystal;
    [SerializeField]
    GameObject burning;

    public static BaseLogic Instance;

    void Awake()
    {
        Instance = this;
        maxHP = health;
    }

    void Update()
    {
        healthBar.fillAmount = (float)health/maxHP;
        if (health <= 0) Death();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy")) Hit();
    }

    void Death()
    {
        //Debug.Log("Game over");
        crystal.SetActive(false);
        burning.SetActive(true);

        GameStates.Instance.Over();
        //Destroy(gameObject);
    }

    void ChangeHP(int change) => health += change;

    public void Hit() => ChangeHP(-1);
}
