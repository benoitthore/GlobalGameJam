using UnityEngine;

public class MoveTowardsTarget : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float stoppingDistance = 5f;
    public Vector2 startPosition = new Vector2(0, 0);
    public Targeting targeting;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (targeting != null)
        {
            var currentPosition = transform.position;
            var targetPosition = targeting.transform.position; // TODO: Use GetTarget()

            // As long as we are far enough, let's move
            if (Vector2.Distance(currentPosition, targetPosition) > stoppingDistance)
            {
                var step = movementSpeed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(currentPosition, targetPosition, step);
            }
            // If we are close, let's check if we are inside the collision
            else
            {
                //targeting.
                // TODO: OnCollide callback
            }
        }
    }


}