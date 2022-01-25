using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIUpdater : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public ScoreManager ScoreManager;
    public GameObject Help;

    private void Update()
    {
        ScoreText.text = new($"Score:" + ScoreManager.CurrentScore);
    }

    public void HelpButton()
    {
        if(Time.timeScale == 1)
        {
            Help.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            Help.SetActive(false);
            Time.timeScale = 1;
        }
    }
}