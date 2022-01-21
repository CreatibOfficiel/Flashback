using System.Collections;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    Rigidbody2D playerRB;
    Animator playerAnim;

    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;

    int maxSpeed = 20;
    float currentSpeed = 1.0f;

    public bool doingWheeling = false;
    public bool doingNitro = false;

    public static EnemyPatrol instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a une double instance de EnemyPatrol");
            return;
        }
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        StartCoroutine(RandomAction());
    }

    IEnumerator RandomAction()
    {
        int i = (int)Random.Range(1, 3);
        if (RaceManager.instance.getGameState())
            useRandomNumber(i);
        yield return new WaitForSeconds(3);
        StartCoroutine(RandomAction());
    }

    // Update is called once per frame
    void Update()
    {
        if (RaceManager.instance.getGameState())
        {
            playerAnim.SetBool("Wheeling", doingWheeling);

            if (doingWheeling)
                EnemyNitro.instance.addNitro(1f);

            if (doingNitro)
            {
                maxSpeed = 30;
            }
            else maxSpeed = 20;


            playerRB.velocity = new Vector2(currentSpeed * maxSpeed, playerRB.velocity.y);
            playerAnim.SetFloat("MoveSpeed", Mathf.Abs(currentSpeed));
        }
    }

    void useRandomNumber(int randomNumber)
    {
        switch (randomNumber)
        {
            case 1:
                nitro();
                Debug.Log("NITRO");
                break;
            case 2:
                Debug.Log("UP");
                wheelingUp();
                break;
            case 3:
                Debug.Log("DOWN");
                wheelingDown();
                break;
            default:
                break;
        }
            
    }

    public void nitro()
    {
        if (doingWheeling)
            wheelingDown();

        if(!doingNitro && !doingWheeling)
            EnemyNitro.instance.useNitro();        
    }

    void wheelingUp()
    {
        if (!doingNitro && !doingWheeling)
        {
            doingWheeling = true;
        }
    }

    void wheelingDown()
    {
        if (doingWheeling)
        {
            doingWheeling = false;
        }
    }

    public void setNitroState(bool b)
    {
        doingNitro = b;
    }

    public Rigidbody2D _rigidbody
    {
        get { return playerRB; }
    }
}
