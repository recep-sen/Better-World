using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodController : MonoBehaviour
{
    public Camera MainCamera;
    public Vector2 MousePosition;
    public bool ControlsEnabled = true;
    public float RotationSpeed;

    private void Update()
    {
        SetMousePosition();
        if (ControlsEnabled)
        {
            Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
            if (dir.y > 5.7f) dir.y = 5.7f;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle+90, Vector3.forward);
        }
    }

    public void SetMousePosition()
    {
        MousePosition = (Vector2)MainCamera.ScreenToWorldPoint(Input.mousePosition);
        if (MousePosition.y > 5.7f) MousePosition.y = 5.7f;
    }
}