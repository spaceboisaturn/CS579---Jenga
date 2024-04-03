using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMovement : MonoBehaviour
{
    public float rollSpeed = 5f;
    public float moveSpeed = 5f;
    private Rigidbody rb;
    private bool onPlane = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!onPlane)
        {
            if(transform.position.y <= 0)
            {
                onPlane = true;
                rb.constraints = RigidbodyConstraints.None;
                rb.angularVelocity = Vector3.up * rollSpeed;
            }
        } else
        {
            Vector3 movement = new Vector3(1, 0, 0);
            rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
        }
    }
}
