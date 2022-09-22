// Botirov U. Специально для SAB Games.
using UnityEngine;
using UnityEditor;

// Это мини редактор для компонента AiBehaviour.cs, данный класс просто визуально рисует "радиус обнаружение" оранжевым цветом.
[CustomEditor(typeof(AiBehaviour))]
public class AiBehaviour_Editor : Editor
{
    private void OnSceneGUI()
    {
        AiBehaviour aiBehaviour = (AiBehaviour)target;

        Handles.color = new Color(1.0f, 0.64f, 0.0f);
        Handles.DrawWireDisc(aiBehaviour.transform.position, new Vector3(0, 1, 0), aiBehaviour.detectRadius);
    }
}