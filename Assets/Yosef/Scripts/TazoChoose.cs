// Elegir que tazo usar dando click en el UI

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TazoChoose : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [Header("Main Settings")]
    public GameObject tazo;
    public Transform camera;
    RectTransform rect;
    float radiusScale = 0.3f; 

    [Header("Animation Settings")]
    public float rotationSpeed = 90f;
    public float risingSpeed = 1f;
    public bool isHover = false;

    private void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        rect.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));
        float y = Screen.height * radiusScale;
        if (isHover && rect.anchoredPosition.y <= y)
            rect.anchoredPosition += new Vector2(0, risingSpeed * y * Time.deltaTime);
        else if (!isHover && rect.anchoredPosition.y >= 0)
            rect.anchoredPosition -= new Vector2(0, risingSpeed * y * Time.deltaTime);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHover = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHover = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        GameObject chosen = (GameObject)Instantiate(tazo, camera);
        chosen.transform.localPosition = new Vector3(0, -0.4f, 1.2f);
        //Prepara el disparo
        //Esconde el resto de la mano
        //Destroy(gameObject);
    }
}
