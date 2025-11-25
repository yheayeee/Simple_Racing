using UnityEditor;
using UnityEngine;

public class MovingWallReverse : MonoBehaviour
{
    Transform WallTrans;
    public int maxPos = -5;
    [Range(0f, 1f)] public float speed =0.2f;
    bool moveLeft = true;
    void Awake()
    {
        WallTrans=GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        Vector3 moveDir=new Vector3(-1,0,0);

        if (WallTrans.position.x <= maxPos)
        {
            moveLeft = false;
        }
        else if (WallTrans.position.x >= -maxPos)
        {
            moveLeft=true;
        }
        
        if (WallTrans.position.x > maxPos & moveLeft)
        {
            WallTrans.Translate(moveDir * speed);
        }
        else if (WallTrans.position.x < -maxPos & !moveLeft)
        {
            WallTrans.Translate(moveDir * speed * -1);
        }
    }
}
