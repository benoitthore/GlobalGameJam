using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveTowardsTarget : MonoBehaviour
{
    public float speed = 1f;
    public float stoppingDistance = 5f;

    public bool moveIfNoTarget = true;

    private Rigidbody2D rigidbody2D;
    private Targeting targeting;

    [Range(0, .3f)] public float movementSmoothing = 0.15f;
    private Vector2 velocity = Vector3.zero;

    private const float speedMultiplier = 100f;

    // Start is called before the first frame update

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        targeting = GetComponent<Targeting>();
    }

    // Update is called once per frame
    void Update()
    {
        var target = targeting.getTarget();

        if (!target && moveIfNoTarget)
        {
            move();
            return;
        }

        if (target && Vector2.Distance(transform.position, target.transform.position) > stoppingDistance)
        {
            move();
        }
        else
        {
            stop();
        }
    }

    private void move()
    {
        var move = speed * Time.fixedDeltaTime * speedMultiplier;

        Vector2 targetVelocity = Vector2.up * move;
        targetVelocity = transform.TransformDirection(targetVelocity);


        rigidbody2D.velocity = Vector2.SmoothDamp(rigidbody2D.velocity, targetVelocity, ref velocity,
            movementSmoothing);
    }

    private void stop()
    {
        Vector2 targetVelocity = Vector2.zero;
        rigidbody2D.velocity = Vector2.SmoothDamp(rigidbody2D.velocity, targetVelocity, ref velocity,
            movementSmoothing);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, stoppingDistance);
    }
}