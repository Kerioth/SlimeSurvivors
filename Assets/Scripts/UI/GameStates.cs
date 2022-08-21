using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStates : MonoBehaviour
{
    [SerializeField]
    GameObject spawner;

    [SerializeField]
    FollowCamera followCamera;

    [SerializeField]
    GameObject gameOver;

    public static GameStates Instance;
    public enum State { Tutor, Play, Over}
    State state;

    public bool isPlay => state == State.Play;
    public void Over() => state = State.Over;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        state = State.Tutor;
        Enemy.slimeList.Clear();
    }

    public void StartPlay()
    {
        state = State.Play;
        spawner.SetActive(true);
    }

    void Update()
    {
        if(state == State.Over)
        {
            followCamera.target = transform.gameObject;
            gameOver.SetActive(true);
        }
    }
}
