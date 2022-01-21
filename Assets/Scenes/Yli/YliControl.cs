using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YliControl : MonoBehaviour
{

    public Rigidbody2D playerRB; // Propri�t� qui tiendra en r�f�ence le rigid body de notre player
    SpriteRenderer playerRenderer; // Propri�t� qui tiendra la r�f�ence du sprite rendered de notre player
    public Animator playerAnim; // Propriete qui tiendra la reference a notre composant animator

    public float moveSpeed;

    bool facingRight = true; // Par d�faut, notre player regarde � droite

    public static YliControl instance;

    private void Awake()
    {
        if (instance != null)
        {

            return;
        }
        instance = this;
    }

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>(); // On utilise GetComponent car notre Rb se situe au sein du m�me objet
        playerRenderer = GetComponent<SpriteRenderer>();
        playerAnim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        // R�diger ci dessous le code permettant de d�erminer quand le player doit se retourner

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();
        playerRB.velocity = new Vector2(move * moveSpeed, playerRB.velocity.y); // On utilise vector 2 car nous sommes dans un contexte 2D
        playerAnim.SetFloat("Speed", Mathf.Abs(move)); // Defini une valeur pour le float MoveSpeed dans notre animator
    }
    void Flip()
    {
        facingRight = !facingRight; // On change la valeur du boolen facing right par son contraire, repr�sentant la direction du personnage
        playerRenderer.flipX = !playerRenderer.flipX; // M�me chose ici pour que notre flipx et facingRight soient en phase
    }
}
