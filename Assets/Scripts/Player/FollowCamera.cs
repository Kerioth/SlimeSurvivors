using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] float interpolationFactor = 0.0f;
    [SerializeField] float zDistance = 10.0f;
    public GameObject target;

    public void SetTarget() => StartCoroutine(TargetPlayer());

    IEnumerator TargetPlayer()
    {
        yield return new WaitForSeconds(1f);
        target = GameObject.FindGameObjectWithTag("Player");
    }

    private void LateUpdate()
    {
        Interpolate(Time.deltaTime);
    }

    void Interpolate(float a_DeltaTime)
    {
        if (target == null) return;
        
        Vector3 diff = target.transform.position + Vector3.back * zDistance - transform.position;
        transform.position += diff * interpolationFactor * a_DeltaTime;
    }
}
