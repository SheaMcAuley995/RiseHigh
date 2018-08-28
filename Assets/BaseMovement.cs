using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMovement : MonoBehaviour {

    Camera cam;
    Rigidbody2D rb;
    public GameObject bullet;
    public Transform shootPos;
    public float movementSpeed;
    public float rotationSpeed;
    private bool shootTrigger;
    private bool moveTrigger;

	void Start () {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
	}
	

	void Update () {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            moveTrigger = true;
        }
        else if(Input.GetKey(KeyCode.W))
        {
            rb.gravityScale = 0;
            moveTrigger = true;
        }
        else
        {
            rb.gravityScale = 2;
            rb.mass = 6;
            moveTrigger = false;
        }
        if (Input.GetMouseButton(0))
        {
           shootTrigger = true;
        }
        else
        {
            shootTrigger = false;
        }
        
	}

    private void FixedUpdate()
    {

        //float camDis = cam.transform.position.y - transform.position.y;

        // Vector3 mouse = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camDis));

        //float angleRad = Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x);
        //float angle = (180 / Mathf.PI) * angleRad;

        if (moveTrigger)
        {
            rb.rotation -= Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
            //rb.rotation = Quaternion.Slerp(, angle, rotationSpeed * Time.deltaTime);
            rb.gravityScale = 2 - (Input.GetAxis("Vertical") * 2);
            rb.mass = 6 - (Input.GetAxis("Vertical") * 3);
            rb.AddForce(transform.right * movementSpeed * Mathf.Abs(Input.GetAxis("Vertical")), ForceMode2D.Force);
            //rb.AddForce(-transform.up * movementSpeed / 3 * Input.GetAxis("Horizontal"), ForceMode2D.Force);
        }


        if (shootTrigger)
        {
            GameObject Bullet = Instantiate(bullet, shootPos.position, shootPos.rotation);
            Bullet.GetComponent<Rigidbody2D>().velocity = rb.velocity;
        }
    }
}
