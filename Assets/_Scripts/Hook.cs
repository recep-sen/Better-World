using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public Vector2 HookPosition;
    public Rigidbody2D HookRigidbody;
    public List<GameObject> HookedObjects;
    public PlayerController PlayerController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Collectible"))
        {
            collision.attachedRigidbody.bodyType = RigidbodyType2D.Kinematic;
            PlayerController.Anim.SetBool("idle", false);
            PlayerController.Anim.SetBool("win", true);
            collision.transform.parent = transform;
            collision.transform.localPosition = HookPosition;
            HookedObjects.Add(collision.gameObject);
            HookRigidbody.velocity *= -1;
        }
        else if (collision.CompareTag("HookStop"))
        {
            PlayerController.Anim.SetBool("win", false);
            if (HookedObjects.Count > 0)
            {
                foreach(var hookedObjects in HookedObjects)
                {
                    hookedObjects.transform.parent = null;
                }
            }
            HookRigidbody.velocity = Vector2.zero;
            PlayerController.ControlsEnabled = true;
            PlayerController.RodController.ControlsEnabled = true;
            if (HookedObjects.Count > 0)
            {
                foreach (var hookedObjects in HookedObjects)
                {
                    Destroy(hookedObjects);
                }
                HookedObjects.Clear();
            }
        }
        else if (collision.CompareTag("HookFail")) 
        {
            HookRigidbody.velocity *= -1;
        }
        else if (collision.CompareTag("Fish"))
        {
            PlayerController.Anim.SetBool("idle", false);
            PlayerController.Anim.SetBool("win", true);
            HookedObjects.Add(collision.gameObject);
            HookRigidbody.velocity *= -1;
            collision.isTrigger = true;
            collision.attachedRigidbody.velocity = Vector2.zero;
            collision.transform.parent = transform;
            collision.transform.localPosition = HookPosition;
        }
    }
}