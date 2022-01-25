using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : MonoBehaviour
{
    public int PointtoGive;
    public Rigidbody2D Rigidbody;
    public bool floating;

    private void Awake()
    {
        GameObject.Find("Player").GetComponent<ScoreManager>().PossibleScore += PointtoGive;
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        if (floating)
        {
            Rigidbody.velocity = new(0f, Mathf.Sin(Time.time) * 0.5f);
        }
    }

    private void OnDestroy()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<ScoreManager>().PossibleScore -= PointtoGive;
        GameObject.FindGameObjectWithTag("Player").GetComponent<ScoreManager>().CurrentScore += PointtoGive;
    }
}