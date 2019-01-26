using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
   [SerializeField] private float health = 100f;
   public GameObject deathEffect;

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
         Instantiate(deathEffect);
      }
      Destroy(gameObject);
   }
}