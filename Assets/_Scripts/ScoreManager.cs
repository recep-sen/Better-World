using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int CurrentScore = 0;
    public float GarbageTime = 120;
    public float Timer = 0;
    public int PossibleScore = 0;
    public bool Ingame = true;
    public Sprite[] Backgrounds;
    public SpriteRenderer BackgroundRenderer;
    public int CurrentLevel = 1;
    public GameObject Win;
    public GameObject Lose;
    public PlayerController PlayerController;
    public RodController RodController;
    public LevelGenerator LevelGenerator;

    private void Update()
    {
        Debug.Log(CurrentScore);
        if (Ingame)
        {
            if(CurrentScore < -500)
            {
                Ingame = false;
                PlayerController.ControlsEnabled = false;
                RodController.ControlsEnabled = false;
                Lose.SetActive(true);
            }
            else if (CurrentScore < 250) CurrentLevel = 1;
            else if (CurrentScore < 500) CurrentLevel = 2;
            else if (CurrentScore < 750) CurrentLevel = 3;
            else if (CurrentScore < 1000) CurrentLevel = 4;
            else CurrentLevel = 5;
            SetBackgrounds(CurrentLevel);
            if (PossibleScore == 0 || CurrentLevel == 5)
            {
                if (CurrentLevel > 2)
                {
                    Ingame = false;
                    PlayerController.ControlsEnabled = false;
                    RodController.ControlsEnabled = false;
                    Win.SetActive(true);
                }
                else
                {
                    Ingame = false;
                    PlayerController.ControlsEnabled = false;
                    RodController.ControlsEnabled = false;
                    Lose.SetActive(true);
                }
            }
            Timer += Time.deltaTime;
            if (GarbageTime <= Timer)
            {
                DumpGarbage();
            }
        }
    }

    public void DumpGarbage()
    {
        Ingame = false;
        PlayerController.ControlsEnabled = false;
        RodController.ControlsEnabled = false;
        LevelGenerator.DumpGarbage();
        Timer = 0;
        CurrentScore -= 500;
        Ingame = true;
        PlayerController.ControlsEnabled = true;
        RodController.ControlsEnabled = true;
    }

    public void SetBackgrounds(int background)
    {
        switch (background)
        {
            case 1:
                BackgroundRenderer.sprite = Backgrounds[0];
                break;
            case 2:
                BackgroundRenderer.sprite = Backgrounds[1];
                break;
            case 3:
                BackgroundRenderer.sprite = Backgrounds[2];
                break;
            case 4:
                BackgroundRenderer.sprite = Backgrounds[3];
                break;
            case 5:
                BackgroundRenderer.sprite = Backgrounds[4];
                break;
            default:
                break;
        }
    }
}