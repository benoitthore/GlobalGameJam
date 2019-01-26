using System.Collections;
using UnityEngine;

public class MoveTowardsTarget : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float stoppingDistance = 5f;
    private Rigidbody2D rigidbody2D;
    private Targeting targeting;
    
    // Start is called before the first frame update

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        targeting = GetComponent<Targeting>();
    }

    // Update is called once per frame
    void Update()
    {
//        var step = Vector2.up * movementSpeed * Time.deltaTime;
//       
//        
//        var currentPosition = transform.position;
//        var target = targeting.getTarget();
//
//        if (target)
//        {
//            var targetPosition = target.transform.position;
//
//            // As long as we are far enough, let's move
//            if (Vector2.Distance(currentPosition, targetPosition) > stoppingDistance)
//            {
//                transform.Translate(step);
//            }
//        }
//        else
//        {
//            transform.Translate(Vector2.up);
//        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, stoppingDistance);
    }
}