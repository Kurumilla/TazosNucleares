using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tazo : MonoBehaviour
{
    Rigidbody rb;
    RoundOver gg;

    public float power = 1f;
    [Header("Game Status")]
    public bool activo = false;
    public bool enMano = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        gg = GameObject.Find("Scripts Manager").GetComponent<RoundOver>();
    }

    private void OnCollisionEnter(Collision col)
    {
        activo = false;
        gg.countdown = 5f; //Reset countdown because tazos are still bouncing around
        Tazo other = col.gameObject.GetComponent<Tazo>();
        if (activo && other!=null)
        {
            Vector3 knockback = rb.velocity;
            knockback.y *= -1;
            // Apply impulse
            other.rb.AddForceAtPosition(knockback, col.contacts[0].point, ForceMode.Impulse);
        }
    }

    public void OnClick()
    {
        if (enMano)
        {
            // Shoot
            float _value = GameObject.Find("Fuerza de lanzamiento").GetComponent<OscillatingBar>().value;
            rb.AddForce(_value * power * -transform.up, ForceMode.Impulse);
            // Edit Variables
            rb.useGravity = true;
            transform.SetParent(null);
            enMano = false;
            // Start Count
            gg.SystemPhase();
        }
    }

    public bool CheckOrientation()
    {
        // Heads
        if (Vector3.Angle(transform.forward, Vector3.up) < 90f)
            return true;
        // Tails
        return false;
    }
}
