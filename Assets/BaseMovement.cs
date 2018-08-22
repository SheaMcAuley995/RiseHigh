using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMovement : MonoBehaviour {

    Camera cam;
    Rigidbody2D rb;
    public GameObject bullet;
    public Transform shootPos;
    public float movementSpeed;

	void Start () {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
	}
	

	void Update () {

        float camDis = cam.transform.position.y - transform.position.y;

        Vector3 mouse = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camDis));

        float angleRad = Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x);
        float angle = (180 / Mathf.PI) * angleRad;

        rb.rotation = angle;

        if(Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.right * movementSpeed,ForceMode2D.Force);
        }
        if(Input.GetMouseButton(0))
        {
            Instantiate(bullet,shootPos.position, shootPos.rotation);
        }
        
	}
}
