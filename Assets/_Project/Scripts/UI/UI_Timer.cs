using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;

    public void UpdateGraphics(float time)
    {
        _timerText.text = time.ToString("F1");
    }
}

