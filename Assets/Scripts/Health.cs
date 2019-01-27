using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
   [SerializeField] private float health = 100f;
   private float maxHealth;
   public GameObject deathEffect;

   public float getHealth()
   {
      return health;
   }
   
   public float getMaxHealth()
   {
      return maxHealth;
   }

   private void Start()
   {
      maxHealth = health;
   }

   public void takeDamage(float damage)
   {
      health -= damage;
      if (health <= 0)
      {
         die();
      }
   }



   private void die()
   {
      if (deathEffect)
      {
         Instantiate(deathEffect,transform.position,transform.rotation);
      }
      Destroy(gameObject);
   }
}