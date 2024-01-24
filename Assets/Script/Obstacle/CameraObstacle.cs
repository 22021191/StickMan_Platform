using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraObstacle : MonoBehaviour
{
    [Header("Rotate")]
    [SerializeField] private float angularVelocity;
    [SerializeField] private float angleStart, angleEnd;
    [SerializeField] private float timeDelay;
    [SerializeField] private float curAngle;
    [SerializeField] private bool isIdle, canCircular;

    void Start()
    {
        transform.rotation = Quaternion.EulerAngles(new Vector3(0, 0, angleStart));
        curAngle = angleStart;
    }

    // Update is called once per frame
    void Update()
    {
        if(isIdle)
        {
            return;
        }
        if(canCircular)
        {
            RotateCamera();
        }
        else
        {
            isIdle = true;
            StartCoroutine(Idle());
        }
    }
    private void FixedUpdate()
    {
        if (curAngle<angleStart || curAngle>angleEnd)
        {
            canCircular= false;
            if(curAngle > angleEnd)
            {
                curAngle= angleEnd;
            }
            else
            {
                curAngle= angleStart;
            }
        }
    }
    private void RotateCamera()
    {
        curAngle += angularVelocity * Time.deltaTime ;
        transform.rotation=Quaternion.Euler(new Vector3(0,0,curAngle));
    }
    IEnumerator Idle()
    {
        yield return new WaitForSeconds(timeDelay);
        isIdle=false;
        canCircular=true;
        flipCamera();

    }
    void flipCamera()
    {
        angularVelocity *= -1;
    }
}
