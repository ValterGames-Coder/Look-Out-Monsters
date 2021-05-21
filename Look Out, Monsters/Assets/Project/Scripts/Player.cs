using UnityEngine;
public class Player : MonoBehaviour
{
    //Компоненты
    Health _health;
    Move _move;
    //Силы
    [SerializeField] private float speed; 

    private void Start()
    {
        _health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        _move = GameObject.FindGameObjectWithTag("Player").GetComponent<Move>();
    }
    private void FixedUpdate()
    {
       _move.MoveVector(speed);
       _move.Flip();
    }
}
