using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Wallet : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textAmount;
    [SerializeField]
    int coins = 200;
    public int Amount => coins;
    public static Wallet Instance;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        textAmount.text = coins.ToString();
    }
    public void Add(int amount) => coins += amount;
    public void Add() => coins++;
    public void Pay(int cost) => coins -= cost;
}
