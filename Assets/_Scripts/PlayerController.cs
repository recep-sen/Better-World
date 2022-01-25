using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D HookRigidbody;
    public float PlayerSpeed;
    public RodController RodController;
    public bool ControlsEnabled = true;
    public Transform Hook;
    public Animator Anim;
    public float HookVelocity;

    private void Update()
    {
        if (ControlsEnabled)
        {
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
            {
                transform.Translate(0, 0, 0);
                Anim.SetBool("idle", true);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-1 * Time.deltaTime * PlayerSpeed, 0f, 0f);
                Anim.SetBool("idle", true);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Time.deltaTime * PlayerSpeed, 0f, 0f);
                Anim.SetBool("idle", true);
            }
            else
            {
                Anim.SetBool("idle", false);
            }
            if (Input.GetMouseButton(0))
            {
                RodController.ControlsEnabled = false;
                ControlsEnabled = false;
                HookRigidbody.velocity = (RodController.MousePosition - (Vector2)Hook.position) * HookVelocity;
            }
        }
    }
}