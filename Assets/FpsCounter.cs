using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FpsCounter : MonoBehaviour
{
    TextMeshProUGUI fpsText; 
    float deltaTime = 0.0f;

    void Start()
    {
        fpsText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.SetText(Mathf.Ceil(fps).ToString() + " FPS");
    }
}
