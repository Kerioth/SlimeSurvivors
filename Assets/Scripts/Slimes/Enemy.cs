using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public static List<Enemy> slimeList = new List<Enemy>();

    public static Enemy GetClosest(Vector3 position, float range)
    {
        Enemy closest = null;
        foreach (Enemy slime in slimeList)
        {
            if (Vector3.Distance(position, slime.GetPosition()) <= range)
            {
                if (closest == null) closest = slime;
                else
                {
                    if (Vector3.Distance(position, slime.GetPosition()) < Vector3.Distance(position, closest.GetPosition()))
                        closest = slime;
                }
            }
        }
        return closest;
    }

    public Vector3 GetPosition() => transform.position;
}
