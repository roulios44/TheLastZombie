using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Zombie : MonoBehaviour
{
    private bool goRight = false;
    private bool goLeft = false;
    private bool goUp = false;
    private bool goDown = false;
    public float mass;
    public float speed = 200f;
    public Rigidbody2D body;
    Vector2 movement;
    private float lastDir;
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask ennemyLayer;
    public int damage = 20;
    void Start()
    {
        mass = body.mass;
    }

    void Update()
    {
        if (goLeft) movement.x = -1;
        else if (goRight) movement.x = 1;
        else movement.x = 0;
        if (goUp) movement.y = 1;
        else if (goDown) movement.y = -1;
        else movement.y = 0;

        animator.SetFloat("Horizontal",movement.x);
        animator.SetFloat("Vertical",movement.y);
        animator.SetFloat("Speed",movement.sqrMagnitude);
        animator.SetFloat("LastDir",lastDir);
    }

    void FixedUpdate()
    {
        body.MovePosition(body.position + movement * speed * Time.fixedDeltaTime);
    }
    void OnRight(InputValue val){
        if(val.Get<float>() == 0)goRight = false;
        else {
            goRight = true;
            lastDir = 4;
        }
    }
    
    void OnLeft(InputValue val){
        if(val.Get<float>() == 0)goLeft = false;
        else {
            goLeft = true;
            lastDir = 3;
        }
    }
    
    void OnUp(InputValue val){
        if(val.Get<float>() == 0)goUp = false;
        else {
            goUp = true;
            lastDir = 2;
        }
    }
    
    void OnDown(InputValue val){
        if(val.Get<float>() == 0)goDown = false;
        else {
            goDown = true;
            lastDir = 1;
        }
    }
    void OnAttack(InputValue val){
        if(val.Get<float>()==1){
            StopMoving();
            animator.SetTrigger("Attack");
            Collider2D[] hitEnnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange,ennemyLayer);
            foreach(Collider2D enemy in hitEnnemies){
                enemy.GetComponent<Enemy>().TakeDamage(this.damage);
            }
        }
    }

    void StopMoving(){
        goDown = false;
        goLeft = false;
        goRight = false;
        goUp = false;
    }

    void OnDrawGizmosSelected(){
        if(attackPoint == null)return;
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }
}