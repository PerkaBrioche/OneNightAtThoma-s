using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RepairCam : MonoBehaviour
{
    public Animator CanvasAnim;
    public int Temperature;
    public TextMeshProUGUI TemmpText;
    public bool Refroidissement;
    public bool Rechauffement;
    public bool canloose;
    public bool RepairOpen;
    public float Timing;
    public GameObject BehindButton;
    public GameObject RepairPanel;
    public GameObject RepairButton;
    public Action Action;
    public Animator PlayerAnim;
    public AudioSource PlayerSource;
    public AudioClip CloseCam;
    public AudioClip OpenCamS;

    public Texture PlayBut;
    public Texture PauseBut;

    public GameObject HeatLogo;
    public GameObject ColdLogo;

        public RawImage ChauffageRaw;
    public RawImage ClimRaw;

    public Animatronic Animatronic;
    public PhoneCall PhoneCall;

    // Start is called before the first frame update
    void Start()
    {
        Temperature = 60;
        canloose = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (PhoneCall.EndCall)
        {


            if (Temperature <= 0)
            {
                Animatronic.Scream();
            }
            if (Temperature < 20 && Temperature >= 10)
            {
                CanvasAnim.Play("TemperatureGlace");

            }
            if (Temperature < 10)
            {
                CanvasAnim.Play("TemperatureExtremeGlace");
            }
            if (Temperature < 30 && Temperature >= 20)
            {
                CanvasAnim.Play("TemperatureCold");
            }
            else
            {

            }


            TemmpText.text = Temperature.ToString() + "°";
            if (Refroidissement)
            {
                HeatLogo.SetActive(false);
                ColdLogo.SetActive(true);
                TemmpText.color = Color.blue;
                ClimRaw.texture = PauseBut;
                ChauffageRaw.texture = PlayBut;
                RepairButton.SetActive(false);
                Timing += Time.deltaTime;
                if (Timing >= 0.5f)
                {
                    Timing = 0;
                    Temperature--;
                }
            }
            else if (Rechauffement)
            {
                TemmpText.color = Color.red;
                HeatLogo.SetActive(true);
                ColdLogo.SetActive(false);
                ClimRaw.texture = PlayBut;
                ChauffageRaw.texture = PauseBut;
                RepairButton.SetActive(false);
                Timing += Time.deltaTime;
                if (Timing >= 0.25f && Temperature < 60)
                {
                    Timing = 0;
                    Temperature++;
                }
            }
            else if (Action.Turned)
            {
                ClimRaw.texture = PlayBut;
                ChauffageRaw.texture = PlayBut;
                HeatLogo.SetActive(false);
                TemmpText.color = Color.white;

                ColdLogo.SetActive(false);
                RepairButton.SetActive(true);
            }
            else
            {
                RepairButton.SetActive(false);
            }
            if (Rechauffement == false && Refroidissement == false && canloose)
            {
                StartCoroutine(WaitLoose());
            }
        }
    }
    public void Cold()
    {
        if (Refroidissement)
        {
            Refroidissement = false;
            
        }
        else if(Rechauffement)
        {
            Refroidissement = true;
            Rechauffement = false;
        }
        else
        {
            Refroidissement = true;
        }
    }
    public void WarmUp()
    {
        if (Rechauffement)
        {
            Rechauffement = false;
        }
        else if(Refroidissement)
        {
            Rechauffement = true;
            Refroidissement = false;
        }
        else
        {
            Rechauffement = true;

        }
    }
    IEnumerator WaitLoose()
    {
        canloose = false;

        yield return new WaitForSeconds(1.5f);
        canloose = true;
        Temperature --;
    }
    public void OpenCam()
    {
        if (RepairOpen)
        {
            PlayerSource.PlayOneShot(CloseCam);
            PlayerAnim.Play("CloseCamera");

            BehindButton.SetActive(true);
            RepairPanel.SetActive(false);
            PlayerSource.PlayOneShot(CloseCam);

            RepairOpen = false;
        }
        else
        {
            PlayerAnim.Play("WatchCamera");
            StartCoroutine(WaitScreen());
            RepairOpen = true;


        }
    }
    IEnumerator WaitScreen()
    {


        PlayerSource.PlayOneShot(OpenCamS);
        yield return new WaitForSeconds(0.2f);
        RepairPanel.SetActive(true);
        BehindButton.SetActive(false);
    }
      
}
