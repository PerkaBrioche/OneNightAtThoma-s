using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneCall : MonoBehaviour
{
    public GameObject ButtonPhone;
    public GameObject PhoneGuy;
    public GameObject PHoneRing;
    public bool EndCall;
    public bool Listen;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitCall());
        PHoneRing.SetActive(true);
        ButtonPhone.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Listen)
        {
            ButtonPhone.SetActive(false);
            PhoneGuy.SetActive(true);
            PHoneRing.SetActive(false);


        }
    }
    public void Raccorcher()
    {
        if(Listen == false) 
        {
            EndCall = true;
            ButtonPhone.SetActive(false);
            PHoneRing.SetActive(false);
            PhoneGuy.SetActive(false);
            StopAllCoroutines();
        }




    }
    IEnumerator WaitCall()
    {
        yield return new WaitForSeconds(6.5f);
        Listen = true;
        StartCoroutine(EndCalling());


    }
    IEnumerator EndCalling()
    {
        PhoneGuy.SetActive(true);

        yield return new WaitForSeconds(68);
        Listen = false;
        EndCall = true;
        ButtonPhone.SetActive(false);
        PHoneRing.SetActive(false);
        PhoneGuy.SetActive(false);

    }
}
