using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CameraChoice : MonoBehaviour
{
    
    public ListCamera[] AllCamera;
    public GameObject Camera;
    public int CameraChoose;
    public TextMeshProUGUI CamName;
    public TextMeshProUGUI CamDescription;
    public GameObject CameraPanel;
    public GameObject BehindButton;
    public GameObject BatteryPanel;
    public bool CameraOpen;
    public Animator PlayerAnim;

    public AudioSource PlayerSource;

    public AudioClip OpenCam;
    public AudioClip CloseCam;
    public AudioClip ChangeCa;

    public Image CamObj1;
    public Image CamObj2;
    public Image CamObj3;
    public Image CamObj4;
    public Image CamObj5;
    public Image CamObj6;
    public Image CamObj7;
    public Image CamObj8;

    // Start is called before the first frame update
    void Start()
    {
        CameraChoose = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (AllCamera[CameraChoose].Broken)
        {
            Camera.transform.GetChild(2).gameObject.SetActive(true);
        }
        else
        {
            Camera.transform.GetChild(2).gameObject.SetActive(false);
        }
        Camera.transform.position = AllCamera[CameraChoose].CameraPos.transform.position;
        Camera.transform.rotation = AllCamera[CameraChoose].CameraPos.transform.rotation;
        CamName.text = AllCamera[CameraChoose].CameraName;
        CamDescription.text = AllCamera[CameraChoose].CameraDescription;
      //  SignalSonore.transform.position = AllCamera[CameraChoose].SignalPos.transform.position;
    }
    [System.Serializable]
    public class ListCamera
    {
        public string CameraName;
        public string CameraDescription;
        public GameObject CameraPos;
        public GameObject SignalPos;
        public bool Broken;
        public int ThomasPos;
    }
    public void CameraClick()
    {
        if (CameraOpen)
        {
            PlayerSource.PlayOneShot(CloseCam);
            Camera.SetActive(false);
            PlayerAnim.Play("CloseCamera");
            CameraOpen = false;
            CameraPanel.SetActive(false);
            BehindButton.SetActive(true);
            BatteryPanel.SetActive(true);
        }
        else
        {

            PlayerAnim.Play("WatchCamera");
            StartCoroutine(WaitScreen());
        }

    }
    public void Cam1()
    {
        PlayerSource.PlayOneShot(ChangeCa);
        CamObj1.color = Color.gray;
        CamObj2.color = Color.white;
        CamObj3.color = Color.white;
        CamObj4.color = Color.white;
        CamObj5.color = Color.white;
        CamObj6.color = Color.white;
        CamObj7.color = Color.white;
        CamObj8.color = Color.white;
        CameraChoose = 0;
    }
    public void Cam2()
    {
        PlayerSource.PlayOneShot(ChangeCa);

        CameraChoose = 1;
        CamObj1.color = Color.white;
        CamObj2.color = Color.gray;
        CamObj3.color = Color.white;
        CamObj4.color = Color.white;
        CamObj5.color = Color.white;
        CamObj6.color = Color.white;
        CamObj7.color = Color.white;
        CamObj8.color = Color.white;
    }
    public void Cam3()
    {
        PlayerSource.PlayOneShot(ChangeCa);

        CameraChoose = 2;
        CamObj1.color = Color.white;
        CamObj2.color = Color.white;
        CamObj3.color = Color.gray;
        CamObj4.color = Color.white;
        CamObj5.color = Color.white;
        CamObj6.color = Color.white;
        CamObj7.color = Color.white;
        CamObj8.color = Color.white;
    }
    public void Cam4()
    {
        PlayerSource.PlayOneShot(ChangeCa);

        CameraChoose = 3;
        CamObj1.color = Color.white;
        CamObj2.color = Color.white;
        CamObj3.color = Color.white;
        CamObj4.color = Color.gray;
        CamObj5.color = Color.white;
        CamObj6.color = Color.white;
        CamObj7.color = Color.white;
        CamObj8.color = Color.white;
    }
    public void Cam5()
    {
        PlayerSource.PlayOneShot(ChangeCa);

        CameraChoose = 4;
        CamObj1.color = Color.white;
        CamObj2.color = Color.white;
        CamObj3.color = Color.white;
        CamObj4.color = Color.white;
        CamObj5.color = Color.gray;
        CamObj6.color = Color.white;
        CamObj7.color = Color.white;
        CamObj8.color = Color.white;
    }
    public void Cam6()
    {
        PlayerSource.PlayOneShot(ChangeCa);

        CameraChoose = 5;
        CamObj1.color = Color.white;
        CamObj2.color = Color.white;
        CamObj3.color = Color.white;
        CamObj4.color = Color.white;
        CamObj5.color = Color.white;
        CamObj6.color = Color.gray;
        CamObj7.color = Color.white;
        CamObj8.color = Color.white;
    }
    public void Cam7()
    {
        PlayerSource.PlayOneShot(ChangeCa);
        CamObj1.color = Color.white;
        CamObj2.color = Color.white;
        CamObj3.color = Color.white;
        CamObj4.color = Color.white;
        CamObj5.color = Color.white;
        CamObj6.color = Color.white;
        CamObj7.color = Color.gray;
        CamObj8.color = Color.white;
        CameraChoose = 6;
    }
    public void Cam8()
    {
        PlayerSource.PlayOneShot(ChangeCa);

        CameraChoose = 7;
        CamObj1.color = Color.white;
        CamObj2.color = Color.white;
        CamObj3.color = Color.white;
        CamObj4.color = Color.white;
        CamObj5.color = Color.white;
        CamObj6.color = Color.white;
        CamObj7.color = Color.white;
        CamObj8.color = Color.gray;
    }
    IEnumerator WaitScreen()
    {
        PlayerSource.PlayOneShot(OpenCam);

        yield return new WaitForSeconds(0.2f);
        Camera.SetActive(true);
        CameraOpen = true;
        CameraPanel.SetActive(true);
        BehindButton.SetActive(false);
        BatteryPanel.SetActive(false);
    }

}
