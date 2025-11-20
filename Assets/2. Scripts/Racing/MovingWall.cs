using UnityEditor;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    Transform WallTrans;
    public int maxPos=5;
    [Range(0f, 1f)] public float speed =0.5f;
    bool moveRight=true;
    void Awake()
    {
        WallTrans=GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        Vector3 moveDir=new Vector3(1,0,0);

        if (WallTrans.position.x >= maxPos)
        {
            moveRight=false;
        }
        else if (WallTrans.position.x<=-maxPos)
        {
            moveRight=true;
        }
        
        if (WallTrans.position.x < maxPos & moveRight)
        {
            WallTrans.Translate(moveDir*speed);
        }
        else if (WallTrans.position.x > -maxPos & !moveRight)
        {
            WallTrans.Translate(moveDir*speed*-1);
        }
    }
}
