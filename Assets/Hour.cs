using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Hour : MonoBehaviour
{
    public float Timer;
    public TextMeshProUGUI HourText;
    public int HourInt;
    public Animator CanvasAnim;
    public Animatronic Animatronic;
    public PhoneCall PhoneCall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PhoneCall.EndCall)
        {


            HourText.text = "0" + HourInt.ToString() + "AM";
            Timer += Time.deltaTime;
            if (Timer >= 55)
            {
                Timer = 0;
                HourInt++;
            }
            if (HourInt == 6)
            {
                Animatronic.EndGame = true;
                CanvasAnim.Play("EndNight");
                StartCoroutine(CloseGame());
            }
        }
        else
        {
            HourText.text = "";
        }
        
    }
    IEnumerator CloseGame()
    {
        yield return new WaitForSeconds(5.5f);
        Application.Quit();
    }
}
