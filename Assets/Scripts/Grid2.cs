using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid2 : MonoBehaviour
{
    public float gridSize = 1f; // Tama�o del grid
    public LayerMask obstacleMask; // Capa de obst�culos

    private Vector3 targetPosition; // Posici�n objetivo
    private bool isMoving; // Flag para indicar si el jugador est� movi�ndose

    private void Update()
    {
        if (!isMoving)
        {
            // Obtener la direcci�n de movimiento deseada
            Vector3 moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

            // Verificar si el movimiento es posible
            if (CanMove(moveDirection))
            {
                // Calcular la posici�n objetivo
                targetPosition = transform.position + moveDirection * gridSize;

                // Si hay una subida diagonal, ajustar la posici�n objetivo
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
        // Rayo desde la posici�n actual en la direcci�n de movimiento
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, gridSize, obstacleMask))
        {
            // Si el rayo golpea un obst�culo, no se puede mover en esa direcci�n
            return false;
        }
        return true;
    }

    private System.Collections.IEnumerator MoveToTarget()
    {
        isMoving = true;

        while (Vector3.Distance(transform.position, targetPosition) > 0.05f)
        {
            // Movimiento suavizado hacia la posici�n objetivo
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, gridSize * Time.deltaTime * 5f);
            yield return null;
        }

        // Ajustar posici�n exacta en caso de que haya peque�os desajustes
        transform.position = targetPosition;

        isMoving = false;
    }
}
