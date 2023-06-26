using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCtroller : MonoBehaviour
{
    public DameEnemy d;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator ani;

    [SerializeField] public Transform pointa;
    [SerializeField] public Transform pointb;
    [SerializeField] public Transform player;
    [SerializeField] private Transform targetPoint;
    [SerializeField] public float speed;
    [SerializeField] public int rd = 0;
    [SerializeField] public bool isAttack = false;
    [SerializeField] public GameObject HBOutEnemy;
    //private DameEnemy enemy;
    public LayerMask layerMask;
    public Transform attatckPosition;
    public float radius;

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

        d=GetComponent<DameEnemy>();
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        ani.SetInteger("State", (int)movementState);
        targetPoint = pointa; // Bắt đầu với điểm A
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }
    private void Update()
    {
        //isAttack = enemyIsAttack.isAttack;
    }
    private void FixedUpdate()
    {

        if (targetInside() == false)
        {
            MoveMonster();
        }
        else
        {
            ChasePlayer();
        }

        if (isAttack)
        {
            UpdataAttackAnimation();
        }
    }

    private void MoveMonster()
    {
        //Debug.Log("Move");
        if (isAttack) return;
        // Di chuyển quái vật
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

        //animation
        movementState = MovementState.aniMonsterrun;
        ani.SetInteger("State", (int)movementState);

        // Quay mặt quái vật khi đổi hướng
        if (transform.position.x < targetPoint.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Quay mặt về hướng trái
            HBOutEnemy.transform.localScale = new Vector3(-1, 1, 1);
            //spriteRenderer.flipX = false;
        }
        else if (transform.position.x > targetPoint.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1); // Quay mặt về hướng phải
            HBOutEnemy.transform.localScale = new Vector3(1, 1, 1);
            //spriteRenderer.flipX = true;
        }

        // Kiểm tra nếu quái vật đã đến điểm đích
        if (Vector2.Distance(transform.position, targetPoint.position) < 0.5f)
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
    private void ChasePlayer()
    {
        if (isAttack) return;
        //Debug.Log("Chase");
        if (Vector3.Distance(transform.position, player.position) > 1.5f)
        {
            // Di chuyển tới player
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * (float)1.5 * Time.deltaTime);
            //animation
            movementState = MovementState.aniMonsterrun;
            ani.SetInteger("State", (int)movementState);
            // Quay mặt quái vật khi đổi hướng
            if (transform.position.x < player.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1); // Quay mặt về hướng trái
                HBOutEnemy.transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (transform.position.x > player.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1); // Quay mặt về hướng phải
                HBOutEnemy.transform.localScale = new Vector3(1, 1, 1);
            }

        }
    }
    private bool targetInside()
    {
        if (pointa.position.x <= player.position.x && player.position.x <= pointb.position.x)
        {
            return true;
        }
        return false;
    }

    private void UpdataAttackAnimation()
    {
        movementState = MovementState.aniMonsterAttack1;
        ani.SetInteger("State", (int)movementState);
    }
    private void AttackPlayer()
    {
        Collider2D collider = Physics2D.OverlapCircle(attatckPosition.position, radius, layerMask);
        if (collider != null)
        {
            DamePlayer dame = collider.gameObject.GetComponent<DamePlayer>();
            if (dame != null)
            {
                //dame.TakeDamePlayer(DameEnemy.Instance.currenDameEnemy);
                dame.TakeDamePlayer(d.currenDameEnemy);
            }
            PopupDamage uIManager = collider.gameObject.GetComponent<PopupDamage>();
            if (uIManager != null)
            {

                //uIManager.PlayerTookDanage(DamePlayer.instance.damePlayer);
                //uIManager.PlayerTookDanage(DameEnemy.Instance.currenDameEnemy);
                uIManager.PlayerTookDanage(d.currenDameEnemy);
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isAttack = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isAttack = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attatckPosition.position, radius);
    }
}
