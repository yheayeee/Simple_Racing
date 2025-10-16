using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform PlayerTransform;
    public Vector3 offset = new Vector3(0f, 1.5f, -3f);
    public float smoothSpeed = 0.2f;

    void LateUpdate()
    {
        if (PlayerTransform == null)
        {
            Debug.Log("No Target in PlayerTransform");
            return;
        }
        Vector3 desiredPosition = PlayerTransform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        // transform.LookAt(PlayerTransform);
    }

}