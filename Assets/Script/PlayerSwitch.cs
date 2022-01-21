using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{
    [Header("Settings Switch")]
    [SerializeField] private float coolDown;

    [HideInInspector]
    [SerializeField] private int selectedCharacter;

    private float switchTime;
    private Rigidbody2D rb;

    private GameManagementPlayer GameManagementScript;
    private CameraFollow CameraFollowScript;

    private GameObject curPlayer;

    private Vector3 positionLastPlayer;

    private bool canSwitch = true;

    public static PlayerSwitch instance;


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
        GameManagementScript = GameObject.FindGameObjectWithTag("GameManagerPlayer").GetComponent<GameManagementPlayer>();
        CameraFollowScript = GameObject.FindGameObjectWithTag("CameraFollow").GetComponent<CameraFollow>();

        curPlayer = GameObject.FindGameObjectWithTag(GameManagementPlayer.instance.unlockPlayers[0].ToString());
    }

    private void Update()
    {
        InputKey();
    }

    private void SwitchPlayer()
    {
        switchTime = Time.time + coolDown;

        if (GameManagerScene.instance._ActualScene == enumList.Scene.Manoir)
        {
            //////////////////////////////////////////////////////////
            ///Switch DANS MANOIR
            //////////////////////////////////////////////////////////

            if (GameManagementPlayer.instance.unlockPlayers.Count > 1)
            {
                if (selectedCharacter < GameManagementPlayer.instance.unlockPlayers.Count - 1)
                    selectedCharacter++;
                else
                    selectedCharacter = 0;

                for (int i = 0; i < GameManagementPlayer.instance.unlockPlayers.Count; ++i) // Mettre size tableau unlock perso
                {

                    enumList.Players value = (enumList.Players)i;

                    _getRb = GameObject.FindGameObjectWithTag(GameManagementPlayer.instance.unlockPlayers[i].ToString()).GetComponent<Rigidbody2D>();
                    rb.velocity = Vector3.zero;

                    if (i != selectedCharacter)
                    {
                        if (GameObject.FindGameObjectWithTag(GameManagementPlayer.instance.unlockPlayers[i].ToString()).tag == "KevinPlayer")
                        {
                            GameObject.FindGameObjectWithTag(GameManagementPlayer.instance.unlockPlayers[i].ToString()).GetComponent<AnimGhost>().enabled = false;

                        }
                        if (GameObject.FindGameObjectWithTag(GameManagementPlayer.instance.unlockPlayers[i].ToString()).tag == "YliPlayer")
                        {
                            GameObject.FindGameObjectWithTag(GameManagementPlayer.instance.unlockPlayers[i].ToString()).GetComponent<AnimYli>().enabled = false;

                        }
                        GameObject.FindGameObjectWithTag(GameManagementPlayer.instance.unlockPlayers[i].ToString()).GetComponent<playerController>().enabled = false;
                        GameObject.FindGameObjectWithTag(GameManagementPlayer.instance.unlockPlayers[i].ToString()).GetComponent<PnjMoveRandomly>().enabled = true;
                    }
                    else
                    {
                        GameObject.FindGameObjectWithTag(GameManagementPlayer.instance.unlockPlayers[i].ToString()).GetComponent<playerController>().enabled = true;
                        GameObject.FindGameObjectWithTag(GameManagementPlayer.instance.unlockPlayers[i].ToString()).GetComponent<PnjMoveRandomly>().enabled = false;

                        curPlayer = GameObject.FindGameObjectWithTag(GameManagementPlayer.instance.unlockPlayers[i].ToString());
                        if(curPlayer.tag == "KevinPlayer")
                        {
                            curPlayer.GetComponent<AnimGhost>().enabled = true;
                        }
                        if(curPlayer.tag == "YliPlayer")
                        {
                            curPlayer.GetComponent<AnimYli>().enabled = true;
                        }
                        CameraFollowScript._target = GameObject.FindGameObjectWithTag(GameManagementPlayer.instance.unlockPlayers[i].ToString()).GetComponent<Transform>();
                    }
                }
            }
        }
        else
        {
            positionLastPlayer = new Vector3(GameManagementPlayer.instance._getActualPlayer.transform.position.x, GameManagementPlayer.instance._getActualPlayer.transform.position.y, GameManagementPlayer.instance._getActualPlayer.transform.position.z);

            if (selectedCharacter < GameManagementPlayer.instance.unlockPlayers.Count - 1)
                selectedCharacter++;
            else
                selectedCharacter = 0;
            for (int i = 0; i < GameManagementPlayer.instance.unlockPlayers.Count; ++i)
            {
                if (i != selectedCharacter)
                {
                    LoadPlayer.instance.listToLoad[i].GetComponent<playerController>().enabled = false;
                    LoadPlayer.instance.listToLoad[i].SetActive(false);
                }
                else
                {
                    LoadPlayer.instance.listToLoad[i].SetActive(true);
                    LoadPlayer.instance.listToLoad[i].GetComponent<playerController>().enabled = true;
                    curPlayer = GameObject.FindGameObjectWithTag(GameManagementPlayer.instance.unlockPlayers[i].ToString());
                    LoadPlayer.instance.listToLoad[i].transform.position = positionLastPlayer;
                    CameraFollowScript._target = LoadPlayer.instance.listToLoad[i].GetComponent<Transform>();

                }
                Debug.Log(positionLastPlayer);

            }
            Debug.Log("salmut");
        }
    }

    private void InputKey()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time > switchTime && canSwitch)
        {
            SwitchPlayer();
        }
    }


    public Rigidbody2D _getRb
    {
        get { return rb; }
        set { rb = value; }
    }

    public bool _canSwitch
    {
        get { return canSwitch; }
        set { canSwitch = value; }
    }

    public GameObject _getActualPlayerSwitch
    {
        get { return curPlayer; }
    }

}
