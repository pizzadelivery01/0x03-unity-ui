using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody body;
    private Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        body = this.GetComponent<Rigidbody> ();
        speed = 50.0F;
    }
    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
    }
    // FixedUpdate is called once per fixed framerate frame
    void FixedUpdate()
    {
       movePlayer(movement);
    }
    void movePlayer(Vector3 direction)
    {
        body.AddForce(direction * speed);
    }
}
