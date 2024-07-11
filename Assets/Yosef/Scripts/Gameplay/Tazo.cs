using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tazo : MonoBehaviour
{
    Rigidbody rb;
    RoundOver gg;
    AudioSource audio;

    [Header("Variables generales")]
    public float velocidad = 1f;
    public float fuerzaTiro = 1f;
    [Header("Variables del Tiro Curvo")]
    public Vector3 center;
    public float anguloInicial = 0;
    public float anguloActual = 0;
    [Header("Game State")]
    public bool activo = false;
    public bool enMano = false;
    public bool tiroCurvo = false;

    private void Awake()
    {
        velocidad /= 2f;
        rb = GetComponent<Rigidbody>();
        gg = GameObject.Find("Scripts Manager").GetComponent<RoundOver>();
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (activo && tiroCurvo)
        {
            // Movimiento curvo
            anguloActual += Mathf.PI * 2.0f * fuerzaTiro * Time.deltaTime;
            transform.position = center - velocidad * (Mathf.Sin(anguloActual) * transform.right - Mathf.Cos(anguloActual) * transform.up);
        }
        else if (activo)
        {
            // Movimiento recto
            transform.position -= transform.up * 4.0f * velocidad * fuerzaTiro * Time.deltaTime;
        }
    }
    
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag != "Ignore")
        {
            audio.Play();
            //Reset countdown because tazos are still bouncing around
            if (gg.countdown < 2.5f)
                gg.countdown = 2.5f;
            // When hitting a tazo
            Tazo other = col.gameObject.GetComponent<Tazo>();
            if (activo && other != null)
            {
                Vector3 knockback = Vector3.up;
                // Apply impulse
                other.rb.AddForce(knockback * 2.0f, ForceMode.Impulse);
                other.audio.Play();
            }
            // Becomes part of the field
            GetComponent<MeshCollider>().isTrigger = false;
            rb.useGravity = true;
            rb.AddForce(Vector3.up * 2.0f, ForceMode.Impulse);
            activo = false;
        }
    }
    
    private void OnCollisionEnter(Collision other)
    {
        audio.Play();
        //Reset countdown because tazos are still bouncing around
        if (gg.countdown < 2.5f)
            gg.countdown = 2.5f;
    }

    public void OnClick()
    {
        if (enMano)
        {
            // Variables del tiro
            fuerzaTiro = Mathf.Clamp(GameObject.Find("Fuerza de lanzamiento").GetComponent<OscillatingBar>().value, 0.2f, 1.0f);
            anguloActual = (1.0f - fuerzaTiro) * Mathf.PI / 3.0f;
            velocidad /= Mathf.Cos(anguloActual);
            center = transform.position + velocidad * (Mathf.Sin(anguloActual) * transform.right - Mathf.Cos(anguloActual) * transform.up);
            activo = true;
            // Edit Variables
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
