using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrabStuff;

public class GameOverPanel : MonoBehaviour
{
    public void Restart() => Loader.Reload();
    public void MainMenu() => Loader.Load(0);
}
