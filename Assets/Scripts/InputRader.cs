using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputRader : MonoBehaviour
{
    public static event Action<Vector2> OnMove;
    public static event Action ChangeColor;
    public void Movement(InputAction.CallbackContext context)
    {
        OnMove?.Invoke(context.ReadValue<Vector2>());
    }
    public void Change(InputAction.CallbackContext Context)
    {
        if(Context.performed)
        ChangeColor?.Invoke();
    }
}
