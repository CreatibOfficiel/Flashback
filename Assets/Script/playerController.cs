using UnityEngine;
using System.Collections.Generic;

public class playerController : MonoBehaviour
{
    [Header("Comp")]
    public Rigidbody2D rb;
    private Animator animator;
    public SpriteRenderer spriteRenderer;
    private Transform trans;

    [Header("Movement Axe X")]
    public float moveSpeed;
    private float horizontalMove;

    [Header("Physics")]
    private Vector3 velocity = Vector3.zero;

    [Header("Info")]
    public float TimeIdle;
    private bool isIdle;
    private bool canMove = true;

    public static playerController instance;
    private void Awake()
    {
        if (instance != null)
        {
            return;
        } 

        instance = this;
    }

    private void Start()
    {
        if(instance != null)
        {

            if (GameManagementPlayer.instance._getActualPlayer.tag != instance.tag)
            {
                
                instance = this;
            }
        }

        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (canMove)
            horizontalMove = Input.GetAxis("Horizontal") * moveSpeed;

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        Flip(rb.velocity.x);
        setIsIdle();
        setTimeIdle();
    }

    private void FixedUpdate()
    {
        if(canMove)
            MovePlayer(horizontalMove * Time.fixedDeltaTime);
    }

    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void setIsIdle()
    {
        if (Mathf.Abs(rb.velocity.x) <= 0.2f)
            isIdle = true;
        else
            isIdle = false;
    }

    private void setTimeIdle()
    {
        if (isIdle)
        {
            TimeIdle = TimeIdle + Time.deltaTime;
        }

        else if (!isIdle)
            TimeIdle = 0;
    }

    private void MovePlayer(float _horizontalMove)
    {
        Vector3 actualVelocity = new Vector2(_horizontalMove, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, actualVelocity, ref velocity, .05f);
    }


    public bool _canMove
    {
        get { return canMove; }
        set { canMove = value; }
    }

    public Animator _Animator
    {
        get { return animator; }
    }

    public float _TimeIdle
    {
        get { return TimeIdle; }
    }

    public Transform _TransformPlayer
    {
        get { return trans; }
    }

    public Rigidbody2D _rb
    {
        get { return rb; }
        set { rb = value; }
    }


}

