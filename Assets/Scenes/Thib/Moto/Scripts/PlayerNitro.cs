using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNitro : MonoBehaviour
{
    float maxNitro = 100;
    bool nitroIsActive = false;
    public float curentNitro = 0;
    public static PlayerNitro instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Bug");
            return;
        }
        instance = this;
    }

    Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !PlayerMove.instance.getWheelingState())
        {
            if (curentNitro >= 90)
            {
                AudioManager.instance.startNitro();
                setStateOfNitro(true);
                useNitro();
                StartCoroutine(TimeInNitro());
            }
        }
    }

    private void FixedUpdate()
    {
        if (PlayerMove.instance.getWheelingState() && !nitroIsActive)
            addNitro(3f);
    }

    void setStateOfNitro(bool b)
    {
        nitroIsActive = b;
        playerAnim.SetBool("Nitro", nitroIsActive);
    }

    void addNitro(float value)
    {
        if ((curentNitro + value) >= maxNitro)
            curentNitro = maxNitro;
        else
            curentNitro += value;

        NitroBar.instance.setNitro(curentNitro);
    }

    void useNitro()
    {
        NitroBar.instance.resetSlider();
        curentNitro = 0;
    }

    public bool GetNitroState()
    {
        return nitroIsActive;
    }

    public IEnumerator TimeInNitro()
    {
        yield return new WaitForSeconds(5f);
        AudioManager.instance.stopNitro();
        setStateOfNitro(false);
    }
}
