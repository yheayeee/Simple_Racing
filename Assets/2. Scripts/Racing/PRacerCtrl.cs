using System;
using UnityEngine;

public class PRacerCtrl : MonoBehaviour
{
    [Range(0f, 500f)] public float rollForce = 300f;
    [Range(0f, 50f)] public float jumpForce = 5f;
    private Rigidbody RacerRig;
    public GameObject Teleportor;
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

        Vector3 movement = new Vector3(h, 0, v);
        RacerRig.AddForce(movement*rollForce);

        if (canJump)
        {
            Jump();
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            canJump = false;
            // RacerRig.linearVelocity = new Vector3(0, 0, 0);
            // RacerRig.angularVelocity = new Vector3(0, 0, 0);
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