using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMotor : MonoBehaviour {

    Rigidbody2D rb;
   // public GameObject bullet;
    //public Transform shootPos;
    public float movementSpeed;
    public float rotationSpeed;
    private bool shootTrigger;
    private bool moveTrigger;

    void Start()
    {
     rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        movementMotor(1, 1);


    }

    private void movementMotor(float horzInput, float vertInput)
    {
        rb.rotation -= horzInput * rotationSpeed * Time.deltaTime;
        rb.gravityScale = 2 - vertInput * 2;
        rb.mass = 6 - vertInput * 3;
        rb.AddForce(transform.right * movementSpeed * vertInput, ForceMode2D.Force);

    }
}
