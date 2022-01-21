using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    bool grounded = false;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public GameObject respawnPoint;
    public Rigidbody2D body;

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (grounded)
        {
            body.velocity = new Vector3(0, 0, 0);
            body.constraints = RigidbodyConstraints2D.FreezeRotation;
            transform.rotation = UnityEngine.Quaternion.Euler(0, 0, 0);
            body.bodyType = RigidbodyType2D.Kinematic;
            transform.position = respawnPoint.transform.position;
            body.bodyType = RigidbodyType2D.Dynamic;
        } 
    }
}
