using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public GameObject mainZombie;
    private bool isAlive = true;
    public int maxHP = 100;

    private int dirZombie;
    int currentHP;
    // Start is called before the first frame update
    void Start()
    {
        mainZombie = GameObject.Find("zombie");
        this.currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        this.GetOrientationPlayer();
        animator.SetFloat("zombiePosition",dirZombie);
        if(!this.isAlive)animator.SetBool("isAlive",false);
    }

    public bool GetIsAlive(){
        return this.isAlive;
    }

    public void TakeDamage(int damage){
        currentHP-=damage;
        if(currentHP<=0)Die();
        else Debug.Log("enemy is at " + this.currentHP + " HP");
    }

    void Die(){
        this.isAlive = false;
        Debug.Log("enemy is dead");
        GetComponent<Pathfinding.AIPath>().canMove = false;

    }

    void GetOrientationPlayer(){
        float diffY = this.transform.position.y - this.mainZombie.transform.position.y;
        float diffX = this.transform.position.x - this.mainZombie.transform.position.x;
        if(diffX<0 && Math.Abs(diffX)>Math.Abs(diffY))this.dirZombie = 4;
        else if(diffX>0 && Math.Abs(diffX)>Math.Abs(diffY))this.dirZombie = 3;
        else if(diffY<0)this.dirZombie = 2;
        else if(diffY>0)this.dirZombie = 1;
    }
}
