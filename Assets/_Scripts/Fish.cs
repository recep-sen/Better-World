using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public Rigidbody2D Rigidbody;
    public int PointtoGive;
    public int Direction;
    private float timer;
    private float time;
    private void Start()
    {
        Rigidbody.velocity = new(0.5f * Direction, 0);
        time = 10f;
        timer = 0f;
    }

    private void Update()
    {
        if (timer > time  && (transform.position.x < -17.77 || transform.position.x > 17.77))
        {
            SpriteRenderer.flipX = !SpriteRenderer.flipX;
            Direction *= -1;
            Rigidbody.velocity = new(0.5f * Direction, 0);
            timer = 0f;
        }
        timer += Time.deltaTime;
    }
    private void OnDestroy()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<ScoreManager>().CurrentScore += PointtoGive;
    }
}