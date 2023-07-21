using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class LocalizationManager : Singleton<LocalizationManager>
{
    private Dictionary<string, string> _localizedText;
    public Action OnLanguageChanged;

    protected override void Awake()
    {
        base.Awake();
        
        LoadLocalizationData("en");
    }

    private void LoadLocalizationData(string languageId)
    {
        _localizedText = new Dictionary<string, string>();

        string jsonData = Resources.Load<TextAsset>(languageId).ToString();
        _localizedText = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonData);
    }
    
    public string GetLocalizationValue(string key)
    {
        return _localizedText[key];
    }

    public string GetLocalizationValue(string key, params object[] objects)
    {
        string result = _localizedText[key];

        for (int i = 0; i < objects.Length; i++)
        {
            result = result.Replace("{" + i + "}", objects[i].ToString());
        }

        return result;
    }
    
    public void ChangeLanguage(string languageId)
    {
        LoadLocalizationData(languageId);
        OnLanguageChanged?.Invoke();
    }
}