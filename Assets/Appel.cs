using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appel : MonoBehaviour
{
    public GameObject BatteryAppel;
    public float Cooldown;
    public bool CanCall;
    public Animator CamAnim;
    public Animator CanvasAnim;
    public Animatronic Animatronic;
    public CameraChoice CameraChoice;
    public GameObject SignalSonore;
    public GameObject CameraButton;
    public GameObject ThomasTrigger;

    public AudioClip Suicide1;
    public AudioClip Suicide2;
    public AudioClip Suicide3;
    public AudioSource CamSource;

    public GameObject LightCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        CanCall = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Calling()
    {
        if (CanCall)
        {
            LightCamera.SetActive(false);
            int han = Random.Range(0, 3);
            if(han == 0)
            {
                CamSource.PlayOneShot(Suicide1);
            }
            if (han == 1)
            {
                CamSource.PlayOneShot(Suicide2);

            }
            if (han == 2)
            {
                CamSource.PlayOneShot(Suicide3);

            }
            ThomasTrigger.transform.position = CameraChoice.AllCamera[CameraChoice.CameraChoose].CameraPos.transform.position;
            if(Animatronic.ConduitInt > 0)
            {
                print("NE PEUT PAS ETRE ENTENDU !");
            }
            else
            {
                ThomasTrigger.SetActive(true);
            }

            CameraButton.SetActive(false);
            SignalSonore.transform.position = CameraChoice.AllCamera[CameraChoice.CameraChoose].SignalPos.transform.position;
            CanvasAnim.Play("Signal");
            CamAnim.Play("Reload");
            CanCall = false;
            for (int i = 0; i < BatteryAppel.transform.childCount; i++)
            {
                BatteryAppel.transform.GetChild(i).gameObject.SetActive(false);
            }
            StartCoroutine(WaitCall());
            StartCoroutine(BackUpCamera());
        }
    }
    IEnumerator WaitCall()
    {
        float Wait = Cooldown / 10;

        int o = 0;
        while (o < BatteryAppel.transform.childCount)
        {
            yield return new WaitForSeconds(Wait);
            BatteryAppel.transform.GetChild(o).gameObject.SetActive(true);
            o++;
            print(o + "o");
        }

        CanCall = true;

    }
    IEnumerator BackUpCamera()
    {
        yield return new WaitForSeconds(5);
        CameraButton.SetActive(true);
        ThomasTrigger.SetActive(false);
        LightCamera.SetActive(true);
    }

}
