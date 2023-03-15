using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class Zombie : MonoBehaviour
{
    private bool goRight = false;
    private bool goLeft = false;
    private bool goUp = false;
    private bool goDown = false;
    public float mass;
    public float speed = 1f;
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
        if (this.goLeft) this.movement.x = -1;
        else if (this.goRight) this.movement.x = 1;
        else this.movement.x = 0;
        if (this.goUp) this.movement.y = 1;
        else if (this.goDown) this.movement.y = -1;
        else this.movement.y = 0;

        this.animator.SetFloat("Horizontal", movement.x);
        this.animator.SetFloat("Vertical", movement.y);
        this.animator.SetFloat("Speed", movement.sqrMagnitude);
        this.animator.SetFloat("LastDir", lastDir);
    }

    void FixedUpdate()
    {
        body.MovePosition(body.position + movement * speed * Time.fixedDeltaTime);
    }
    void OnRight(InputValue val)
    {
        if (val.Get<float>() == 0) goRight = false;
        else
        {
            goRight = true;
            lastDir = 4;
        }
    }

    void OnLeft(InputValue val)
    {
        if (val.Get<float>() == 0) goLeft = false;
        else
        {
            goLeft = true;
            lastDir = 3;
        }
    }

    void OnUp(InputValue val)
    {
        if (val.Get<float>() == 0) goUp = false;
        else
        {
            goUp = true;
            lastDir = 2;
        }
    }

    void OnDown(InputValue val)
    {
        if (val.Get<float>() == 0) goDown = false;
        else
        {
            goDown = true;
            lastDir = 1;
        }
    }
    void OnAttack(InputValue val)
    {
        if (val.Get<float>() == 1)
        {
            StopMoving();
            animator.SetTrigger("Attack");
            Collider2D[] hitEnnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, ennemyLayer);
            foreach (Collider2D enemy in hitEnnemies)
            {
                Enemy enemyObject = enemy.GetComponent<Enemy>();
                enemyObject.TakeDamage(this.damage);
                if (!enemyObject.IsAlive() && enemyObject.canBeHit)
                {
                    ScoreManager.instance.AddPoint();
                    enemyObject.canBeHit = false;
                }
            }
        }
    }

    void StopMoving()
    {
        goDown = false;
        goLeft = false;
        goRight = false;
        goUp = false;
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        Debug.Log(collisionInfo);
    }
    void OnRestart()
    {
        SceneManager.LoadScene("MainScene");
    }
}