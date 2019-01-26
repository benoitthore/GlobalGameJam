using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAtTarget : MonoBehaviour
{
    public float shootingDistance = 7f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float shotsPerSecond = 1f;

    private bool canShoot = true;

    public bool isPlayerObject;


    private void Awake()
    {
        if (isPlayerObject)
        {
            bulletPrefab.GetComponent<Bullet>().collideWith = GameController.instance.tagEnemyFilter;
        }
        else
        {
            bulletPrefab.GetComponent<Bullet>().collideWith = GameController.instance.tagPlayerFilter;
        }
    }

    private void Start()
    {
        if (!firePoint)
        {
            firePoint = transform;
        }
    }

    private void Update()
    {
        var targeting = GetComponent<Targeting>();
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
        Vector2 from = firePoint.position;
        Vector2 to = target.transform.position;
        var direction = new Vector2(from.x - to.x, from.y - to.y);


        var bullet = Instantiate(bulletPrefab, from, firePoint.transform.rotation, transform);
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