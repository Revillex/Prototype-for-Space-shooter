using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private float timeBtwShots;
    [SerializeField] private float startTimeBtwShots;

    [SerializeField] private GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBtwShots <= 0) 
        {
           Instantiate(projectile, transform.position, Quaternion.identity);
           timeBtwShots = startTimeBtwShots;
        }
        else 
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
