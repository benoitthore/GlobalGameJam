using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Targeting : MonoBehaviour
{
    public float rotationSpeed = 1f;
    public bool resetRotationWhenNoTarget = false;
    public bool isActive = true;

    public bool isPointingAtTarget()
    {
        var target = getTarget();
        if (target)
        {
            Vector3 lookDir = target.transform.position - transform.position;
 
            Vector3 myDir = transform.up;
 
            float myAngle = Vector3.Angle(myDir, lookDir);
 
            
            if (myAngle < 5.0f)
            {
                return true;
            }
        }

        
        return false;
    }

    public abstract GameObject getTarget();


    public void Update()
    {
        if (!isActive)
        {
            return;
        }
        
        var target = getTarget();
        isPointingAtTarget();

        if (target)
        {
            aimAt(target.transform);
        }
        else if(resetRotationWhenNoTarget)
        {
            resetRotation();
        }
    }

    protected void aimAt(Transform target)
    {
        Vector2 from = transform.position;
        Vector2 to = target.position;
        var direction = new Vector2(from.x - to.x, from.y - to.y);

        from = transform.transform.up;
        to = -direction;

        transform.transform.up = Vector2.Lerp(from, to, Time.deltaTime * rotationSpeed);
    }


    private void resetRotation()
    {
        var from = transform.transform.up;
        var to = Vector2.up;
        transform.transform.up = Vector2.Lerp(from, to, Time.deltaTime * rotationSpeed);
    }
}