using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class HealtText : MonoBehaviour
{
    private TextMeshProUGUI text; 
    public int health;
    
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }
    
    void Update()
    {
        text.text = LocalizationManager.Instance.GetLocalizationValue("playerHealth", health);
    }
}
