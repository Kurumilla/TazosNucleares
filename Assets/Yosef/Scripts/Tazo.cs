using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tazo : MonoBehaviour
{
    Rigidbody rb;
    RoundOver gg;

    [Header("Game Status")]
    public bool activo = false;
    public bool enMano = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        gg = GameObject.Find("Scripts Manager").GetComponent<RoundOver>();
    }

    private void OnCollisionEnter(Collision col)
    {
        gg.countdown = 5f; //Reset countdown because tazos are still bouncing around
        Tazo other = col.gameObject.GetComponent<Tazo>();
        if (activo && other!=null)
        {
            Vector3 power = rb.velocity;
            power.y *= -1;
            // Apply impulse
            other.rb.AddForceAtPosition(power, col.contacts[0].point, ForceMode.Impulse);
            activo = false;
        }
    }

    public void OnClick()
    {
        if (enMano)
        {
            // Shoot
            float _value = GameObject.Find("Fuerza de lanzamiento").GetComponent<OscillatingBar>().value;
            rb.AddForce(_value * 30f * transform.forward, ForceMode.Impulse);
            // Edit Variables
            rb.useGravity = true;
            transform.SetParent(null);
            enMano = false;
            // Start Count
            gg.BouncingPhase();
        }
    }

    public bool CheckOrientation()
    {
        // Heads
        if (Vector3.Angle(transform.up, Vector3.up) < 90f)
            return true;
        // Tails
        return false;
    }
}
