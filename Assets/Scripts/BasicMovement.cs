using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public Animator animator; 
    public Transform modelTransform;
    public EstadoDeJuego estadoDeJuego;

    private Rigidbody rb;
    private AudioSource audio;
    private bool isMoving = false;

    public bool activado = false;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        estadoDeJuego = GameObject.Find("Estado de Juego").GetComponent<EstadoDeJuego>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (activado && !estadoDeJuego.movimientoBloqueado)
        {
            // Obtener las entradas de movimiento del eje horizontal y vertical
            float moveInputX = Input.GetAxisRaw("Horizontal");
            float moveInputY = Input.GetAxisRaw("Vertical");

            // Normalizar el vector de movimiento para evitar el movimiento en diagonal
            Vector3 movement = new Vector3(moveInputX, 0f, moveInputY).normalized;

            // Verificar si el jugador se est� moviendo
            if (movement != Vector3.zero)
            {
                // Calcular la nueva posici�n del jugador
                Vector3 newPosition = rb.position + transform.TransformDirection(movement) * moveSpeed * Time.deltaTime;

                // Mover al jugador usando el Rigidbody
                rb.MovePosition(newPosition);

                // Girar el modelo del personaje hacia la direcci�n del movimiento
                if (modelTransform != null)
                {
                    modelTransform.LookAt(modelTransform.position + movement);
                }

                // Activar la variable bool en el Animator
                if (!isMoving)
                {
                    audio.Play();
                    animator.SetBool("isWalking", true);
                    isMoving = true;
                }
            }
            else if (isMoving)
            {
                audio.Stop();
                animator.SetBool("isWalking", false);
                isMoving = false;
            }
        }
        else if (isMoving)
        {
            audio.Stop();
            animator.SetBool("isWalking", false);
            isMoving = false;
        }
    }
}
