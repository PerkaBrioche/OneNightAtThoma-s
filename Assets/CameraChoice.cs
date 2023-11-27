using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
    // Start is called before the first frame update
    void Start()
    {
        CameraChoose = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // Camera.transform.position = AllCamera[CameraChoose].CameraPos.transform.position;
        CamName.text = AllCamera[CameraChoose].CameraName;
        CamDescription.text = AllCamera[CameraChoose].CameraDescription;
    }
    [System.Serializable]
    public class ListCamera
    {
        public string CameraName;
        public string CameraDescription;
        public GameObject CameraPos;
    }
    public void CameraClick()
    {
        if (CameraOpen)
        {
            CameraOpen = false;
            CameraPanel.SetActive(false);
            BehindButton.SetActive(true);
            BatteryPanel.SetActive(true);
        }
        else
        {
            CameraOpen = true;
            CameraPanel.SetActive(true);
            BehindButton.SetActive(false);
            BatteryPanel.SetActive(false);
        }

    }
    public void Cam1()
    {
        CameraChoose = 0;
    }
    public void Cam2()
    {
        CameraChoose = 1;
    }
    public void Cam3()
    {
        CameraChoose = 2;
    }
    public void Cam4()
    {
        CameraChoose = 3;
    }
    public void Cam5()
    {
        CameraChoose = 4;
    }
    public void Cam6()
    {
        CameraChoose = 5;
    }
    public void Cam7()
    {
        CameraChoose = 6;
    }

}
