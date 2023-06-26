using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using Unity.VisualScripting;

public class enemyGFX : MonoBehaviour
{
    public AIPath aiPath;
    [SerializeField] private bool checkBoss=false;
    [SerializeField] private Animator ani;
    [SerializeField] public GameObject HBOut;
    //private DameEnemy enemy;
    public LayerMask layerMask;
    public Transform attatckPosition;
    public float radius;


    private void Start()
    {
        ani = GetComponent<Animator>();
    }
    void Update()
    {
        if(aiPath.desiredVelocity.x>=0.01f)
        {
            transform.localScale=new Vector3(1f, 1f,1f);
            HBOut.transform.localScale = new Vector3(1, 1, 1);

        }
        else if(aiPath.desiredVelocity.x<=-0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            HBOut.transform.localScale = new Vector3(-1, 1, 1);
        }
        //if (checkBoss == true)
        //{
        //    InvokeRepeating("Attackdoi", 0f, 2f);
        //}

        //Attackdoi();

    }
    private void FixedUpdate()
    {
        if (checkBoss == true)
        {
            //InvokeRepeating("Attackdoi", 0f, 2f);
            Attackdoi();
        }
    }
    private enum MovementState
    {
        aniMonsteridle,
        aniMonsterrun,
        aniMonsterAttack1,
        aniMonsterAttack2,
        aniMonsterStun,

    }
    private MovementState movementState;

    private void Attackdoi()
    {
        if(checkBoss==true)
        {
            //animation
            movementState = MovementState.aniMonsterAttack2;
            ani.SetInteger("State", (int)movementState);
        }
        else
        {
            movementState = MovementState.aniMonsteridle;
            ani.SetInteger("State", (int)movementState);
        }
    }
    private void AttackPlayer()
    {
        Collider2D collider = Physics2D.OverlapCircle(attatckPosition.position, radius, layerMask);
        if (collider != null)
        {
            DamePlayer dame = collider.gameObject.GetComponent<DamePlayer>();
            if (dame != null)
            {
                dame.TakeDamePlayer(DameEnemy.Instance.currenDameEnemy);
            }
            PopupDamage uIManager = collider.gameObject.GetComponent<PopupDamage>();
            if (uIManager != null)
            {
                //uIManager.PlayerTookDanage(DamePlayer.instance.damePlayer);
                uIManager.PlayerTookDanage(DameEnemy.Instance.currenDameEnemy);
            }
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            checkBoss=true;
            Debug.Log("OnTriggerEnter2D dơi va chạm player");
           
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            checkBoss = false;
            Debug.Log("OnTriggerEnter2D out");
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attatckPosition.position, radius);
    }
}
