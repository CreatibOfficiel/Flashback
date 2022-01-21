using UnityEngine;
using UnityEngine.UI;


public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;

    private bool isInRange;

    private Text interactUI;

    private void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            TriggerDialogue();
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("DefaultPlayer") && !GameManager.instance.getIfCanTalk())
        {
            interactUI.enabled = true;
            isInRange = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("DefaultPlayer"))
        {
            interactUI.enabled = false;
            isInRange = false;
        }
    }

    void TriggerDialogue()
    {
        interactUI.enabled = false;
        DialogueManager.instance.StartDialogue(dialogue);
        GameManager.instance.setTalkWithGhost(dialogue.name);
    }
}
