using UnityEngine;

public class PlayerMoveManoir : MonoBehaviour
{

    float maxSpeed;
    public float moveSpeed;
    private float timer = 0.5f;

    bool canMove = true;
    bool doingWheeling = false;
    bool facingRight = true; // Par défaut, notre player regarde à droite

    public static PlayerMove instance;
    private Rigidbody2D playerRB;
    private Animator playerAnim;
    private SpriteRenderer playerRenderer;

    // Use this for initialization
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        playerRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal");

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();
        playerRB.velocity = new Vector2(move * moveSpeed, playerRB.velocity.y); // On utilise vector 2 car nous sommes dans un contexte 2D
        playerAnim.SetFloat("Speed", Mathf.Abs(move)); // Defini une valeur pour le float MoveSpeed dans notre animator
    }

    void Flip()
    {
        facingRight = !facingRight; // On change la valeur du boolen facing right par son contraire, représentant la direction du personnage
        playerRenderer.flipX = !playerRenderer.flipX; // Même chose ici pour que notre flipx et facingRight soient en phase
    }
}