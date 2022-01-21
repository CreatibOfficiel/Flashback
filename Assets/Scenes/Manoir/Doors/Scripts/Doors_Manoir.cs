using UnityEngine;
using UnityEngine.UI;

public class Doors_Manoir : MonoBehaviour
{
    [Header("Detections")]
    [SerializeField] private int doorNumber;
    [SerializeField] private bool isInZone;
    [SerializeField] private Text interact;

    private GameManagementPlayer GameManagementScript;

    private void Start()
    {
        GameManagementScript = GameObject.FindGameObjectWithTag("GameManagerPlayer").GetComponent<GameManagementPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("1" + GameManagementScript._getActualPlayer.tag.ToString());Debug.Log("2" + GameManager.instance.getIfcanGoInThePaint(doorNumber));Debug.Log("col" + col.gameObject.tag);
        if (col.gameObject.tag == GameManagementScript._getActualPlayer.tag.ToString() && GameManager.instance.getIfcanGoInThePaint(doorNumber))
        {
            isInZone = true;
            displayLevel(doorNumber);
            interact.enabled = true;
        }
    }
    // testtt
    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == GameManagementScript._getActualPlayer.tag.ToString() && GameManager.instance.getIfcanGoInThePaint(doorNumber))
        {
            isInZone = false;
            interact.enabled = false;
        }
            
    }

    private void Update()
    {
        if (isInZone)
        {
            InputKey();
        }
    }


    private void displayLevel(int level) {
        enumList.Scene value = (enumList.Scene)level;
        Debug.Log(value);
    }

    private void enterLevel(int level)
    {
        Loader.Load(level);
    }

    private void InputKey()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            enterLevel(doorNumber);
        }
    }


}
