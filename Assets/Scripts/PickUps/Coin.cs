using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : PickUp
{
    public int value = 1;
    public float lifetime = 10f;
    private void Start()
    {
        StartCoroutine(Lifetime());
    }

    IEnumerator Lifetime()
    {
        yield return new WaitForSeconds(lifetime - 1f);
        GetComponent<Animator>().SetTrigger("End");
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    protected override void Pick()
    {
        Wallet.Instance.Add(value);
        AudioManager.Instance.PlaySound("Coin");
        base.Pick();
    }
}
