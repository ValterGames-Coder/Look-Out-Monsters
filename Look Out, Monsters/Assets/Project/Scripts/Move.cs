using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //Компоненты
    Rigidbody2D _rigidbody;
    Joystick _joystick;
    private bool _isRight;
    private Vector2 move;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _joystick = GameObject.FindObjectOfType<Joystick>();
    }
    public Vector2 MoveVector(float speed)
    {
        move = new Vector2(_joystick.Horizontal * speed + Time.fixedDeltaTime, _rigidbody.velocity.y);
        _rigidbody.velocity = move;
        return move;
    }

    public void Flip(){
        if(_joystick.Horizontal > 0 && _isRight || _joystick.Horizontal < 0 && !_isRight)
        {
            _isRight = !_isRight;
            Vector3 Scale = transform.localScale;
            Scale.x *= -1;
            transform.localScale = Scale;
        }
    }
}
