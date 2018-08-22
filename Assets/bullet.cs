using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    Rigidbody2D rb;
    private float movementSpeed = 45;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	void Update () {
        rb.AddForce(transform.right * movementSpeed, ForceMode2D.Force);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
}
