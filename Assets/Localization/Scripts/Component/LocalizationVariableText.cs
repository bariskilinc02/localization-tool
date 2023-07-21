using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LocalizationVariableText : MonoBehaviour
{
    public string key;
    void Start()
    {
        SubscribeToEvent();
        LoadData();
    }

    public void LoadData()
    {
        int value = 5;
        GetComponent<TextMeshProUGUI>().text = LocalizationManager.Instance.GetLocalizationValue(key, $"{value}");
    }

    public void SubscribeToEvent()
    {
        LocalizationManager.Instance.OnLanguageChanged += LoadData;
    }
}
