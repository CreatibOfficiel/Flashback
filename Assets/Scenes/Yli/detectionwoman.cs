using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class detectionwoman : MonoBehaviour
{

    //Start is called before the first frame update
    public Text texte;
    public bool seducteur;
    //private GameObject actualplayer;

    //private GameManagementPlayer.instance.;
    void Start()
    {


        texte.enabled = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && seducteur)
        {
            SceneManager.LoadScene(6);

        } }

        //activer le texte si le joueur rentre dans la zone de détection
       void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "YliPlayer")
            {
                seducteur = true;
            texte.enabled = true;
            }
        }

        //desactiver le texte si le joueur sort de la zone de de détection
      void  OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "YliPlayer")
            {
                seducteur = false;
                texte.enabled = false;
            }
        }
    
}
