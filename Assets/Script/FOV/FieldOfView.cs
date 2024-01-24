using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float Radius = 20;
    public float Angle = 90;
    Collider2D[] PlayerInRadius;
    public LayerMask obstacleMask,playerMask;
    
    public Vector2 DirFromAngle(float angle,bool global)
    {
        if(!global)
        {
            angle += transform.eulerAngles.z;
        }
        return new Vector2(Mathf.Cos(angle*Mathf.Deg2Rad),Mathf.Sin(angle*Mathf.Deg2Rad));
    }
   
   

}
