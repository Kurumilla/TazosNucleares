using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tazo : MonoBehaviour
{
    [Header("Game Status")]
    Rigidbody rb;
    public bool activo = false;
    public bool enMano = false;

    [Header("Physics Settings")]
    public float bounciness;
    public int energyLoss = 4;
    public float maxPower = 20f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision col)
    {
        Tazo other = col.gameObject.GetComponent<Tazo>();
        if (activo && other!=null)
        {
            Vector3 power = rb.velocity; // energyLoss;
            power.y *= -bounciness / (bounciness + other.bounciness);
            /* Clamps
            power.x = Mathf.Clamp(power.x, -maxPower, maxPower);
            power.y = Mathf.Clamp(power.y, -maxPower, maxPower);
            power.z = Mathf.Clamp(power.z, -maxPower, maxPower);*/
            // Apply impulse
            other.rb.AddForceAtPosition(power, col.contacts[0].point, ForceMode.Impulse);
            activo = false;
        }
    }

    private void Shoot()
    {
        rb.AddForce(20 * transform.forward, ForceMode.Impulse);
        rb.useGravity = true;
        transform.SetParent(null);
        enMano = false;
    }

    public void OnClick()
    {
        if (enMano)
            Shoot();
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
