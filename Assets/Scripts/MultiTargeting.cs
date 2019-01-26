using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiTargeting : Targeting
{
    private TargetingPredefined targetingPredefined;
    private TargetingWithRadius targetingWithRadius;

    public GameObject predefinedTarget;

    [TagSelector] public string[] tagFilterArray;

    public float radius = 5f;


    void Start()
    {
        targetingPredefined = gameObject.AddComponent<TargetingPredefined>();
        targetingWithRadius = gameObject.AddComponent<TargetingWithRadius>();

        targetingPredefined.isActive = false;
        targetingWithRadius.isActive = false;
    }

    private void Update()
    {
        targetingPredefined.predefinedTarget = predefinedTarget;
        targetingWithRadius.radius = radius;
        targetingWithRadius.tagFilterArray = tagFilterArray;
        base.Update();
    }

    public override GameObject getTarget()
    {
        var target = targetingWithRadius.getTarget();
        if (target)
        {
            return target;
        }

        return targetingPredefined.getTarget();
    }
    
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}