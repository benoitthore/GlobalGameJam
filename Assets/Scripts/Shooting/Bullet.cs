using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 100f;
    public float damage = 1000f;
    public string[] collideWith;
    
    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(Vector2.up) * speed;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (
            !GameController.isObjectFromTag(other.gameObject, collideWith) 
            || other.gameObject.GetComponent<Bullet>()
            )
        {
            return;
        }
        
        var health = other.gameObject.GetComponent<Health>();
        
        if (health)
        {
            health.takeDamage(damage);
        }
        
        Destroy(gameObject);
    }
}