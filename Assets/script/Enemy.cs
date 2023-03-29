using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    private GameObject mainZombie;
    private bool isAlive = true;
    public int maxHP = 100;
    public bool canBeHit = true;

    private int dirZombie;
    public int currentHP;

    public int damage = 5;
    // Start is called before the first frame update
    void Start()
    {
        this.mainZombie = GameObject.Find("Zombie");
        this.currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        this.GetOrientationPlayer();
        this.animator.SetFloat("zombiePosition",this.dirZombie);
        if(!this.isAlive)animator.SetBool("isAlive",false);
    }

    public bool IsAlive(){
        return this.isAlive;
    }

    public void TakeDamage(int damage){
        this.currentHP-=damage;
        if(this.currentHP<=0)Die();
    }

    void Die(){
        this.isAlive = false;
        float destryDelay = 10;
        GetComponent<Pathfinding.AIPath>().canMove = false;
        Destroy(this.gameObject,destryDelay);
    }

    void GetOrientationPlayer(){
        float diffY = this.transform.position.y - this.mainZombie.transform.position.y;
        float diffX = this.transform.position.x - this.mainZombie.transform.position.x;
        if(diffX<0 && Math.Abs(diffX)>Math.Abs(diffY))this.dirZombie = 4;
        else if(diffX>0 && Math.Abs(diffX)>Math.Abs(diffY))this.dirZombie = 3;
        else if(diffY<0)this.dirZombie = 2;
        else if(diffY>0)this.dirZombie = 1;
    }
    public int GetCurrentHP(){
        return this.currentHP;
    }
}
