using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D playerRB;
    Animator playerAnim;

    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;
    [SerializeField] GameObject wayPoint;

    float maxSpeed;
    private float timer = 0.5f;

    bool canMove = true; 
    bool doingWheeling = false;

    public static PlayerMove instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a une double instance de PlayerMove");
            return;
        }
        instance = this;
    }

    // Use this for initialization
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>(); 
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (RaceManager.instance.getGameState())
        {
            if (Input.GetKeyDown(KeyCode.D) || !getState())
                canMove = false;
            if (Input.GetKeyDown(KeyCode.D) && getState())
                canMove = true;

            UpdateTimer();

            float move = Input.GetAxis("Horizontal");

            if (getState())
            {
                playerRB.constraints = RigidbodyConstraints2D.None;
            }

            if (canMove && getState() && Input.GetAxis("Jump") > 0 && move > 0.1)
            {
                doingWheeling = true;
            }
            else
                doingWheeling = false;

            playerAnim.SetBool("Wheeling", doingWheeling);

            if (PlayerNitro.instance.GetNitroState())
                maxSpeed = 30;
            else
            {
                 maxSpeed = 20;
            }

            if (canMove)
            {
                playerRB.velocity = new Vector2(move * maxSpeed, playerRB.velocity.y);
                playerAnim.SetFloat("MoveSpeed", Mathf.Abs(move));
            }
            else
            {
                playerRB.velocity = new Vector3(0, playerRB.velocity.y, 0);
                playerAnim.SetFloat("MoveSpeed", 0);
            }
        }
    }

    bool getState()
    {
        Vector2 position = groundCheck.position;
        Vector2 direction = Vector2.down;
        float distance = 6.0f;
        if (PlayerNitro.instance.GetNitroState())
            distance = 15.0f;

        Debug.DrawRay(groundCheck.position, direction, Color.red);
        RaycastHit2D touch = Physics2D.Raycast(position, direction, distance, groundLayer);
        if(touch.collider != null)
        {
            return true;
        }
        return false;
    }

    public bool getWheelingState()
    {
        return doingWheeling;
    }

    void UpdateTimer()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            UpdatePosition();
            timer = 0.5f;
        }
    }

    void UpdatePosition()
    {
        wayPoint.transform.position = transform.position;
    }

    public Rigidbody2D _rigidbody
    {
        get { return playerRB; }
    }
}