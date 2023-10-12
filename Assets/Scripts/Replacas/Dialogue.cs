using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(menuName = "Database/Replicas", fileName = "Replicas")]
public class Dialogue : ScriptableObject
{
    [SerializeField, HideInInspector] private List<DialogueData> _dialogueData = new List<DialogueData>();

    [SerializeField] private DialogueData _currentDialogueData;

    private int _currentIndex = 0;
    private List<DialogueData> _tempDialogueData = new List<DialogueData>();

    public void FillTempEventsList()
    {
        _tempDialogueData.Clear();

        for (int i = 0; i < _dialogueData.Count; i++)
            _tempDialogueData.Add(_dialogueData[i]);
    }

    public DialogueData GetRandom()
    {
        int randomEventIndex = Random.Range(0, _tempDialogueData.Count);
        DialogueData randomEvent = _tempDialogueData[randomEventIndex];
        _tempDialogueData.RemoveAt(randomEventIndex);

        return randomEvent;
    }

    public void AddElement()
    {
        if(_dialogueData == null)
            _dialogueData = new List<DialogueData>();

        _currentDialogueData = new DialogueData();
        _dialogueData.Add(_currentDialogueData);
        _currentIndex = _dialogueData.Count - 1;
    }

    public void RemoveCurrentElement()
    {
        if(_currentIndex > 0)
        {
            _currentDialogueData = _dialogueData[--_currentIndex];
            _dialogueData.RemoveAt(++_currentIndex);
        }
        else
        {
            _dialogueData.Clear();
            _currentDialogueData = null;
        }
    }

    public DialogueData TryGetNextDialogueData()
    {
        if(_currentIndex < _dialogueData.Count - 1)
            _currentIndex++;

        _currentDialogueData = this[_currentIndex];

        return _currentDialogueData;
    }

    public DialogueData TryGetPreviousDialogueData()
    {
        if (_currentIndex > 0)
            _currentIndex--;

        _currentDialogueData = this[_currentIndex];

        return _currentDialogueData;
    }

    public DialogueData this[int index]
    {
        get
        {
            if (_dialogueData != null && index >= 0 && index < _dialogueData.Count)
                return _dialogueData[index];
            return null;
        }
        set
        {
            if (_dialogueData == null)
                _dialogueData = new List<DialogueData>();

            if (index >= 0 && index < _dialogueData.Count && value != null)
                _dialogueData[index] = value;
            else
                Debug.LogError("Выход за границы массива, либо переданное значение = null");
        }
    }
}

[System.Serializable]
public class DialogueData
{
    [SerializeField] private List<TMP_Text> _replicas = new List<TMP_Text>();
}