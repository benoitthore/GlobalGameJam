using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Targeting : MonoBehaviour
{
    public float rotationSpeed = 1f;
    
    public bool isPoitingAtTarget()
    {
        return false;
    }

    public abstract GameObject getTarget();  



    private void Update()
    {
        var target = getTarget();

        if (target)
        {
            aimAt(target.transform);
        }
        else
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