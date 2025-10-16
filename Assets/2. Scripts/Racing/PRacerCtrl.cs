using System;
using UnityEngine;

public class PRacerCtrl : MonoBehaviour
{
    [Range(0f, 500f)] public float speed = 300f;
    [Range(0f, 50f)] public float jumpForce = 5f;
    private Rigidbody RacerRig;
    bool canJump;

    void Awake()
    {
        RacerRig = GetComponent<Rigidbody>();
        canJump = true;
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 LocalDirection = new Vector3(h, 0f, v).normalized;
        Vector3 WorldDIrection = transform.TransformDirection(LocalDirection);

        Move(WorldDIrection);
        if (canJump)
        {
            Jump();
        }
    }

    void Move(Vector3 V)
    {
        RacerRig.AddForce(V * speed);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            canJump = false;
            RacerRig.linearVelocity = new Vector3(0, 0, 0);
            RacerRig.angularVelocity = new Vector3(0, 0, 0);
            RacerRig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.tag == "Floor")
        {
            canJump = true;
        }
    }
}