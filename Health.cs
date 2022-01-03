using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private float health = 100;
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        Bullet damageGiver = other.GetComponent<Bullet>();

        if(other.tag == "Player Bullet" && this.tag == "Enemy") 
        {
            Debug.Log("E");
            health -= damageGiver.GetDamage();
            CheckForDeath();
        } 
        else if(other.tag == "Enemy Bullet" && this.tag == "Player") 
        {
            Debug.Log("E");
            health -= other.GetComponent<Bullet>().GetDamage();
            FindObjectOfType<HealthBar>().ReduceHealth(damageGiver.GetDamage());
            CheckForDeath();
        }
    }

    private void CheckForDeath() 
    {
        if(health <= 0) 
        {
            Destroy(gameObject);
        }
    }
}
