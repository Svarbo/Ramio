using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ToggleGroup))]
public class LanguagesChanger : MonoBehaviour
{
    [SerializeField] private List<Toggle> _toggles = new List<Toggle>();

    private ToggleGroup _toggleGroup;

    private void Start()
    {
        _toggleGroup = GetComponent<ToggleGroup>();
        SetCurrentToggleActive();
    }

    private void SetCurrentToggleActive()
    {
        int activeToggleIndex = PlayerPrefs.GetInt("LanguageIndex");

        _toggles[activeToggleIndex].isOn = true;
    }

    public void ChangeLanguage()
    {
        Toggle activeToggle = _toggleGroup.GetFirstActiveToggle();
        int languageIndex = activeToggle.transform.GetSiblingIndex();

        PlayerPrefs.SetInt("LanguageIndex", languageIndex);
        PlayerPrefs.SetInt("LanguageWasChanged", 1);
    }
}