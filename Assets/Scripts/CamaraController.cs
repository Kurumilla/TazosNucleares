using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public Transform player; // Referencia al transform del jugador
    public float distance = 5f; // Distancia entre la camara y el jugador
    public float height = 2f; // Altura de la camara sobre el jugador
    public Vector3 offset; // Offset adicional para ajustar la posicion de la camara
    public float cameraAngle = 45f; // angulo de la camara

    private void FixedUpdate()
    {
        // Convertir el angulo de la camara a direccion en el plano XY
        Vector3 direction = Quaternion.Euler(0f, cameraAngle, 0f) * Vector3.forward;

        // Calcular la posicion objetivo de la camara
        Vector3 desiredPosition = player.position + offset - direction * distance + Vector3.up * height;
        transform.position = desiredPosition;

        // Mantener la camara mirando al jugador
        transform.LookAt(player.position + offset);
    }
}
