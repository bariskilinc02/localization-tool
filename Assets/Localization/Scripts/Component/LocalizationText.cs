using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LocalizationText : MonoBehaviour
{
    public string key;

    void Start()
    {
        SubscribeToEvent();
        LoadData();
    }

    public void LoadData()
    {
        GetComponent<TextMeshProUGUI>().text = LocalizationManager.Instance.GetLocalizationValue(key);
    }

    public void SubscribeToEvent()
    {
        LocalizationManager.Instance.OnLanguageChanged += LoadData;
    }
}
