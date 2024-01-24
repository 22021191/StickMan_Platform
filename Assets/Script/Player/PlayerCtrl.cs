using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    None,
    Die,
    Appear,
    DisAppear
}
public class PlayerCtrl : MonoBehaviour
{
    public PlayerState state;
    public int hp;
    private PlayerMovement movement;
    public Animator anim;
    private string animName;

    void Start()
    {
        movement=gameObject.GetComponent<PlayerMovement>();
        anim=gameObject.GetComponent<Animator>();
        state = PlayerState.Appear;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void AnimationUpDate()
    {
        switch(state)
        {
            case PlayerState.None:
                _hepller.ChangeAnim(animName , anim , "None");
                break;
            case PlayerState.Appear:
                Appear();
                break;
            case PlayerState.DisAppear:
                DisAppear();
                break;
            case PlayerState.Die:
                _hepller.ChangeAnim(animName, anim, "Die");
                break;
            
        }
    }
    void Appear()
    {

    }
    void DisAppear()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.GetMask("Obstacle")) {
            if (hp > 1)
            {
                state = PlayerState.DisAppear;
            }
            else
            {
                state = PlayerState.Die;
            }
        }
    }

}
