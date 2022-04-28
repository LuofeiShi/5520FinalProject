using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Player Input")]
public class PlayerInput : ScriptableObject, RacunInput.IPlayerActions
{
    public event UnityAction<Vector2> onMove = delegate {};
    public event UnityAction onFire = delegate {};
    public event UnityAction onStopFire = delegate {};
    public event UnityAction onStopMove = delegate {};
    RacunInput inputActions;

    void OnEnable() 
    {
        inputActions = new RacunInput();

        inputActions.Player.SetCallbacks(this);
        
    }
    void Ondisable() {
        DisableAllInputs();
    }

    public void EnablePlayerInput()
    {
        inputActions.Player.Enable();

        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;

    }

    public void DisableAllInputs()
    {
        inputActions.Player.Disable();
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            
            onMove.Invoke(context.ReadValue<Vector2>());
        }
        if(context.phase == InputActionPhase.Canceled)
        {
            onStopMove.Invoke();
        }
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        GameObject player = GameObject.FindGameObjectWithTag ("Player");
        var pc = player.GetComponent<Player>();

        if (context.phase == InputActionPhase.Performed)
        {
            onFire.Invoke();
        }
        if (context.phase == InputActionPhase.Canceled){
            onStopFire.Invoke();
        }
        
    }

    public void OnLook(InputAction.CallbackContext context){}
   
}
