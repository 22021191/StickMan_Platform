using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    [Header ("Dash Ghost")]
    public bool makeGhost;
    [SerializeField] private float timeLife;
    [SerializeField] private GameObject ghost;
    [SerializeField] private Color color;
    [SerializeField] private float ghostDelay;
    [SerializeField] private float ghostDelaySecond;
    void Start()
    {
       ghostDelaySecond= ghostDelay;
    }
   
    // Update is called once per frame
    public void MakeGhostRender()
    {
        if (!makeGhost)
        {
            return;
        }
        if (ghostDelaySecond > 0)
        {
            ghostDelaySecond -= Time.deltaTime;
        }
        else
        {
            GameObject curGhost = Instantiate(ghost, transform.position, transform.rotation);
            Sprite curSprite = GetComponent<SpriteRenderer>().sprite;
            curGhost.GetComponent<SpriteRenderer>().sprite = curSprite;
            curGhost.GetComponent<SpriteRenderer>().color = color;
            Destroy(curGhost, timeLife);
            ghostDelaySecond = ghostDelay;
        }
    } 
}
