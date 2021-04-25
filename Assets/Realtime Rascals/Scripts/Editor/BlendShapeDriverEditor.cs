using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BlendShapeDriver))]
public class BlendShapeDriverEditor : Editor
{
    BlendShapeDriver instance;
    SerializedObject obj;

    bool m_showMeshes;
    bool m_showRemaps;
    public override void OnInspectorGUI()
    {
        obj = new SerializedObject(target);
        instance = (BlendShapeDriver)target;

        EditorGUILayout.BeginHorizontal();
        m_showMeshes = EditorGUILayout.Foldout(m_showMeshes, "Meshes");
        if (m_showMeshes)
        {
            if (GUILayout.Button("Add"))
            {
                instance.meshes.Add(null);
            }
            if (GUILayout.Button("Remove"))
            {
                instance.meshes.RemoveAt(instance.meshes.Count - 1);
            }
        }
        EditorGUILayout.EndHorizontal();
        EditorGUI.BeginChangeCheck();
        if (m_showMeshes)
        {
            EditorGUI.indentLevel++;
            for (int i = 0; i < instance.meshes.Count; i++)
            {
                instance.meshes[i] = (SkinnedMeshRenderer)EditorGUILayout.ObjectField(instance.meshes[i], typeof(SkinnedMeshRenderer), true);
            }
            EditorGUI.indentLevel--;
        }

        instance.submeshesUseRemappedIndexes = EditorGUILayout.Toggle("Remap Indexes", instance.submeshesUseRemappedIndexes);
        m_showRemaps = EditorGUILayout.Foldout(m_showRemaps, "Index Maps");
        if (instance.submeshesUseRemappedIndexes && m_showRemaps)
        {
            EditorGUILayout.BeginVertical("box");
            for (int i = 0; i < instance.remappedIndexes.Count; i++)
            {
                instance.remappedIndexes[i] = EditorGUILayout.IntField(instance.shapes[i].shapeName, instance.remappedIndexes[i]);
            }
            EditorGUILayout.EndVertical();
        }


        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Blend Shapes", EditorStyles.boldLabel);
        EditorGUILayout.EndHorizontal();


        for (int i = instance.shapes.Count - 1; i >= 0; i--)
        {
            EditorGUILayout.BeginHorizontal("box");
            EditorGUILayout.LabelField(instance.shapes[i].shapeIndex.ToString(), GUILayout.Width(20), GUILayout.ExpandWidth(false));
            instance.shapes[i].shapeName = EditorGUILayout.TextField(instance.shapes[i].shapeName);
            EditorGUILayout.Slider(obj.FindProperty(instance.valueNames[i]), 0, 100, "");

            EditorGUILayout.EndHorizontal();
        }

        if (EditorGUI.EndChangeCheck())
        {
            obj.ApplyModifiedProperties();
            EditorUtility.SetDirty(target);
        }

    }

}
