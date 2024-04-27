using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid2 : MonoBehaviour
{
    public float gridSize = 1f; // Tamaño del grid
    public LayerMask obstacleMask; // Capa de obstáculos

    private Vector3 targetPosition; // Posición objetivo
    private bool isMoving; // Flag para indicar si el jugador está moviéndose

    private void Update()
    {
        if (!isMoving)
        {
            // Obtener la dirección de movimiento deseada
            Vector3 moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

            // Verificar si el movimiento es posible
            if (CanMove(moveDirection))
            {
                // Calcular la posición objetivo
                targetPosition = transform.position + moveDirection * gridSize;

                // Si hay una subida diagonal, ajustar la posición objetivo
                if (moveDirection.x != 0 && moveDirection.z != 0 && CanMove(Vector3.up))
                {
                    targetPosition += Vector3.up * gridSize;
                }

                // Iniciar el movimiento
                StartCoroutine(MoveToTarget());
            }
        }
    }

    private bool CanMove(Vector3 direction)
    {
        // Rayo desde la posición actual en la dirección de movimiento
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, gridSize, obstacleMask))
        {
            // Si el rayo golpea un obstáculo, no se puede mover en esa dirección
            return false;
        }
        return true;
    }

    private System.Collections.IEnumerator MoveToTarget()
    {
        isMoving = true;

        while (Vector3.Distance(transform.position, targetPosition) > 0.05f)
        {
            // Movimiento suavizado hacia la posición objetivo
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, gridSize * Time.deltaTime * 5f);
            yield return null;
        }

        // Ajustar posición exacta en caso de que haya pequeños desajustes
        transform.position = targetPosition;

        isMoving = false;
    }
}
