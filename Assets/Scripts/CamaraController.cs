using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public Transform player; // Referencia al transform del jugador
    public float distance = 5f; // Distancia entre la cámara y el jugador
    public float height = 2f; // Altura de la cámara sobre el jugador
    public Vector3 offset; // Offset adicional para ajustar la posición de la cámara
    public float cameraAngle = 45f; // Ángulo de la cámara

    private void FixedUpdate()
    {
        // Convertir el ángulo de la cámara a dirección en el plano XY
        Vector3 direction = Quaternion.Euler(0f, cameraAngle, 0f) * Vector3.forward;

        // Calcular la posición objetivo de la cámara
        Vector3 desiredPosition = player.position + offset - direction * distance + Vector3.up * height;
        transform.position = desiredPosition;

        // Mantener la cámara mirando al jugador
        transform.LookAt(player.position + offset);
    }
}
