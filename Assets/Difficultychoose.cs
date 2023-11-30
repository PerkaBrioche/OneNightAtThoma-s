using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Difficultychoose : MonoBehaviour
{
    public TextMeshProUGUI DiffText;
    public Animator MonsterAnium;
    public Light SpoitLigt;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Difficulty", 1);
    }

    // Update is called once per frame
    void Update()
    {
        print(PlayerPrefs.GetInt("Difficulty"));
        DiffText.text = PlayerPrefs.GetInt("Difficulty").ToString();

        if (PlayerPrefs.GetInt("Difficulty") == 1)
        {
            MonsterAnium.Play("Pos1");
            SpoitLigt.color = new Color(255, 255, 255, 255) ;
        }
        if (PlayerPrefs.GetInt("Difficulty") == 2)
        {
            MonsterAnium.Play("Pos2");
            SpoitLigt.color = new Color(255, 165, 165);

        }
        if (PlayerPrefs.GetInt("Difficulty") == 3)
        {
            MonsterAnium.Play("Pos3");
            SpoitLigt.color = new Color(255, 100, 100);

        }
        if (PlayerPrefs.GetInt("Difficulty") == 4)
        {
            MonsterAnium.Play("Pos4");
            SpoitLigt.color = new Color(255, 26, 26);

        }
        if (PlayerPrefs.GetInt("Difficulty") == 5)
        {
            MonsterAnium.Play("Pos5");
            SpoitLigt.color = new Color(255, 0, 0);

        }
    }
    public void LevelUp()
    {
        if (PlayerPrefs.GetInt("Difficulty") < 5)
        {
            PlayerPrefs.SetInt("Difficulty", PlayerPrefs.GetInt("Difficulty") +1);
        }
    }
    public void LevelDown()
    {
        if (PlayerPrefs.GetInt("Difficulty") > 1)
        {
            PlayerPrefs.SetInt("Difficulty", PlayerPrefs.GetInt("Difficulty") -1);
        }
    }
    public void LaunchGame()
    {
        SceneManager.LoadScene(2);
    }
        
} 