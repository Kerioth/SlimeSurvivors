using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
  
    public static List<Tower> towerList = new List<Tower>();

    protected virtual void Death()
    {
        Destroy(gameObject);
    }

    public static Tower GetClosest(Vector3 position, float range)
    {
        Tower closest = null;
        foreach (Tower tower in towerList)
        {
            if (Vector3.Distance(position, tower.GetPosition()) <= range)
            {
                if (closest == null) closest = tower;
                else
                {
                    if (Vector3.Distance(position, tower.GetPosition()) < Vector3.Distance(position, closest.GetPosition()))
                        closest = tower;
                }
            }
        }
        return closest;
    }

    public Vector3 GetPosition() => transform.position;
}
