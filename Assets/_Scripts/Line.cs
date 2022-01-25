using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public LineRenderer LineRenderer;
    public Transform Rod;
    public Transform Hook;

    private void Update()
    {
        LineRenderer.SetPosition(0, Rod.position);
        LineRenderer.SetPosition(1, Hook.position);
    }
}