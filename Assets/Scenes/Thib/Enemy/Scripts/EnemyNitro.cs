using UnityEngine;
using System.Collections;

public class EnemyNitro : MonoBehaviour
{
    float maxNitro = 100.0f;
    float curentNitro = 0.0f;

    public static EnemyNitro instance;
    Animator playerAnim;

    public void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a une double instance de EnemyNitro");
            return;
        }
        instance = this;
    }

    public void addNitro(float value)
    {
        if ((curentNitro + value) >= maxNitro)
            curentNitro = maxNitro;
        else
            curentNitro += value;
    }

    public void useNitro()
    {
        if (curentNitro >= 98)
        {
            curentNitro = 0;
            EnemyPatrol.instance.setNitroState(true);
            playerAnim.SetBool("Nitro", true);
            StartCoroutine(TimeInNitro());
        }
    }

    public IEnumerator TimeInNitro()
    {
        yield return new WaitForSeconds(5f);
        Debug.Log("fin nitro");
        EnemyPatrol.instance.setNitroState(false);
        playerAnim.SetBool("Nitro", false);
        
    }
}
