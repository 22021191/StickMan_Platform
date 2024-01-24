using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D rb2d;
    private string animName;

    [Header("Layers Masks")]
    [SerializeField] private LayerMask _GroundLayerMask;

    [Header("Movement")]
    [SerializeField] private float Speed;
    [SerializeField] private bool _onGround;
    [SerializeField] private bool _onWall;
    [SerializeField] private float TimeDelay;
    [SerializeField] private bool isMove;
    [SerializeField] private bool isIdle;
    [SerializeField] private bool FaceRight = true;

    [Header("Check Collision Variable")]
    [SerializeField] private float wallLength;
    [SerializeField] private float GroundLength;
    [SerializeField] private Vector3 groundOffset;
    [SerializeField] private Vector3 wallOffset;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckCollision();
        UpdateAnimation();
        if (!_onGround || _onWall)
        {
            isMove = false;
        }
        else
        {
            isMove= true;
        }
    }
    private void FixedUpdate()
    {
        

        if (isIdle)
        {
            return;
        }

        if (isMove)
        {
            Movement();
        }
        else
        {
            isIdle = true;
            StartCoroutine(Idle());
        }

    }

    void UpdateAnimation()
    {
        anim.SetBool("Idle", isIdle);
        anim.SetBool("Walk", isMove);

    }

    IEnumerator Idle()
    {
        rb2d.velocity=Vector2.zero;
        yield return new WaitForSeconds(TimeDelay);
        Flip();
        
    }

    private void Movement()
    {
        if (!FaceRight)
        {
            rb2d.velocity = new Vector2(-Speed, 0);
        }

        else
        {
            rb2d.velocity = new Vector2(Speed, 0);

        }

    }
    private void Flip()
    {
        isMove = true;
        isIdle = false;
        FaceRight = !FaceRight;
        transform.Rotate(0f, 180f, 0f);
        wallOffset.x *= -1;
        groundOffset.x *= -1;
    }
    
    private void CheckCollision()
    {
        _onWall = Physics2D.OverlapCircle(transform.position + wallOffset, wallLength, _GroundLayerMask);
        _onGround = Physics2D.OverlapCircle(transform.position + groundOffset, GroundLength, _GroundLayerMask);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position + wallOffset, wallLength);
        Gizmos.DrawWireSphere(transform.position + groundOffset, GroundLength);
    }
}
