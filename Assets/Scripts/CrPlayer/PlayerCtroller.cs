using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtroller : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator ani;
    [SerializeField] private CapsuleCollider2D capsuleCollider;
    [SerializeField] LayerMask jumpbleground;
    [SerializeField] private TrailRenderer trailRenderer;

    [SerializeField] private float directionx;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpheight;
    [SerializeField] private bool isjumping;
    [SerializeField] private bool isdoulejump;
    [SerializeField] private bool isDashing;
    [SerializeField] private bool canDash = true;
    [SerializeField] private float dashingPower = 24f;
    [SerializeField] private float dashingTime = 0.2f;
    [SerializeField] private float dashingCooldow = 1f;


    private enum MovementState
    {
        aniplayeridle,
        aniplayerrun,
        aniplayerJump,
        aniplayerDie
    }
    private MovementState movementState;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        trailRenderer = GetComponent<TrailRenderer>();
    }

    void Start()
    {
        trailRenderer.emitting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }
        directionx = Input.GetAxisRaw("Horizontal");
        

        StateAnimation();
        ChanegeDirction();
        jumping();


       
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
           
        }


    }
    private void FixedUpdate()
    {
        Move();
        if (isDashing)
        {
            return;
        }
    }

   
    private void ChanegeDirction()
    {
        if(directionx>0)
        {
            spriteRenderer.flipX = false;
        }
        if(directionx<0)
        {
            spriteRenderer.flipX = true;
        }
    }
    private void Move()
    {
        rb.velocity=new Vector2 (directionx * moveSpeed, rb.velocity.y);
    }
    private void StateAnimation()
    {
        if (directionx != 0) 
        {
            movementState = MovementState.aniplayerrun;
        }
        else
        {
            movementState = MovementState.aniplayeridle;
        }
        if(rb.velocity.y >0.1f)
        {
            movementState = MovementState.aniplayerJump;
        }
        ani.SetInteger("State", (int)movementState);
    }
    private void jumping()
    {

        if (Input.GetButtonDown("Jump"))
        {
            isjumping = true;
            
        }
        if (Input.GetButtonUp("Jump"))
        {
            isjumping = false;
        }
        if (isgrouder() && !isjumping)
        {
            isdoulejump = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (isgrouder() || isdoulejump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpheight);
                isdoulejump = !isdoulejump;
               
            }

        }
    }
    private bool isgrouder()//kiểm tra va chạm với nền đất
    {
        return Physics2D.BoxCast(capsuleCollider.bounds.center, capsuleCollider.bounds.size, 0f, Vector2.down, 0.1f, jumpbleground);
    }
    private IEnumerator Dash()
    {
        canDash = false;//khi nhân vật lướt,để nhân vật k lướt liên tục 2 lần
        isDashing = true;//chặn input khi nhân vật đang lướt
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0;//set trong lúc =0 để nhân vật dang nhảy mà lướt để khong bị rối
        rb.velocity = new Vector2(directionx * dashingPower, 0f);//khoản cách lướt của nhân vật
        trailRenderer.emitting = true;//hiển thị hướng về khi lướt
        yield return new WaitForSeconds(dashingTime);// khoản thời gian nhân vật lướt
        trailRenderer.emitting = false;//tat duong về khi lướt
        rb.gravityScale = originalGravity;//cho vật duy chuyển binh thường
        isDashing = false;// cho nhan vat di chuyen binh thuong
        yield return new WaitForSeconds(dashingCooldow); //thoi gian cho de luot lan tiep theo
        canDash = true;// cho nhan vat luot lan tiep theo
        Debug.Log("aaaa");
    }
}
