using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Write : MonoBehaviour
{
    public int speed = 10;

    TextMeshProUGUI txt;
    string text;
    float counter = 0.0f;
    bool active = false;

    void Start()
    {
        txt = gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
        if (active)
        {
            counter += Time.deltaTime * speed;
            int x = Mathf.RoundToInt(counter);

            if (counter < text.Length)
                txt.text = text.Substring(0, x);
            else
                active = false;
        }
    }

    public void NewOutput(string _text)
    {
        text = _text;
        counter = 0;
        active = true;
    }
}
