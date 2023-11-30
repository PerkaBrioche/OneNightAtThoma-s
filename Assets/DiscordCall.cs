using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DiscordCall : MonoBehaviour
{
    public int RandomCall;
    public GameObject PanelDiscord;
    public GameObject DiscordSound;
    public float CoolDown;
    public bool CanCall;
    public int Soustraction;
    public Animatronic Animatronic;
    public bool iscalling;
    public PhoneCall PhoneCall;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForCall());
    }

    // Update is called once per frame
    void Update()
    {
        if(CanCall && PhoneCall.EndCall)
        {
            RandomCall = Random.Range(0, 10);
            if (RandomCall == 0)
            {
                CanCall = false;
                DiscordSound.SetActive(true);
                PanelDiscord.SetActive(true);
                iscalling = true;
            }
            else
            {
                CanCall = false;
                StartCoroutine(WaitForCall());
            }
        }
    }
    public void HangUP()
    {
        CanCall = true;
        DiscordSound.SetActive(false);
        PanelDiscord.SetActive(false);
        StartCoroutine(WaitForCall());
        iscalling = false;
    }
    IEnumerator WaitForCall()
    {
        yield return new WaitForSeconds(12- Animatronic.difficulty);
        CanCall = true;
    }
}
