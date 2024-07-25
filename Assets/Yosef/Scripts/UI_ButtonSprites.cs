using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ButtonSprites : MonoBehaviour
{
    public Sprite sprite1, sprite2;
    private bool firstSprite = true;
    private Image render;

    private void Start()
    {
        render = GetComponent<Image>();
    }

    public void ChangeSprite()
    {
        firstSprite = !firstSprite;
        render.sprite = firstSprite ? sprite1 : sprite2;
    }

    public void OnEnable() //Para el tiro que viene nuevo con cada tazo
    {
        firstSprite = true;
        render.sprite = sprite1;
    }
}
