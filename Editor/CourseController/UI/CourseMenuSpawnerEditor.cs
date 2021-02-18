using System;
using Innoactive.Creator.UX;
using UnityEditor;
using UnityEngine;

namespace Innoactive.CreatorEditor.UX
{
    /// <summary>
    /// Custom editor for <see cref="ICourseController"/>s.
    /// Takes care of adding required components.
    /// </summary>
    [CustomEditor(typeof(CourseMenuSpawner))]
    public class CourseMenuSpawnerEditor : Editor
    {
        private SerializedProperty useCustomPrefabProperty;
        private SerializedProperty customPrefabProperty;
        private SerializedProperty defaultPrefabProperty;

        private GameObject defaultPrefab;
        private GameObject customPrefab;
        private bool useCustomPrefab;

        private void OnEnable()
        {
            defaultPrefabProperty = serializedObject.FindProperty("defaultPrefab");
            useCustomPrefabProperty = serializedObject.FindProperty("useCustomPrefab");
            customPrefabProperty = serializedObject.FindProperty("customPrefab");
        }

        public override void OnInspectorGUI()
        {
            GUI.enabled = false;
            EditorGUILayout.ObjectField("Script", MonoScript.FromMonoBehaviour((CourseMenuSpawner)target), typeof(CourseMenuSpawner), false);
            EditorGUILayout.ObjectField("Default prefab", defaultPrefabProperty.objectReferenceValue, typeof(GameObject), false);
            
            GUI.enabled = useCustomPrefab == false && Application.isPlaying == false;
            bool prevUseCustomPrefab = useCustomPrefab;
            
            GUI.enabled = !Application.isPlaying;

            useCustomPrefab = EditorGUILayout.Toggle("Use custom prefab", useCustomPrefabProperty.boolValue);
            
            if (useCustomPrefab)
            {
                customPrefab = EditorGUILayout.ObjectField("Custom prefab", customPrefabProperty.objectReferenceValue, typeof(GameObject), false) as GameObject;
                customPrefabProperty.objectReferenceValue = customPrefab;
            }
            
            useCustomPrefabProperty.boolValue = useCustomPrefab;
            serializedObject.ApplyModifiedProperties();
        }
    }
}