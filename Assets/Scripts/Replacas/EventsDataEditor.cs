using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Dialogue))]
public class EventsDataEditor : Editor
{
    private Dialogue _dialogue;

    private void Awake()
    {
        _dialogue = (Dialogue)target;
    }

    public override void OnInspectorGUI()
    {
        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Remove"))
            _dialogue.RemoveCurrentElement();
        if (GUILayout.Button("Add"))
            _dialogue.AddElement();
        if (GUILayout.Button("<="))
            _dialogue.TryGetPreviousDialogueData();
        if (GUILayout.Button("=>"))
            _dialogue.TryGetNextDialogueData();

        GUILayout.EndHorizontal();
        base.OnInspectorGUI();
    }
}
