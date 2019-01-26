using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public float radius;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var inCircleList = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (var obj in inCircleList)
        {
            Debug.Log("Overlapping" + obj.name);
            var target = obj.gameObject.GetComponent<TurretTarget>();

            if (target)
            {
                Vector2 from = transform.position;
                Vector2 to = target.transform.position;
                var direction = new Vector2(from.x - to.x, from.y - to.y);
                transform.transform.up = -direction;
            }
        }
    }

    private void OnDrawGizmos()
//    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}