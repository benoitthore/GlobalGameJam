using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiTargeting : Targeting
{
    private TargetingPredefined targetingPredefined;
    private TargetingWithRadius targetingWithRadius;

    private void Start()
    {
        targetingPredefined = gameObject.AddComponent<TargetingPredefined>();
        targetingWithRadius = gameObject.AddComponent<TargetingWithRadius>();

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
}