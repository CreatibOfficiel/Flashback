using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YliControl : MonoBehaviour
{

    public Rigidbody2D playerRB; // Propriété qui tiendra en réféence le rigid body de notre player
    SpriteRenderer playerRenderer; // Propriété qui tiendra la réféence du sprite rendered de notre player
    public Animator playerAnim; // Propriete qui tiendra la reference a notre composant animator

    public float moveSpeed;

    bool facingRight = true; // Par défaut, notre player regarde à droite

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
        playerRB = GetComponent<Rigidbody2D>(); // On utilise GetComponent car notre Rb se situe au sein du même objet
        playerRenderer = GetComponent<SpriteRenderer>();
        playerAnim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        // Rédiger ci dessous le code permettant de déerminer quand le player doit se retourner

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
