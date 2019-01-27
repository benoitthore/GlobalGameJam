using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtTarget : MonoBehaviour
{
    public float shootingDistance = 7f;
    public GameObject bulletPrefab;
    public float shotsPerSecond = 1f;

    private bool canShoot = true;

    private TargetingWithRadius targeting;

    private void Start()
    {
        targeting = GetComponent<TargetingWithRadius>();
    }

   

    private void Update()
    {
        
        var target = targeting.getTarget();
        if (target
            && canShoot
            && Vector2.Distance(target.transform.position, transform.position) < shootingDistance
            && targeting.isPointingAtTarget()
        )
        {
            shoot(target.transform);
        }
    }

    void shoot(Transform target)
    {
        Vector2 from = transform.position;
        Vector2 to = target.transform.position;
        var direction = new Vector2(from.x - to.x, from.y - to.y);


        var bullet = Instantiate(bulletPrefab, from, transform.rotation);
        bullet.GetComponent<Bullet>().collideWith = targeting.getTargetTags();
        bullet.transform.up = -direction;

        StartCoroutine(lockShotWithDelay());
    }

    private IEnumerator lockShotWithDelay()
    {
        canShoot = false;
        yield return new WaitForSeconds(1f / shotsPerSecond);
        canShoot = true;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shootingDistance);
    }
}