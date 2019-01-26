﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingWithRadius : Targeting
{
    [TagSelector] public string[] tagFilterArray;

    public float radius = 5f;

    protected GameObject lastTarget;

    public override GameObject getTarget()
    {
        var inCircleList = Physics2D.OverlapCircleAll(transform.position, radius);
        var possibleTargets = new List<GameObject>();
        foreach (var obj in inCircleList)
        {
            if (isValidTarget(obj.gameObject))
            {
                possibleTargets.Add(obj.gameObject);
            }
        }

        GameObject returnedTarget = null;
        if (possibleTargets.Contains(lastTarget))
        {
            returnedTarget = lastTarget;
        }
        else if (possibleTargets.Count > 0)
        {
            returnedTarget = findSmallestRotation(possibleTargets);
        }

        lastTarget = returnedTarget;
        return returnedTarget;
    }

    private GameObject findSmallestRotation(List<GameObject> possibleTargets)
    {
        GameObject currTarget = null;
        var smallestAngle = 10000000f;
        foreach (var target in possibleTargets)
        {
            Vector3 lookDir = target.transform.position - transform.position;
 
            Vector3 myDir = transform.up;

            if (smallestAngle > Vector3.Angle(myDir, lookDir))
            {
                currTarget = target;
            }
        }

        return currTarget;
    }

    private bool isValidTarget(GameObject gameObject)
    {
        return GameController.isObjectFromTag(gameObject, tagFilterArray);
    }


//    private void OnDrawGizmos()
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}