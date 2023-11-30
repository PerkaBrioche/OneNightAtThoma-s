using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Animatronic : MonoBehaviour
{
    public int difficulty;
    public bool Action;
    public bool Detected;
    public int RandomNum;
    public int ActualPos;
    public int Life;
    public AllPos[] MonsterPos;
    public int ReturnInt;
    public float Timing;
    public bool Conduiting;
    public bool Gel;
    public bool HallWayingL;
    public bool Firstime;
    public bool HallWayingR;
    public bool Attacking;
    public int ConduitInt;
    public int HallWay;
    public bool GoingScream;
    public DiscordCall DiscordCall;
    public GameObject DeathScreen;
    public bool EndGame;
    public Animator PlayerAnim;
    public GameObject CameraPanel;
    public GameObject RepairPanel;
    public RepairCam RepairCam;

    public Animator ThomasAnim;
    public PhoneCall PhoneCall;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitAction());
        difficulty = PlayerPrefs.GetInt("Difficulty") + 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(Detected == false)
        {
            transform.position = MonsterPos[ActualPos].Pos.transform.position;
            transform.rotation = MonsterPos[ActualPos].Pos.transform.rotation;
        }
        else
        {

        }
        if(Action && Gel == false && PhoneCall.EndCall && Detected == false)
        {
            print("Thomas Actionne");
            Action = false;
            RandomNum = Random.Range(0, 11 - difficulty);
            if(RandomNum == 0)
            {
                Moove();
            }
            else
            {
                print("C'est un flop !");
                StartCoroutine(WaitAction());
            }
        }
        if(ConduitInt > 0 && RepairCam.Rechauffement)
        {
            StartCoroutine(Screamer());
        }
        if (ConduitInt >0 && RepairCam.Refroidissement)
        {
            Gel = true;
        }
        else
        {
            if (Gel)
            {
                StartCoroutine(WaitGel());
            }
            else
            {
                Gel = false;

            }
        }
        if (Gel)
        {
            print("LIFE = "+ Life);
            if (Life <= 0 && Firstime)
            {
                Timing = 0;
                Firstime = false;
                ActualPos = Random.Range(0, 14);
                Detected = false;
                Attacking = false;
                Conduiting = false;
                HallWayingL = false;
                HallWayingR = false;
                GoingScream = false;
                ConduitInt = 0;
                HallWay = 0;
            }

            if (Firstime)
            {
                print("GLAGLOUQGLAGLOUQ");

                Timing += Time.deltaTime;
                if (Timing >= 0.5f)
                {
                    print("Reset Timer");

                    Timing = 0;
                    Life--;
                }
            }
            else
            {
                print("Attributyion Life");

                Firstime = true;
                Life = Random.Range(10, 22);

            }


        }

    }
    public void Moove()
    {
        if (Attacking)
        {
            if (Conduiting)
            {

                ConduitInt++;
                if(ConduitInt == 1)
                {
                    ActualPos = 16;
                }
                else if(ConduitInt == 2)
                {
                    ActualPos = 17;
                }
                else if(ConduitInt == 3)
                {
                    ActualPos = 18;
                    GoingScream = true;
                }
            }
            else if(HallWayingR)
            {
                HallWay++;
                if (HallWay == 1)
                {
                    ActualPos = 20;
                }
                else if (HallWay == 2)
                {
                    ActualPos = 21;
                    GoingScream = true;
                }
            }
            else if (HallWayingL)
            {
                HallWay++;
                if (HallWay == 1)
                {
                    ActualPos = 23;
                }
                else if (HallWay == 2)
                {
                    ActualPos = 24;
                    GoingScream = true;
                }
            }

            
        }
        else if (MonsterPos[ActualPos].canAttack)
        {
            //  int Attack = Random.Range(0,5);
            //if (Attack == 3)
            //  {
            //      print("BAT EN RETRAIRE !");
            //      int Han = Random.Range(0, 15);
            //      ActualPos = Han;
            //  }
            //  else
            //  {
            print("IL PEUT ATTAQUER");
            Attacking = true;
                if (MonsterPos[ActualPos].Conduit && MonsterPos[ActualPos].LeftHaLLWAY || MonsterPos[ActualPos].RightHaLLWAY)
                {
                    print("ATTACK ! A le choix varier");
                    int Burgerplssss = Random.Range(0, 3);
                    if (Burgerplssss == 1)
                    {
                    ThomasAnim.Play("Conduit");

                    print(Burgerplssss);
                        print("GO DANS LES CONDUITS !");
                        ActualPos = 15;
                        Conduiting = true;
                        
                    }
                    else
                    {
                        print("Couloirs !");
                        if (MonsterPos[ActualPos].RightHaLLWAY)
                        {
                            print("DROIT");
                            HallWayingR = true;
                            ActualPos = 19;

                        }
                        else
                        {
                            HallWayingL = true;

                            print("Gauche");
                            ActualPos = 22;

                        }
                    }

                }
                else if (MonsterPos[ActualPos].Conduit)
                {
                    print("GO DANS LES CONDUITS !");
                    ActualPos = 15;
                    Conduiting = true;
                    ThomasAnim.Play("Conduit");

                }
            else if (MonsterPos[ActualPos].RightHaLLWAY)
                {
                    HallWayingR = true;
                    ActualPos = 19;
                }
                else if (MonsterPos[ActualPos].LeftHaLLWAY)
                {

                    HallWayingL = true;

                    print("Gauche");
                    ActualPos = 22;

                }
           // }
        }
        else
        {
            int Han = Random.Range(0,14);
            ActualPos = Han;
        }
        print("nouvelle Action");
        StartCoroutine(WaitAction());


    }

    [System.Serializable]
    public class AllPos
    {
        public GameObject Pos;
        public bool canAttack;
        public bool Conduit;
        public bool LeftHaLLWAY;
        public bool RightHaLLWAY;
        public bool IsAttacking;
    }
    public void Scream()
    {
        StartCoroutine(Screamer());

    }
    IEnumerator WaitAction()
    {
        if (EndGame == false)
        {


            int Cooll = 12 - difficulty;
            print("Cooll" + Cooll);
            if (DiscordCall.iscalling)
            {
                Cooll = Cooll / 2;
                print("DIVISEZ PAS DEUX" + Cooll);
            }
            else
            {

            }
            yield return new WaitForSeconds(Cooll);
            if (GoingScream)
            {
                StartCoroutine(Screamer());
            }
            else
            {
                Action = true;
            }
        }
    }
    public void ResetThomas()
    {
        if(ConduitInt > 0)
        {
            print("DANS LES CONDUITS INTOUCHABLE");
        }
        else
        {
            print("RETOUR A LA CASE RETURNIT = " + ReturnInt);
            ThomasAnim.Play("Normal");

            Detected = true;
            transform.position = MonsterPos[ReturnInt - 1].Pos.transform.position;
            transform.rotation = MonsterPos[ReturnInt - 1].Pos.transform.rotation;
            StartCoroutine(DetectedWait());
            Attacking = false;
            Conduiting = false;
            HallWayingL = false;
            HallWayingR = false;
            GoingScream = false;
            ConduitInt = 0;
            HallWay = 0;
        }

    }
    IEnumerator WaitGel()
    {
        print("ON ATTEND LE GEL");
        yield return new WaitForSeconds(1.5f);
        Gel = false;
        print("Gel finit");

    }
    IEnumerator Screamer()
    {
        Destroy(CameraPanel);
        Destroy(RepairPanel);
        PlayerAnim.Play("Screaler");
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        yield return new WaitForSeconds(1);
        DeathScreen.SetActive(true);
        Application.Quit();
    }
    IEnumerator DetectedWait()
    {
        yield return new WaitForSeconds(15f);
        ActualPos = Random.Range(0, 14);
        Detected = false;
        Attacking = false;
        Conduiting = false;
        HallWayingL = false;
        HallWayingR = false;
        GoingScream = false;
        ConduitInt = 0;
        HallWay = 0;



    }
}
