using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialLogic : MonoBehaviour
{
    [SerializeField]
    GameObject phase1;
    [SerializeField]
    GameObject phase2;
    [SerializeField]
    GameObject phase3;

    [SerializeField]
    FollowCamera followCamera;

    [SerializeField]
    PlayerMovement player;

    [SerializeField]
    DragBuild dragBuild;

    int phase;

    void Start()
    {
        phase = 1;
    }

    void Update()
    {
        if (phase == 2 && player.isMove) Phase3();
        if (phase == 3 && dragBuild.isDrag) EndTutor();
    }

    public void Phase2()
    {
        phase1.SetActive(false);
        phase2.SetActive(true);
        phase++;
    }

    void Phase3()
    {
        phase2.SetActive(false);
        phase3.SetActive(true);
        phase++;
    }

    void EndTutor()
    {
        phase3.SetActive(false);
        phase++;

        followCamera.SetTarget();
        GameStates.Instance.StartPlay();
    }
}
