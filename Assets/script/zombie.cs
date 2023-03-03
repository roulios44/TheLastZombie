using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class zombie : MonoBehaviour
{
    // Start is called before the first frame update
    private bool goRight = false;
    private bool goLeft = false;
    private bool goUp = false;
    private bool goDown = false;
    public float mass;
    public float speed = 5f;
    public  Rigidbody2D body;
    Vector2 movement;
    private float posX;
    private float posY;
    public Animator animator;
    void Start()
    {
        mass = body.mass;
    }

    // Update is called once per frame
    void Update()
    {
        if(goLeft)movement.x = -1;
        else if(goRight)movement.x = 1;
        else movement.x = 0;
        if (goUp)movement.y = 1;
        else if (goDown)movement.y = -1;
        else movement.y = 0;

        animator.SetFloat("Horizontal",movement.x);
        animator.SetFloat("Vertical",movement.y);
        // animator.SetFloat("Speed",movement.sqrMagnitude);

    }

    void FixedUpdate(){
        body.MovePosition(body.position + movement * speed * Time.fixedDeltaTime);
    }

    void OnRight(InputValue val){
        if(val.Get<float>() == 0)goRight = false;
        else goRight = true;
    }
    
    void OnLeft(InputValue val){
        if(val.Get<float>() == 0)goLeft = false;
        else goLeft = true;
    }
    
    void OnUp(InputValue val){
        if(val.Get<float>() == 0)goUp = false;
        else goUp = true;
    }
    
    void OnDown(InputValue val){
        if(val.Get<float>() == 0)goDown = false;
        else goDown = true;
    }
}