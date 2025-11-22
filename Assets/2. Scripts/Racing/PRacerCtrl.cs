using System;
using UnityEngine;

public class PRacerCtrl : MonoBehaviour
{
    [Range(0f, 500f)] public float rollForce = 300f;
    [Range(0f, 50f)] public float jumpForce = 5f;
    [Range(0f, 50f)] public float maxSpeed = 15f; // 공의 최대 속도
    private Rigidbody RacerRig;
    private Transform RacerTr;
    bool canJump;
    bool IsPause = false;
    Vector3 Teleportor = new Vector3(0f,0.5f,-45f);

    void Awake()
    {
        RacerRig = GetComponent<Rigidbody>();
        RacerTr = GetComponent<Transform>();
        canJump = true;
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(h, 0, v);
        RacerRig.AddForce(movement*rollForce);

        Vector3 curspeed = new Vector3(RacerRig.linearVelocity.x,0,RacerRig.linearVelocity.z);

        if (curspeed.magnitude>maxSpeed)
        {
            curspeed = curspeed.normalized * maxSpeed;
            RacerRig.linearVelocity = new Vector3(curspeed.x, RacerRig.linearVelocity.y, curspeed.z);
        }

        if (canJump)
        {
            Jump();
        }

        if (RacerTr.position.y<-12)
        {
            Fall();
        }

        if (IsPause == true)
        {
            Time.timeScale = 0;
            IsPause=false;
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

    void Fall()
    {
        RacerRig.linearVelocity = new Vector3(0, 0, 0);
        RacerRig.angularVelocity = new Vector3(0, 0, 0);
        
        transform.position=Teleportor;
    }

    void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.tag == "Floor")
        {
            canJump = true;
        }
        if (collision.gameObject.tag == "EndLine")
        {
            RacerRig.linearVelocity = new Vector3(0, 0, 0);
            RacerRig.angularVelocity = new Vector3(0, 0, 0);
            transform.position=Teleportor;        
            Timer.EndGame();
            IsPause = true;
        }
    }
}