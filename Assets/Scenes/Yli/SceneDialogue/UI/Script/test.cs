using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class test : MonoBehaviour
{
    public static test LoveManager;

    //Liste de GameObject//
    VisualDialogueSystem dialogue;
    [Header("UI")]
    public GameObject ResponsesPannel;
    public GameObject GameOverPannel;
    public AmeliaScript Amelia;
    public Button Button1;
    public Button Button2;
    public Button Button3;
    public Button SkipButton;
    public Button Retry;
    public Button Mansion;
    public Text Reponse1;
    public Text Reponse2;
    public Text Reponse3;
    public Slider LoveBar;
    float LoveValue = 0;
    float loveprogress = 0;

    [Header("Sons")]
    public AudioSource OST;
    public AudioSource Hello;
    public AudioSource OhEm;
    public AudioSource Timetospendwithme;
    public AudioSource Ohem;
    public AudioSource Actually;
    public AudioSource AlrightThen;
    public AudioSource EmEm;
    public AudioSource Erk;
    public AudioSource Euh;
    public AudioSource EuhEmm;
    public AudioSource Fun;
    public AudioSource Gooodpoint;
    public AudioSource Han;
    public AudioSource Hey;
    public AudioSource Hmm;
    public AudioSource HoldOn;
    public AudioSource ISee;
    public AudioSource IsthatSo;
    public AudioSource Isuppose;
    public AudioSource Joking;
    public AudioSource MayI;
    public AudioSource No;
    public AudioSource NotBad;
    public AudioSource Okey;
    public AudioSource OkwithYou;
    public AudioSource ReallyDepressing;
    public AudioSource Sure;
    public AudioSource ThatsIt;
    public AudioSource Umm;
    public AudioSource Understand;
    public AudioSource Well;
    public AudioSource WellEmm;
    public AudioSource Yes;
    public AudioSource YouRight;
    public AudioSource AMinute;
    public AudioSource ThankYou;
    public AudioSource Deception;
    public AudioSource Oh;
    public AudioSource Alright;
    public AudioSource Laugh;
    public AudioSource Choice;
    public AudioSource Fail;
    public AudioSource LoveUp;
    public AudioSource LoveUpMax;
    public AudioSource LoveMax;
    public AudioSource Sorry;
    public AudioSource Interesting;
    public AudioSource GoHome;
    public AudioSource OST2;

    double win = 2;
    bool winbool;
    bool loosebool;



    //HISTOIRE//
    public string[] start = new string[]
{
        "Euh...",
        " Salut ?",
        "Moi c'est Amélia" ,
        "Je vois que tu es tout seul",
        "Je te paye un verre ?"

};

    public string[] PositiveResponses1 = new string[]
   {
        "Cool !",
        "Enfin quelqu'un avec qui discuter",
        "Alors",
        "...",
        "C'est embarassant...",
        "Je ne sais pas quoi dire"

   };
    public string[] NeutralResponses1 = new string[]
    {
        "Pas besoin de jouer au gentleman",
        "Mais bon...",
        "Si tu insistes !",
        "Alors",
        "...",
    };
    public string[] NegativeResponses1 = new string[]
{
        "Oh... ok",
        "....",
        "On peut quand même discuter !",
        "..."
};

    public string[] PositiveResponses2 = new string[]
    {
        "Hé ! J'ai 19 ans quand même !",
        "Mais faut dire que...",
        "J'ai pas tellement l'habitude de parler avec des hommes.."
    };

    public string[] NeutralResponses2 = new string[]
{
        "Non c'est la première fois",
        "Je suis venue pour faire des rencontres",
        "Mais pour l'instant je n'ai parlé qu'avec des gens mal intentionné..."
}; public string[] NegativeResponses2 = new string[]
 {
        "Mais pourquoi tu dis ça ??",
        "Enfin..",
        "C'est vrai que ça doit être bizarre de se faire accoster par une fille",
        "Pour dire vrai...",
        "Je suis venue te voir parce que tu avais l'air gentil",
        "Pas comme les personnes que j'ai rencontré auparavant"
 };
    public string[] PositiveResponses3 = new string[]
    {
        "Oh...",//étonné
        "C'est vraiment attentionné de ta part !",//additive
        "T'es bien le premier à me dire ça",
        "ça me fait du bien de te parler..",//rougir
        "J'ai déjà pensé plusieurs fois à en finir.."//triste
    };
    public string[] NeutralResponses3 = new string[]
   {
       "Quoi !?",
       "Je ne m'attendais pas à ça...",//rire
       "Je ne sais pas quoi penser de ce que tu me dis",
       "J'ai déjà beaucoup souffert de ce genre de personne..",//triste
       "J'ai même déjà envisagé le suicide.."
       
   };
    public string[] NegativeResponses3 = new string[]
   {
       "Si tu le dis...",//mépris
       "Si tu savais le nombre de fois qu'on m'avait dit ça",
       "Alors que c'était des mensonges..",//triste
       "Si tu savais à quel point c'est horrible de ne pouvoir faire confiance à personne",
       "Je me sentais si seule, je voulais mourrir"//pleure
   };

    public string[] PositiveResponses4 = new string[]
    {
        "C'est vraiment gentil ! ",//contente
        "Non ça ira...",//triste
        "Je préfèrerai penser à autre chose",//additive
        "Même si tu sais..",
        "Je ne pense pas que ça s'améliorera",
        "Ton inquiètude me touche...",//sourire
        "Dis..",//timide
        "Est-ce que je te plais ?"//addtive //sourire
    };
    public string[] NeutralResponses4 = new string[]
  {
        "Désolé c'est vrai que je dois être chiante...",
        "ça va.. ?",
        "Est-ce que je te plais au moins ? ",
       
  };
    public string[] NegativeResponses4 = new string[]
  {
        "Certes..",
        "Ne t'inquiète pas..",
        "J'irai bientôt mieux..",
        "Avoue que je te plais", // sourir et rougir    
  };

    public string[] PositiveResponses5 = new string[]
    {
        "Je me sens pas très bien..",
        "Je n'ai rien de trouvé de mieux que ça pour me réconforter",
        "Ce n'est pas tout les jours facile pour moi",//rougir
        "Personne ne s'est jamais vraiment intéressé moi",
        "Tu sais..",
        "Je me vraiment bien avec toi !"//additive


    };
    public string[] NeutralResponses5 = new string[]
    {
    "Aller... Tu pourrais jouer le jeux quand même !",
    "Tu es sur que ton engin fonctionne ?",//mépris
    "Je te taquine..",//sourire
    "T'es un garçon intéressant",
    }; 
    public string[] NegativeResponses5 = new string[]
    {   
        "Je m'en doutais",//rire
        "T'arrêtes pas de me fixer depuis out l'heure",
        "Je t'avoue que ça me fait plutôt de l'effet",//sourir + rougir
    
    };

    public string[] PositiveReponses6 = new string[]
    {
        "Je pense qu'on devrait aller chez moi.."
        //Cinématique du swagg


    };

    public string[] NeutralReponses6 = new string[]
    {
        "T'es vraiment ennuyeux comme garçon",//mépris
        "Tu n'as vraiment rien pour toi..",
        "Pourtant, j'ai vraiment essayé.."
        //GAME OVER

    };

    public string[] NegativeReponses6 = new string[]
    {
        "Je pense qu'on devrait aller chez moi.."
        //Cinématique de la mort
    };

    public List<string[]> listedialogue = new List<string[]>();
    private void Awake()
    {
        SheIsTalking = true;
        listedialogue.Add(start);
        listedialogue.Add(PositiveResponses1);
        listedialogue.Add(NeutralResponses1);
        listedialogue.Add(NegativeResponses1);
        listedialogue.Add(PositiveResponses2);
        listedialogue.Add(NeutralResponses2);
        listedialogue.Add(NegativeResponses2);
        listedialogue.Add(PositiveResponses3);
        listedialogue.Add(NeutralResponses3);
        listedialogue.Add(NegativeResponses3);
        listedialogue.Add(PositiveResponses4);
        listedialogue.Add(NeutralResponses4);
        listedialogue.Add(NegativeResponses4);
        listedialogue.Add(PositiveResponses5);
        listedialogue.Add(NeutralResponses5);
        listedialogue.Add(NegativeResponses5);
        listedialogue.Add(PositiveReponses6);
        listedialogue.Add(NeutralReponses6);
        listedialogue.Add(NegativeReponses6);



    }


    //Variable//
    bool SheIsTalking = true;//booléen pour savoir si la meuf est entrain de parler
    bool additive = false;//booléen pour savoir si la phrase continue
    public bool answer = false;//booléen pour savoir si on doit répondre
    public double CoolDownDisplay = 0.5;//Variable pour permettre l'affichage du menu réponse
    int ButtonClick = 0;//Variable pour savoir sur quel bouton on a cliqué 
    bool skip = false;
    bool gameover = false;
    bool end = false;
    bool endnext = false;
    




    public string State = "Smile";



    //Index//
    int SentenceIndex = 0;
    int ListIndex = 0;
    int ResponseIndex = 0;

    bool retry = false;
    bool mansion = false;
  

    void RetryListener()
    {
        retry = true;
    }

    void MansionListener()
    {
        mansion = true;
    }

    //Fonction//
    void SkipListener()
    {
        skip = true;
    }
    void Listener1()
    {
        ButtonClick = 1; Choice.Play();
    }
    void Listener2()
    {
        ButtonClick = 2; Choice.Play();
    }
    void Listener3()
    {
        ButtonClick = 3; Choice.Play();
    }
    void ShortForAnswer()
    {
        SentenceIndex = 0; answer = false; SheIsTalking = true; ResponseIndex += 1; ButtonClick = 0; NextSentence();
    }
   //float lovespeed = 3f * Time.deltaTime;
    void LoveUpFunction(int Love)
    {
        if (Love == 0)
        {
            /* loveprogress = LoveValue + 15;
             LoveValue = Mathf.Lerp(LoveValue, loveprogress, lovespeed);*/
            LoveValue += 15;
            SoundPlay(LoveUpMax);
        }
        else if(Love == 1)
        {
            LoveValue += 5;
            SoundPlay(LoveUp);
        }
        
    }
    void LoveDown()
    {
        if (LoveValue > 0)
        {
            LoveValue -= 10;
            SoundPlay(Fail);
        }
    }
    void NextSentence()
    {
        dialogue.Say(listedialogue[ListIndex][SentenceIndex], additive);
        SentenceIndex++;
        additive = false;
    }
    void DisplayResponseScreen()
    {
        if (answer && dialogue.stop &&!gameover)
        {
            if (!ResponsesPannel.active)
            {
                CoolDownDisplay -= Time.deltaTime;
            }
            if (CoolDownDisplay < 0 && !ResponsesPannel.active)
            {
                ResponsesPannel.SetActive(true);
                CoolDownDisplay = 0.5;

            }
        }
        if (!answer || gameover)
        {
            ResponsesPannel.SetActive(false);
        }
    }
    void ListOfResponsesChoice()
    {
        switch (ResponseIndex) {
            case 0:
                Reponse1.text = "Avec plaisir !";
                Reponse2.text = "C'est moi qui te le paye !";
                Reponse3.text = "Non merci";

                if (answer)
                    {
                    switch (ButtonClick) {
                        default:
                            break;
                        case 1:
                            ListIndex = 1; ShortForAnswer(); LoveUpFunction(0);
                            break;
                        case 2:
                            ListIndex = 2; ShortForAnswer(); LoveDown();
                            break;
                        case 3:
                            ListIndex = 3; ShortForAnswer(); LoveUpFunction(1);
                            break;
                    } 
        
                }

                break;
            case 1:
                Reponse1.text = "Tu viens souvent ici ? ";
                Reponse2.text = "Tu as l'air d'être vachement jeune !";
                Reponse3.text = "T'es un peu bizarre comme fille...";
                if (answer)
                {
                    switch (ButtonClick)
                    {
                        default:
                            break;
                        case 1:
                            ListIndex = 5; ShortForAnswer(); LoveUpFunction(0);
                            break;
                            
                        case 2:
                            ListIndex = 4; ShortForAnswer(); LoveDown();
                            break;
                        case 3:
                            ListIndex = 6; ShortForAnswer(); LoveUpFunction(1);
                            break;
                    }
                }
                break;
            case 2:
                Reponse1.text = "Tu sais que je suis un gros pervers ?";
                Reponse2.text = "Je suis pas un garçon comme ça";
                Reponse3.text = "Tu devrais faire attention";
                switch (ButtonClick)
                {
                    default:break;
                    case 1:
                        ListIndex = 8; ShortForAnswer(); LoveUpFunction(1); break;
                    case 2:
                        ListIndex = 9; ShortForAnswer(); LoveDown(); break;
                    case 3:
                        ListIndex = 7; ShortForAnswer(); LoveUpFunction(0); break;
                }
                break;
            case 3:
                Reponse1.text = "Tu veux en parler ?";
                Reponse2.text = "T'as vraiment un souci";
                Reponse3.text = "Tu devrais éviter d'y penser";

                switch (ButtonClick)
                {
                    default:break;
                    case 1:
                        ListIndex = 10; ShortForAnswer(); LoveUpFunction(0); break;
                    case 2:
                        ListIndex = 11; ShortForAnswer(); LoveUpFunction(1); break;
                    case 3:
                        ListIndex = 12; ShortForAnswer(); LoveDown(); break;
                      
                }
                break;
            case 4:
                Reponse1.text = "Ouai grave !";
                Reponse2.text = "Ce n'est pas ça qui m'intéresse..";
                Reponse3.text = "Pourquoi tu dis ça ?";
                switch (ButtonClick)
                {

                    default: break;
                    case 1:
                        ListIndex = 15; ShortForAnswer(); LoveDown(); break;
                     
                    case 2:
                        ListIndex = 14; ShortForAnswer(); LoveUpFunction(1); break;
                       
                    case 3:
                        ListIndex = 13; ShortForAnswer(); LoveUpFunction(0); break;

                }
                break;
            case 5:
                Reponse1.text = "On devrait aller dans un endroit plus intime";
                Reponse2.text = "On devrait apprendre à se connaitre";
                Reponse3.text = "Toi aussi";

                switch (ButtonClick)
                {
                    default: break;
                    case 1: SentenceIndex = 0; answer = false; SheIsTalking = true; ResponseIndex += 1; ButtonClick = 0; LoveDown(); end = true; break;
                    case 2: SentenceIndex = 0; answer = false; SheIsTalking = true; ResponseIndex += 1; ButtonClick = 0; LoveUpFunction(0); end = true; break;
                    case 3: SentenceIndex = 0; answer = false; SheIsTalking = true; ResponseIndex += 1; ButtonClick = 0; LoveUpFunction(1); end = true; break;
                }

                break;


           
    }   } 


    void StartDialogue()
    {
        if (skip && !answer)
        {
            skip = false;
            if (!dialogue.isSpeaking || dialogue.isWaitingForUserInput)
            {

                if (SheIsTalking)
                {
                    NextSentence();
                    if (SentenceIndex >= listedialogue[ListIndex].Length)
                    {
                        SheIsTalking = false; answer = true; return;
                    }

                }
            }

        }
    }

    void AnimationManager()
    {
        Amelia.Anim.Play(State);

    }
    void Animation()
    {

        switch(ListIndex)
        {
            default: break;

            case 0:

                switch (SentenceIndex)
                {
                    default: additive = false; break;
                    case 1: additive = true; SoundPlay(EmEm);break;
                    case 2: SoundPlay(Hello); break;
                    case 3: SoundPlay(OhEm);break;
                    case 4: State = "Normal";SoundPlay(ISee); break;
                    case 5: SoundPlay(Timetospendwithme);break;
                }

            break;

            case 1:
                switch(SentenceIndex)
                {
                    default: break;
                    case 1: State = "Smile"; SoundPlay(Well); break;
                    case 3: State = "ShyBlush"; SoundPlay(Umm); break;
                    case 5: SoundPlay(WellEmm);break;
                    case 6: SoundPlay(EuhEmm); break;

                }
                break;
            case 2:
                switch (SentenceIndex)
                {
                    default: additive = false; break;
                    case 1: State = "Smile";SoundPlay(Laugh); break;
                    case 2: additive = true; SoundPlay(Well);break;
                    case 4: SoundPlay(EuhEmm); State = "ShyBlush";break;
                    
                }
                break;
            case 3:
                switch (SentenceIndex)
                {
                    default:break;
                    case 1: State = "Angry"; SoundPlay(Oh); break;
                    case 2: SoundPlay(EuhEmm);break;
                    case 3: SoundPlay(HoldOn); State = "Smile";break;
                }
                break;
            case 4:
                switch (SentenceIndex)
                {
                    default: break;
                    case 1: SoundPlay(Hey); State = "Peaceful"; break;
                    case 2: SoundPlay(Hmm);State = "Shy"; break;
                    case 3: SoundPlay(Actually);State = "ShyBlush"; break;
                }
                break;

            case 5:
                switch (SentenceIndex) {
                    case 1: SoundPlay(No); State = "Smile"; break;
                    case 3: SoundPlay(Actually);State = "Bored"; break;
                        }
                break;

            case 6:
                switch (SentenceIndex)
                {
                    default: break;
                    case 1: State = "AngryBlush"; SoundPlay(Euh); break;
                    case 2: State = "Proud"; SoundPlay(WellEmm); break;
                    case 4: SoundPlay(Actually); break;
                    case 5: State = "ShyBlush";break;
                    case 6: State = "Bored"; SoundPlay(Well);break;

                }
                break;
            case 7:

                switch (SentenceIndex)
                {
                    default: break;
                    case 1: SoundPlay(Ohem);State = "ShyBlush";break;
                    case 3: SoundPlay(Interesting); State = "Smile"; break;
                    case 4: SoundPlay(Well);break;
                    case 5: SoundPlay(ReallyDepressing); State = "Cry"; break;
                }
                break;
            case 8:

                switch (SentenceIndex)
                {
                    default: break;
                    case 1: SoundPlay(Han);State = "ShyBlush";break;
                    case 2: SoundPlay(IsthatSo); State = "Smile"; break;
                    case 3: SoundPlay(WellEmm);State = "Normal"; break;
                    case 5: SoundPlay(ReallyDepressing); State = "Cry"; break;


                }
                break;
            case 9:

                switch (SentenceIndex)
                {
                    default: break;
                    case 1: SoundPlay(Umm); State = "Bored"; break;
                    case 3: SoundPlay(Isuppose);break;
                    case 5: SoundPlay(ReallyDepressing); State = "Cry"; break;

                }
                break;
            case 10:
                switch (SentenceIndex)
                {
                    default: additive = false; break;
                    case 1: State = "SmileBlush";SoundPlay(Han); break;
                    case 2: SoundPlay(No); State = "Normal";break;
                    case 4: additive = true; SoundPlay(Deception);break;
                    case 5: SoundPlay(ThankYou); State = "Peaceful"; break;
                    case 6: SoundPlay(Well); State = "ShyBlush"; break;
                    case 7: SoundPlay(Laugh);break;
                    
                }
                break;

            case 11:
                switch (SentenceIndex)
                {
                    default: break;
                    case 1:State = "Normal"; SoundPlay(Sorry); break;
                    case 3: SoundPlay(Well); break;
                }
                break;

            case 12:
                switch (SentenceIndex)
                {
                    default: break;
                    case 1: SoundPlay(Yes);State = "Bored"; break;
                    case 3: SoundPlay(Sure); break;
                    case 4: SoundPlay(Laugh);State = "Smile"; break;
                }
                break;
            case 13:
                switch (SentenceIndex)
                {
                    default: break;
                    case 1: State = "Bored"; SoundPlay(Deception);break;
                    case 2: State = "SmileBlush"; SoundPlay(Laugh);break;

                }
                break;
            case 14:
                switch (SentenceIndex)
                {
                    default: break;
                     
                    case 1: SoundPlay(Joking); State = "Bored";break;
                    case 2: SoundPlay(Laugh); State = "Smile"; break;
                    case 4: SoundPlay(Interesting); break;
                }
                break;
            case 15:
                switch (SentenceIndex)
                {
                    default: break;
                    case 1:SoundPlay(AlrightThen); State = "Smile";break;
                    case 2: SoundPlay(Understand); State = "SmileBlush"; break;
                    case 3: SoundPlay(Laugh); break;
                }
                break;
            case 16:
                switch (SentenceIndex)
                {
                    default: break;
                    case 1: State = "ShyBlush"; SoundPlay(OkwithYou); break;
                }
                break;
            case 17:
                switch (SentenceIndex)
                {
                    default: break;
                    case 1: SoundPlay(Deception); State = "Bored"; break;
                    case 3: SoundPlay(Well); break;
                }
                break;
            case 18:
                switch (SentenceIndex)
                {
                    default: break;
                    case 1: State = "Smile"; SoundPlay(GoHome); break;
                }
                break;


        }

    }

void SoundPlay(AudioSource sound)
    {
        if (!sound.isPlaying)
        {
            sound.Play();
        }
    }

    void Start()
    {
        dialogue = VisualDialogueSystem.instance;
        NextSentence();
        ResponsesPannel.SetActive(false);
        GameOverPannel.SetActive(false);
        Button1.onClick.AddListener(Listener1);
        Button2.onClick.AddListener(Listener2);
        Button3.onClick.AddListener(Listener3);
        SkipButton.onClick.AddListener(SkipListener);
        Retry.onClick.AddListener(RetryListener);
        Mansion.onClick.AddListener(MansionListener);


    }




    void Update()
    {
        LoveBar.value = LoveValue;
        StartDialogue();
        DisplayResponseScreen();
        ListOfResponsesChoice();

        AnimationManager();
        Animation();

        switch (ListIndex)
        {
            default: break;
            case 16:
                switch (SentenceIndex)
                {
                    default: break;
                    case 1:winbool = true; break;
                }
                break;
            case 17:
                switch (SentenceIndex)
                {
                    default: break;
                    case 3: gameover = true;SheIsTalking = false;  break;
                }
                break;
            case 18:
                switch (SentenceIndex)
                {
                    default: break;
                    case 1: loosebool = true; break;
                }
                break;
           
        }

        if(LoveValue >= 50)
        {
            LoveValue = 50;
        }
        if(LoveValue <= 0)
        {
            LoveValue = 0;
        }
        if(winbool == true || loosebool == true)
        {
            win -= Time.deltaTime;
        }
        if(win < 0 && winbool)
        {
            SceneManager.LoadScene(8);
        }
        if(win < 0 && loosebool)
        {
            SceneManager.LoadScene(7);
        }
        if (retry)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            retry = false;
        }
        if (mansion)
        {
            GameManager.instance.failedMission(5);
            SceneManager.LoadScene(2);
        }
        if (gameover)
        {
            CoolDownDisplay -= Time.deltaTime;
            if (CoolDownDisplay < 0)
            {
                GameOverPannel.SetActive(true);
                OST.Stop();
                SoundPlay(OST2);
                CoolDownDisplay = 0.5;
            }
        }
        if(end && LoveValue != 0 && LoveValue != 50)
        {
            endnext = true;
            if (endnext)
            {
                CoolDownDisplay = 1.5;
                ListIndex = 17;
                NextSentence();
                endnext = false;
                end = false;
            }
            ListIndex = 17;
      
        }
        if (end && LoveValue == 50)
        {
            endnext = true;
            if (endnext)
            {
                CoolDownDisplay = 1.5;
                ListIndex = 16;
                NextSentence();
                endnext = false;
                end = false;
            }
            

        }
        if (end && LoveValue == 0)
        {
            endnext = true;
            if (endnext)
            {
                CoolDownDisplay = 1.5;
                ListIndex = 18;
                NextSentence();
                endnext = false;
                end = false;
            }
        

        }


    }



}
