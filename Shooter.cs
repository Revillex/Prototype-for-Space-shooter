using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [Header("Other GameObjects")]
    [SerializeField] private GameObject bullet;

    [Header("Variables for Tuning")]
    [SerializeField] private float xMoveAmount;
    [SerializeField] private float yMoveAmount;
    [SerializeField] private float bulletSpeed;

    [Header("Observational ONLY")]
    [SerializeField] private float xTotal;
    [SerializeField] private float yTotal;
    private Transform spawnerPosition;

    // Start is called before the first frame update
    void Start()
    {
       spawnerPosition = this.transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shoot();
    }

    private void Move() 
    {
        // Making the xTotal and yTotal

        /*
        xTotal = the tuning amount 
        TIMES

        the amount we get from GetAxis("Horizontal") as this gives a value from -1 - 1 depending on if we press

        A or D or LeftArrowKey or RightArrowKey 

        TIMES 

        the time between frames to make the movement frame rate independent.


        practically the same for yTotal
        */
        xTotal = xMoveAmount * Input.GetAxis("Horizontal") * Time.deltaTime;
        yTotal = yMoveAmount * Input.GetAxis("Vertical") * Time.deltaTime;
        transform.Translate(new Vector3(xTotal, yTotal, 0));
    }

    private void Shoot()
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            Rigidbody2D bulletRB;
            GameObject bulletObject = Instantiate(bullet, transform.GetChild(0).position, Quaternion.identity);
            //bulletObject.transform.parent = gameObject.transform;
            bulletRB = bulletObject.GetComponent<Rigidbody2D>();
            
            bulletRB.velocity = new Vector3(0, bulletSpeed, 0);
        }
    }
}
