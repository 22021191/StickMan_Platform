using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class MovingPlatform :MonoBehaviour
{
    [SerializeField] private GameObject[] WayPoints;
    [SerializeField] private int currentPoint=0;
    [SerializeField] private float speed=2f;
    

    private void Start()
    {
        if(WayPoints.Length <= 0) {
            return;
        }
        transform.position = WayPoints[currentPoint].transform.position;
        if (currentPoint < WayPoints.Length-1&&currentPoint!=0)
        {
            currentPoint++;
        }
        else
        {
            currentPoint=0;
        }
    }

    private void Update()
    {
        if (Vector2.Distance(WayPoints[currentPoint].transform.position, transform.position) < 0.1) {
            currentPoint++;
            if(currentPoint>=WayPoints.Length)
            {
                currentPoint = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position,
            WayPoints[currentPoint].transform.position,
            Time.deltaTime*speed);
    }

    
    
   
}
