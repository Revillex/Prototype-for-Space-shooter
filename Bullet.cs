using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    [SerializeField] private float moveSpeed;
    [Range(1, 100)] [SerializeField] private int damage;

    void Update()
    {
        transform.Translate(new Vector3(0, moveSpeed * Time.deltaTime, 0));
    }

    public int GetDamage() 
    {
        return damage;
    }
}
