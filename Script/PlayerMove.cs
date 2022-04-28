using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    
    Animator animator;

    public float Speed = 5f;
   
    Rigidbody2D rbody;

    //Vector2 movement;
    private PlayerInput input;
    private Vector2 move;

    

    // Start is called before the first frame update
    void Start()
    {
        //control = new PlayerInput();
        input = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody2D>(); 

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Walk();

    }

    void Walk(){
        
        //move = new Vector2(Move.X,Move.Y) * Speed *Time.deltaTime;
        Vector2 position = rbody.position;
        //Vector2 move = InputSystem.
        rbody.velocity = move * Speed;
        //movement = new Vector3(0 , 0, Speed * Time.deltaTime);
        //position += rbody.velocity * Time.deltaTime;
        position += move;
        rbody.MovePosition(position);
        animator.SetFloat("Speed", move.magnitude);

    }

    public void PlayMove(InputAction.CallbackContext callbackContext){
        Vector2 movement = callbackContext.ReadValue<Vector2>();
        if(movement.y != 0 ||movement.x != 0)
        {
            animator.SetBool("Go",true);
        }
        else 
        {
            animator.SetBool("Go",false);
        }
        animator.SetFloat("Speed", movement.magnitude);

        Debug.Log(movement);

    }
}
