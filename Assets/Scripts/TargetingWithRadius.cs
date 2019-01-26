using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingWithRadius : Targeting
{
    [TagSelector] public string[] tagFilterArray;
    
    public float radius = 5f;


    public override GameObject getTarget()
    {
        var inCircleList = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (var obj in inCircleList)
        {
            if (isValidTarget(obj.gameObject))
            {
                return obj.gameObject;
            }
        }

        return null;
    }

    private bool isValidTarget(GameObject gameObject)
    {
        foreach (var _tag in tagFilterArray)
        {
            if (gameObject.CompareTag(_tag))
            {
                return true;
            }
        }

        return false;
    }


//    private void OnDrawGizmos()
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}