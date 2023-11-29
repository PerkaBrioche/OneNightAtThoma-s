using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    public float CoolDown;
    public GameObject LightPosR;
    public GameObject LightPosL;
    public Animator OfficeAnim;
    public Animator PlayerAnim;
    public GameObject Light;
    public GameObject CameraButton;
    public bool Canflash;
    public bool HeadReady;
    public GameObject BatteryUI;
    public bool Turned;
    public Light FlashLight;

    public bool cansound;


    public AudioSource PlayerSource;

    public AudioClip ReturnHead;
    public AudioClip BackHead;
    public AudioClip Flash;
    public AudioClip DeFlash;
    public AudioClip Zap;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Canflash = true;
        cansound = true;
        HeadReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Turned && HeadReady)
        {
            if (Input.GetKey("t")) 
            {
                if (cansound)
                {
                    cansound = false;
                    PlayerSource.PlayOneShot(Flash);

                }
                FlashLight.enabled = true;
            }
            if (Input.GetKeyUp("t"))
            {
                cansound = true;
                PlayerSource.PlayOneShot(DeFlash);
                FlashLight.enabled = false;
            }
        }
        else
        {
        }
        if (Input.GetKeyDown("a") && Canflash)
        {
            PlayerSource.PlayOneShot(Zap);

            Light.transform.position = LightPosL.transform.position;
            StartCoroutine(WaitFlash());
        }
        if (Input.GetKeyDown("e") && Canflash)
        {
            PlayerSource.PlayOneShot(Zap);

            Light.transform.position = LightPosR.transform.position;
            StartCoroutine(WaitFlash());
        }
    }
    IEnumerator WaitFlash()
    {
        for(int i = 0; i < BatteryUI.transform.childCount;  i++) 
        {
            BatteryUI.transform.GetChild(i).gameObject.SetActive(false);
        }

        OfficeAnim.Play("LightFlash");
        Canflash = false;
        yield return new WaitForSeconds(CoolDown/3);
        BatteryUI.transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(CoolDown / 1.5f);
        BatteryUI.transform.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSeconds(CoolDown);
        BatteryUI.transform.GetChild(2).gameObject.SetActive(true);
        Canflash = true;
    }
    public void TurnHead()
    {
        if (Turned == false && HeadReady)
        {
            CameraButton.SetActive(false);

            StartCoroutine(WaitHead());
            PlayerAnim.Play("TurnHead");
            Turned = true;
            PlayerSource.PlayOneShot(ReturnHead);

        }
        else if(Turned && HeadReady)
        {
            StartCoroutine(WaitHead());
            PlayerAnim.Play("BackHead");
            Turned = false;
            CameraButton.SetActive(true);
            PlayerSource.PlayOneShot(BackHead);


        }
    }
    IEnumerator WaitHead()
    {
        HeadReady = false;
        yield return new WaitForSeconds(1.1f);
        HeadReady = true;

    }

}
