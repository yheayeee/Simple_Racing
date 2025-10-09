using UnityEngine;

public class PRacerCtrl : MonoBehaviour
{
    public float speed = 30f;
    public float maxAngle = 40f;
    public float turnspeed = 5f;
    private Rigidbody RacerRig;
    Vector3 MoveDir;
    private float initYRot;

    void Awake()
    {
        RacerRig = GetComponent<Rigidbody>();
        float initYRot = transform.localEulerAngles.y;
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Move(h, v);
        Debug.DrawRay(transform.position, MoveDir * 5f, Color.red);
    }

    void Move(float h, float v)
    {
        MoveDir = transform.forward;
        RacerRig.MovePosition(transform.position + MoveDir * v * speed * Time.deltaTime);
        transform.Rotate(0, h * speed * Time.deltaTime, 0, Space.Self);
    }
}