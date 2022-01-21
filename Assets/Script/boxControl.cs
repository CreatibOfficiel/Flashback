using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxControl : MonoBehaviour
{
    private bool isControl = false;

    public static boxControl instance;
    private CameraFollow CameraFollowScript;
    private Transform trans;

    private Vector3 velocity = Vector3.zero;


    public Rigidbody2D rb;
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
        CameraFollowScript = GameObject.FindGameObjectWithTag("CameraFollow").GetComponent<CameraFollow>();
        trans = this.transform;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "ballKevin")
        {
            isControl = true;
        }
    }

    public bool _isControl
    {
        get { return isControl; }
        set { isControl = value; }
    }

    private void Update()
    {
        if(_isControl)
        {
            playerController.instance._canMove = false;
            PlayerSwitch.instance._canSwitch = false;

            playerController.instance._rb.velocity = Vector3.zero;
            CameraFollowScript._target = trans;

            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            rb.gravityScale = 0;

            if (Input.GetKey(KeyCode.Z))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 5 * Time.deltaTime);

            }

            else if (Input.GetKey(KeyCode.D))
            {
                transform.position = new Vector3(transform.position.x + 5 * Time.deltaTime, transform.position.y);
            }

            else if (Input.GetKey(KeyCode.Q))
            {
                transform.position = new Vector3(transform.position.x - 5 * Time.deltaTime, transform.position.y);
            }

            else if (Input.GetKey(KeyCode.S))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 5 * Time.deltaTime);
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                _isControl = false;
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                rb.gravityScale = 1;
                CameraFollowScript._target = playerController.instance.transform;
                playerController.instance._canMove = true;
            }
        }
    }
}
