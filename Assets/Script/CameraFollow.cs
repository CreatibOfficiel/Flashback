using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float TransitionTime = 10f;

    [SerializeField] private Transform actualPlayerGameObject;

    private Transform target;
    private float margin = 0.1f;

    private GameManagementPlayer GameManagementScript;


    private void Start()
    {
        
        GameManagementScript = GameObject.FindGameObjectWithTag("GameManagerPlayer").GetComponent<GameManagementPlayer>();
        transform.position = new Vector3(actualPlayerGameObject.position.x, actualPlayerGameObject.position.y, transform.position.z);
    }

    private void Update()
    {

        float targetX = target.position.x;
        float targetY = target.position.y;

        if (Mathf.Abs(transform.position.x - targetX) > margin)
            targetX = Mathf.Lerp(transform.position.x, targetX, TransitionTime * Time.deltaTime);

        if (Mathf.Abs(transform.position.y - targetY) > margin)
            targetY = Mathf.Lerp(transform.position.y, targetY, TransitionTime * Time.deltaTime);

        transform.position = new Vector3(targetX, targetY, transform.position.z);
    }

    public Transform _target
    {
        get { return target; }
        set { target = value; }
    }
}

