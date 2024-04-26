using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tazo : MonoBehaviour
{
    Rigidbody rb;
    public bool activo = false;
    public float bounciness;
    public int energyLoss = 4;
    public float maxPower = 20f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision col)
    {
        Tazo other = col.gameObject.GetComponent<Tazo>();
        if (activo && other!=null)
        {
            Vector3 power = rb.velocity / energyLoss;
            power.y *= -bounciness / (bounciness + other.bounciness);
            // Clamps
            power.x = Mathf.Clamp(power.x, -maxPower, maxPower);
            power.y = Mathf.Clamp(power.y, -maxPower, maxPower);
            power.z = Mathf.Clamp(power.z, -maxPower, maxPower);
            // Apply impulse
            other.rb.AddForceAtPosition(power, col.contacts[0].point, ForceMode.Impulse);
            activo = false;
        }
    }
}
