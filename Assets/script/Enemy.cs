using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool isAlive = true;
    public int maxHP = 100;
    int currentHP;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool GetIsAlive(){
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
    }

    int GetOrientationPlayer(){

    }
}
