using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingPredefined : Targeting
{
    public GameObject predefinedTarget;
    
    
    public override GameObject getTarget()
    {
        return predefinedTarget;
    }
}