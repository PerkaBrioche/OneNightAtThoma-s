using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Hour : MonoBehaviour
{
    public float Timer;
    public TextMeshProUGUI HourText;
    public int HourInt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HourText.text ="0"+ HourInt.ToString() + "AM";
        Timer += Time.deltaTime;
        if (Timer >= 55)
        {
            Timer = 0;
            HourInt++;
        }
        
    }
}
