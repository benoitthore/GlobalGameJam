using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public float radius;
    public float rotationSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var isTargeting = false;
        var inCircleList = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (var obj in inCircleList)
        {
            Debug.Log("Overlapping" + obj.name);
            var target = obj.gameObject.GetComponent<TurretTarget>();

            if (target)
            {
                isTargeting = true;
                Vector2 from = transform.position;
                Vector2 to = target.transform.position;
                var direction = new Vector2(from.x - to.x, from.y - to.y);

                from = transform.transform.up;
                to = -direction;

                transform.transform.up = Vector2.Lerp(from, to, Time.deltaTime * rotationSpeed);
            }

            
        }

        if (!isTargeting)
        {
            resetRotation();
        }
    }

    private void resetRotation()
    {
        var from = transform.transform.up;
        var to = Vector2.up;
        transform.transform.up = Vector2.Lerp(from, to, Time.deltaTime * rotationSpeed);
    }

    private void OnDrawGizmos()
//    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}