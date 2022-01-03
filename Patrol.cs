using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{

    [Header("Tuning : ")]
    [SerializeField] private float speed;

    [Header("Attached Transform position : ")]
    [SerializeField] private Transform moveSpot;

    [Header("Time Managing : ")]
    [SerializeField] private float startWaitTime;
    [SerializeField] private float minWaitTime;
    [SerializeField] private float maxWaitTime;

    [Header("Maximum and Minimum positions for moving : ")]
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float minY;
    [SerializeField] float maxY;

    private float waitTime;


    // Start is called before the first frame update
    void Start()
    {
        // Initializing waitTime as startWaitTime, in this case, 0 = 3.
        waitTime = startWaitTime;

        // Giving a random position to the moveSpot Game Object.
        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

    // Update is called once per frame
    void Update()
    {
        // Making the transform.position move towards moveSpot's position every frame at a certain speed
        transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);

        // If the transform.position has come close to the moveSpot ( a distance of 0.2f ),
        // Then start ticking down the waitTime and if the waitTime is above 0, then make the Movespots's position something else again
        // then change the waitTime something between min and max wait time.
        if(Vector2.Distance(transform.position, moveSpot.position) < 0.2f) 
        {
            if(waitTime <= 0) 
            {
                moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                waitTime = Random.Range(minWaitTime, maxWaitTime);
            }
            else 
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    
}
