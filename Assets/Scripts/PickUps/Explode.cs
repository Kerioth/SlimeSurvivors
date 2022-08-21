using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    private void Start()
    {
        AudioManager.Instance.PlaySound("Hit");
    }
    public void Bang() => Destroy(gameObject);
}
