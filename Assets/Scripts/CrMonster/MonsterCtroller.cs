using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCtroller : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator ani;
    
    [SerializeField] public Transform pointa;
    [SerializeField] public Transform pointb;
    [SerializeField] public Transform player;
    [SerializeField] private Transform targetPoint;
    [SerializeField] public float speed;
    [SerializeField] public int rd=0;
    [SerializeField] public bool isChasing=false;
   




    private enum MovementState
    {
        aniMonsteridle,
        aniMonsterrun,
        aniMonsterAttack1,
        aniMonsterAttack2,
        aniMonsterStun,
        
    }
    private MovementState movementState;


    private void Start()
    {

      
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        ani.SetInteger("State", (int)movementState);
        targetPoint = pointa; // Bắt đầu với điểm A
       
        
    }
    private void FixedUpdate()
    {

        if (targetInside() == false)
        {

            MoveMonster();
        }
        else
        {
            MovePlayer();
            //InvokeRepeating("AttackPlayer", 1.5f, 2f);
            AttackPlayer();
        }
    }

    private void Update()
    {


       

    }
   private void MoveMonster()
   {
        
       
        // Di chuyển quái vật
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

        //animation
        movementState = MovementState.aniMonsterrun;
        ani.SetInteger("State", (int)movementState);

        // Quay mặt quái vật khi đổi hướng
        if (transform.position.x < targetPoint.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1); // Quay mặt về hướng trái
            //spriteRenderer.flipX = false;
        }
        else if (transform.position.x > targetPoint.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Quay mặt về hướng phải
            //spriteRenderer.flipX = true;
        }

        // Kiểm tra nếu quái vật đã đến điểm đích
        if (Vector2.Distance(transform.position, targetPoint.position) < 0.5f )
        {
            // Đổi hướng và chọn điểm đến mới
            if (targetPoint == pointa)
            {
                targetPoint = pointb;
            }
            else
            {
                targetPoint = pointa;
            }
        }
       
   }
   private void MovePlayer()
   {
        if (Vector3.Distance(transform.position, player.position) > 0.001f)
        {
            // Di chuyển tới player
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed *(float) 1.5 * Time.deltaTime);
           

        }
        else
        {
            transform.position = Vector2.zero;
        }

        //animation
        movementState = MovementState.aniMonsterrun;
        ani.SetInteger("State", (int)movementState);
        // Quay mặt quái vật khi đổi hướng
        if (transform.position.x < player.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1); // Quay mặt về hướng trái

        }
        else if (transform.position.x > player.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Quay mặt về hướng phải

        }
        
          
       
    }
    private bool targetInside()
    {
        if(pointa.position.x<= player.position.x &&player.position.x<=pointb.position.x)
        {
            return true;
        }
        return false;
    }
    private void AttackPlayer()
    {
        if (isChasing == true)
        {
            //animation

            //if (rd == 0)
            //{
            //    movementState = MovementState.aniMonsterAttack1;
            //    rd ++;
            //}
            //else
            //{
            //    movementState = MovementState.aniMonsterAttack2;
            //    rd --;
            //}
            movementState = MovementState.aniMonsterAttack1;
            ani.SetInteger("State", (int)movementState);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isChasing = true;
           
            Debug.Log("chạm player");

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isChasing = false;
            Debug.Log("out");
        }
    }
}
