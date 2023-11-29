using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animatronic : MonoBehaviour
{
    public int difficulty;
    public bool Action;
    public bool Detected;
    public int RandomNum;
    public int ActualPos;
    public AllPos[] MonsterPos;
    public int ReturnInt;
    public bool Conduiting;
    public bool HallWayingL;
    public bool HallWayingR;
    public bool Attacking;
    public int ConduitInt;
    public int HallWay;
    public bool GoingScream;
    public DiscordCall DiscordCall;
    public GameObject DeathScreen;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitAction());
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
        if(Action)
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
            int Attack = Random.Range(0,4);
            if (Attack == 3)
            {
                print("BAT EN RETRAIRE !");
                int Han = Random.Range(0, 15);
                ActualPos = Han;
            }
            else
            {
                Attacking = true;
                if (MonsterPos[ActualPos].Conduit && MonsterPos[ActualPos].LeftHaLLWAY || MonsterPos[ActualPos].RightHaLLWAY)
                {
                    print("ATTACK ! A le choix varier");
                    int Burgerplssss = Random.Range(0, 3);
                    if (Burgerplssss == 1)
                    {
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
                }
                else if (MonsterPos[ActualPos].RightHaLLWAY)
                {

                }
                else if (MonsterPos[ActualPos].LeftHaLLWAY)
                {

                }
            }
        }
        else
        {
            int Han = Random.Range(0,15);
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
    IEnumerator WaitAction()
    {
        int Cooll = 12 - difficulty;
        print("Cooll" + Cooll);
        if (DiscordCall.iscalling)
        {
            Cooll = Cooll/ 2;
            print("DIVISEZ PAS DEUX" + Cooll);
        }
        else
        {

        }
        yield return new WaitForSeconds(Cooll);
        if (GoingScream)
        {
            print("perdu");
            DeathScreen.SetActive(true);
        }
        else
        {
            Action = true;
        }
    }
    public void ResetThomas()
    {
        Detected = true;
        transform.position = MonsterPos[ReturnInt-1].Pos.transform.position;
        StartCoroutine(DetectedWait());
    }
    IEnumerator DetectedWait()
    {
        yield return new WaitForSeconds(15f);
        ActualPos = Random.Range(0, 15);
        Detected = false;
        Attacking = false;
        Conduiting = false;
        HallWayingL = false;
        HallWayingR = false;
        ConduitInt =0;
        HallWay = 0;
        
        

    }
}
