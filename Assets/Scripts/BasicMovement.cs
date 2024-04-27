using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento del jugador
    public Animator animator; // Referencia al Animator del jugador
    public Transform modelTransform; // Referencia al Transform del modelo del personaje

    private Rigidbody rb; // Referencia al componente Rigidbody del jugador
    private bool isMoving = false; // Variable para controlar si el jugador se est� moviendo o no

    // Se llama al iniciar
    void Start()
    {
        // Obtener el componente Rigidbody del jugador
        rb = GetComponent<Rigidbody>();
    }

    // Se llama una vez por fotograma
    void Update()
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
                animator.SetBool("movimiento", true);
                isMoving = true;
            }
        }
        else
        {
            // Desactivar la variable bool en el Animator
            if (isMoving)
            {
                animator.SetBool("movimiento", false);
                isMoving = false;
            }
        }
    }
}