using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmeliaScript : MonoBehaviour
{
    // Start is called before the first frame update

    public static AmeliaScript Amelia;
    public Animator Anim;

    void Start()
    {
        Amelia = this;
        Anim = GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
