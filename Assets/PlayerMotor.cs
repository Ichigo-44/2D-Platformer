using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMotor : MonoBehaviour
{
    Vector2 direction;
    private bool canJump = true;
    public int multijump = 1;
    public float dashForce = 10;
    public float acceleration = 10;
    public float stoppingForce = 10;
    public float maxSpeedX = 10;
    public float stoppingPoint = 0.1f;
    public float jumpForce = 5;
    public float enemyHitForce = 50;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator; 
    private bool _canJump = true;

    private float initXScale;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        initXScale = transform.localScale.x;
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        MovePlayer();
        LimitMaxSpeed();
        if (direction.x != 0)
        {
            _animator.SetBool("is moving", true);
        }
        else
        {
            _animator.SetBool("is moving", false);
        }
        if (direction.x > 0)
        {
            transform.localScale = new Vector3(initXScale, transform.localScale.y, transform.localScale.z);
        }
        else if(direction.x < 0)
        {
            transform.localScale = new Vector3(-initXScale, transform.localScale.y, transform.localScale.z);
        }
    }
    private void OnJump()
    {
        Debug.Log("Jump");
        if (canJump)
         {
            _rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            if (multijump > 0)
            {
                multijump--;
            }
            else
            {
                _canJump = false;

            }
        }
    }
    private void LimitMaxSpeed()
    {
        //Limit max speed
        if (_rigidbody2D.linearVelocityX >= maxSpeedX)
        {
            _rigidbody2D.linearVelocityX = maxSpeedX;
        }
        else if (_rigidbody2D.linearVelocityX <= -maxSpeedX)
        {
            _rigidbody2D.linearVelocityX = -maxSpeedX;
        }
    }

    private void MovePlayer()
    {
        //accelerate if pressing button
        if (direction.x != 0)
        {
            _rigidbody2D.AddForce(new Vector2(direction.x * acceleration, 0));
        }
        //if not accelerating start slowing down
        else if (_rigidbody2D.linearVelocityX != 0)
        {
            //if almost stopped, force stop
            if (_rigidbody2D.linearVelocityX < stoppingPoint && _rigidbody2D.linearVelocityX > -stoppingPoint)
            {
                _rigidbody2D.linearVelocity = new Vector2(0.0f, _rigidbody2D.linearVelocityY);
            }
            //add stopping force
            else
            {
                _rigidbody2D.AddForce(new Vector2(-_rigidbody2D.linearVelocityX * stoppingForce, 0));
            }
        }
    }

    private void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
    }

    private void Canjump()
    {
        if (_canJump)
        {
            _rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            _canJump = false;
        }
    }

    private void OnDash()
    {
        _rigidbody2D.AddForce(new Vector2(direction.x * dashForce,0), ForceMode2D.Impulse);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        _canJump = true;
    }

    private void OnHealthChanged(int oldHealth, int amountChanged, Vector3 origin)
    {
        _rigidbody2D.AddForce(new Vector3(origin.x - transform.position.x,0,0) * enemyHitForce, ForceMode2D.Impulse);
    }



}
