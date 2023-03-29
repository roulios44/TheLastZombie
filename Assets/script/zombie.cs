using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System;


public class Zombie : MonoBehaviour
{
    public GameObject menuObject;
    public int purse;
    private System.Random rand = new System.Random();
    public bool isAlive = true;
    private int enemiesOn;
    private float timeElapsed = 0f;
    private bool goRight = false;
    private bool goLeft = false;
    private bool goUp = false;
    private bool goDown = false;
    public float mass;
    public float speed = 1f;
    public Rigidbody2D body;
    private Vector2 movement;
    private float lastDir;
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int damage = 20;
    public int currentHP;
    public int maxHP=100;
    void Start()
    {
        this.mass = this.body.mass;
        this.currentHP = this.maxHP;
    }

    void Update()
    {
        this.WalkDirection();
        this.SetAnimator();
    }

    void FixedUpdate()
    {
        this.body.MovePosition(this.body.position + this.movement * this.speed * Time.fixedDeltaTime);
        this.DoEverySeconds();
    }

    void WalkDirection(){
        if (this.goLeft) this.movement.x = -1;
        else if (this.goRight) this.movement.x = 1;
        else this.movement.x = 0;
        if (this.goUp) this.movement.y = 1;
        else if (this.goDown) this.movement.y = -1;
        else this.movement.y = 0;
    }
    void SetAnimator(){
        this.animator.SetFloat("Horizontal",movement.x);
        this.animator.SetFloat("Vertical",movement.y);
        this.animator.SetFloat("Speed",movement.sqrMagnitude);
        this.animator.SetFloat("LastDir",lastDir);
    }

    void DoEverySeconds(){
        this.timeElapsed += Time.fixedDeltaTime;
        if(this.timeElapsed>=1f){
            this.timeElapsed %= 1f;
            this.DamageZombie();
        }
    }
    
    void DamageZombie(){
        if(this.enemiesOn>0){
            this.currentHP-=5*this.enemiesOn;
            if(this.currentHP<=0)this.Die();
        }
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
            Collider2D[] hitEnnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, LayerMask.GetMask(LayerMask.LayerToName(gameObject.layer)));
            foreach (Collider2D enemy in hitEnnemies)
            {
                if(enemy.GetComponent<Enemy>()!=null){
                    Enemy enemyObject = enemy.GetComponent<Enemy>();
                    enemyObject.TakeDamage(this.damage);
                    if (!enemyObject.IsAlive() && enemyObject.canBeHit)
                    {
                        this.enemiesOn--;
                        this.purse += rand.Next(1, 5);
                        ScoreManager.instance.AddPoint();
                        enemyObject.canBeHit = false;
                    }
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
    

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.GetComponent<Enemy>()!=null){
            if(col.gameObject.GetComponent<Enemy>().IsAlive()){
                Enemy enemy = col.gameObject.GetComponent<Enemy>();
                this.enemiesOn++;
            }
        }
    }

    void OnCollisionExit2D(Collision2D col){
        if(col.gameObject.GetComponent<Enemy>()!=null){
            Enemy enemy = col.gameObject.GetComponent<Enemy>();
            this.enemiesOn--;
        }
    }
    void OnRestart()
    {
        SceneManager.LoadScene("MainScene");
    }

    void OnPause(){
        this.menuObject.SetActive(true);
        Time.timeScale = 0;
    }
    void Die(){
        this.isAlive = false;
    }

    public bool IsAlive(){
        return this.isAlive;
    }
}