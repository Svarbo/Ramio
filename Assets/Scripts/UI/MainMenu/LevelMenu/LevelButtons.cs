using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtons : MonoBehaviour
{
    [SerializeField] private List<Button> _buttons = new List<Button>();

    private int _openLevelsNumber;

    private void Start()
    {
        // TODO не понятно где устонавливается значени. Ж: кажется этот функционал ты после меня иначе реализовывал, если это так, то весь класс просто можно удалить
        _openLevelsNumber = PlayerPrefs.GetInt("OpenLevelsNumber");
        ShowOpenLevels();
    }

    private void ShowOpenLevels()
    {
        for (int i = 0; i < _openLevelsNumber; i++)
        {
            _buttons[i].interactable = true;

            SetButtonAlfa(_buttons[i]);
        }
    }

    private void SetButtonAlfa(Button button)
    {
        Color openButtonColor = button.image.color;
        openButtonColor.a = 1f;
        button.image.color = openButtonColor;
    }
}