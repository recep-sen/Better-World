using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelGenerator : MonoBehaviour
{
    public GarbageObject[] GarbageObjects;
    public ScoreManager ScoreManager;
    public GarbageObject[] DumpGarbages;

    private void Start()
    {
        GenerateLevels();
    }
    public void GenerateLevels()
    {
        ScoreManager.Ingame = false;
        for(int i = 0; i < GarbageObjects.Length; i++)
        {
            Instantiate(GarbageObjects[i].Garbage, GarbageObjects[i].SpawnLocation, Quaternion.identity);
        }
        ScoreManager.Ingame = true;
    }

    public void DumpGarbage()
    {
        for (int i = 0; i < DumpGarbages.Length; i++)
        {
            Instantiate(DumpGarbages[i].Garbage, DumpGarbages[i].Boat.transform.position-Vector3.down, Quaternion.identity);
        }
    }

    public void NewLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}