using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerThomas : MonoBehaviour
{
    public CameraChoice CameraChoice;
    public Animatronic Animatronic;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Animatronic")
        {
            print("RETOURNE");
            Animatronic.ReturnInt = CameraChoice.AllCamera[CameraChoice.CameraChoose].ThomasPos;
            Animatronic.ResetThomas();
        }
    }
}
