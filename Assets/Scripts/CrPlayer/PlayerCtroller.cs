using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtroller : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator ani;
    [SerializeField] private CapsuleCollider2D capsuleCollider;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] LayerMask jumpbleground;
    [SerializeField] private TrailRenderer trailRenderer;

    [SerializeField] public float directionx;
    [SerializeField] public float moveSpeed;
    [SerializeField] public float jumpheight;
    [SerializeField] public bool isjumping;
    [SerializeField] public bool isdoulejump;
    [SerializeField] public bool isDashing;
    [SerializeField] public bool canDash = true;
    [SerializeField] public float dashingPower = 10f;
    [SerializeField] public float dashingTime = 0.2f;
    [SerializeField] public float dashingCooldow = 1f;
    [SerializeField] public bool boolTrap = false;
    [SerializeField] public GameObject HBOut;
    public LayerMask layerMask;
    public Transform attatckPosition;
    public float radius;



    private enum MovementState
    {
        aniplayeridle,
        aniplayerrun,
        aniplayerJump,
        aniplayerAttack,
        aniplayerDizzy,
        aniplayerDash
    }
    private MovementState movementState;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        trailRenderer.emitting = false;
        //boxCollider.enabled = false;
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
        if (Input.GetMouseButton(0))
        {
            movementState = MovementState.aniplayerAttack;
            ani.SetInteger("State", (int)movementState);
           
            //boxCollider.enabled = true;
        }
        else
        {
            //boxCollider.enabled = false;
        }

    }
    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        Move();      
    }

   
    private void ChanegeDirction()
    {
        if(directionx>0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Quay mặt về hướng trái
            HBOut.transform.localScale = new Vector3(1, 1, 1);
        }
        if(directionx<0)
        {
            
            transform.localScale = new Vector3(-1, 1, 1); // Quay mặt về hướng trái
            HBOut.transform.localScale = new Vector3(-1, 1, 1);
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
        if(rb.velocity.y >0.1f || rb.velocity.y<-0.1)
        {
            movementState = MovementState.aniplayerJump;
        }
        if(boolTrap==true)
        {
            movementState = MovementState.aniplayerDizzy;
        }
        
        ani.SetInteger("State", (int)movementState);
    }
    private void jumping()
    {

        if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            isjumping = true;
            
        }
        if (Input.GetButtonUp("Jump") || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            isjumping = false;
        }
        if (isgrouder() && !isjumping)
        {
            isdoulejump = false;
        }

        if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
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


        //movementState = MovementState.aniplayerDash;//animation
        //ani.SetInteger("State", (int)movementState);


        if (transform.localScale.x== -1)
        {
            rb.velocity = new Vector2( -dashingPower, 0f);//khoản cách lướt của nhân vật
            Debug.Log("1");
        }
        else
        {
            rb.velocity = new Vector2(dashingPower, 0f);//khoản cách lướt của nhân vật
            Debug.Log("2");
        }
        //rb.velocity = new Vector2(directionx * dashingPower, 0f);//khoản cách lướt của nhân vật



        trailRenderer.emitting = true;//hiển thị hướng về khi lướt
        yield return new WaitForSeconds(dashingTime);// khoản thời gian nhân vật lướt
        trailRenderer.emitting = false;//tat duong về khi lướt
        rb.gravityScale = originalGravity;//cho vật duy chuyển binh thường
        isDashing = false;// cho nhan vat di chuyen binh thuong
        yield return new WaitForSeconds(dashingCooldow); //thoi gian cho de luot lan tiep theo
        canDash = true;// cho nhan vat luot lan tiep theo
        Debug.Log("aaaa");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Trap"))
        {
            boolTrap = true;
            Debug.Log("trap chạm player");
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            boolTrap = false;
            Debug.Log("out trap");
        }
    }

    private void AttackEnemy()
    {
        Collider2D collider = Physics2D.OverlapCircle(attatckPosition.position, radius, layerMask);
        if (collider != null)
        {
            DameEnemy dameEnemy = collider.gameObject.GetComponent<DameEnemy>();
            if(dameEnemy != null)
            {
                dameEnemy.TakeDameEnemy(DamePlayer.instance.damePlayer);
            }
            PopupDamage uIManager = collider.gameObject.GetComponent<PopupDamage>();
            if(uIManager != null)
            {
                uIManager.EnemyTookDanage(DamePlayer.instance.damePlayer);
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attatckPosition.position, radius);
    }
}
