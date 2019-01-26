using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*\
 TODO Review ARCHITECTURE for targeting, then refactor if not too much work
 */
public class EarthTargeting : TargetingWithRadius
{
    public override GameObject getTarget()
    {
        var target = base.getTarget();
        if (target)
        {
            return target;
        }

        return GameController.instance.earth;
    }
    
}
