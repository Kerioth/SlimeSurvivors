using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemTower : MonoBehaviour
{
    [SerializeField]
    DragBuild drag;
    [SerializeField]
    Image plate;

    Wallet wallet;

    private void Start()
    {
        wallet = Wallet.Instance;
    }

    private void Update()
    {
        if (drag.cost > wallet.Amount)
        {
            drag.enabled = false;
            plate.color = Color.gray;
        }
        else
        {
            drag.enabled = true;
            plate.color = Color.cyan;
        }
    }
}
