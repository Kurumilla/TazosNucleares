using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public Transform player; // Referencia al transform del jugador
    public float distance = 5f; // Distancia entre la c�mara y el jugador
    public float height = 2f; // Altura de la c�mara sobre el jugador
    public Vector3 offset; // Offset adicional para ajustar la posici�n de la c�mara
    public float cameraAngle = 45f; // �ngulo de la c�mara

    private void FixedUpdate()
    {
        // Convertir el �ngulo de la c�mara a direcci�n en el plano XY
        Vector3 direction = Quaternion.Euler(0f, cameraAngle, 0f) * Vector3.forward;

        // Calcular la posici�n objetivo de la c�mara
        Vector3 desiredPosition = player.position + offset - direction * distance + Vector3.up * height;
        transform.position = desiredPosition;

        // Mantener la c�mara mirando al jugador
        transform.LookAt(player.position + offset);
    }
}
