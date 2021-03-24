using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ui_manager : MonoBehaviour
{
    public static ui_manager instance { get; private set; }

    [SerializeField] private TextMeshProUGUI heart_counter_text;

    private void Awake()
    {
        instance = this;
    }

    public void UpdateText(string value)
    {
        heart_counter_text.text = value;
    }
}
