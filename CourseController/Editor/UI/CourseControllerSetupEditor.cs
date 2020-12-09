using System;
using System.Collections.Generic;
using System.Linq;
using Innoactive.Creator.Core.Utils;
using Innoactive.Creator.UX;
using UnityEditor;
using UnityEngine;

namespace Innoactive.CreatorEditor.UX
{
    /// <summary>
    /// Custom editor for <see cref="ICourseController"/>s.
    /// Takes care of adding required components.
    /// </summary>
    [CustomEditor(typeof(CourseControllerSetup))]
    internal class CourseControllerSetupEditor : Editor
    {
        private SerializedProperty courseControllerProperty;
        private SerializedProperty useCustomPrefabProperty;
        private SerializedProperty customPrefabProperty;

        private CourseControllerSetup setupObject;
        
        private ICourseController[] availableCourseControllers;
        private string[] availableCourseControllerNames;
        private static int selectedIndex = 0;
        private static bool useCustomPrefab;
        private static GameObject customPrefab = null;

        private static List<Type> currentRequiredComponents = new List<Type>();
        
        private void OnEnable()
        {
            courseControllerProperty = serializedObject.FindProperty("courseControllerQualifiedName");
            useCustomPrefabProperty = serializedObject.FindProperty("useCustomPrefab");
            customPrefabProperty = serializedObject.FindProperty("customPrefab");
            
            setupObject = (CourseControllerSetup) serializedObject.targetObject;
            
            availableCourseControllers = ReflectionUtils.GetFinalImplementationsOf<ICourseController>()
                .Select(c => (ICourseController) ReflectionUtils.CreateInstanceOfType(c)).OrderByDescending(controller => controller.Priority).ToArray();
            
            availableCourseControllerNames = availableCourseControllers.Select(controller => controller.Name).ToArray();
            currentRequiredComponents = availableCourseControllers[selectedIndex].GetRequiredSetupComponents();
        }

        public override void OnInspectorGUI()
        {
            GUI.enabled = !useCustomPrefab && !Application.isPlaying;
            bool prevUseCustomPrefab = useCustomPrefab;
            int prevIndex = selectedIndex;
            
            selectedIndex = EditorGUILayout.Popup("Course Controller", selectedIndex, availableCourseControllerNames);
            
            GUI.enabled = !Application.isPlaying;

            useCustomPrefab = EditorGUILayout.Toggle("Use custom prefab", useCustomPrefabProperty.boolValue);
            
            if (useCustomPrefab)
            {
                customPrefab = EditorGUILayout.ObjectField("Custom prefab", customPrefab, typeof(GameObject), false) as GameObject;
                if (useCustomPrefab != prevUseCustomPrefab)
                {
                    ClearRequiredComponents();
                }
            }
            else if (prevIndex != selectedIndex || HasComponents() == false)
            {
                ClearRequiredComponents();
                AddRequiredComponents();
            }

            useCustomPrefabProperty.boolValue = useCustomPrefab;
            customPrefabProperty.objectReferenceValue = customPrefab;
            courseControllerProperty.stringValue = availableCourseControllers[selectedIndex].GetType().AssemblyQualifiedName;
            
            serializedObject.ApplyModifiedProperties();
        }

        private void ClearRequiredComponents()
        {
            foreach (Type component in currentRequiredComponents)
            {
                DestroyImmediate(setupObject.GetComponent(component));
            }
            
            currentRequiredComponents = new List<Type>();
        }

        private void AddRequiredComponents()
        {
            List<Type> requiredComponents = availableCourseControllers[selectedIndex].GetRequiredSetupComponents();
            
            if (requiredComponents != null)
            {
                currentRequiredComponents = requiredComponents;
                foreach (Type requiredComponent in requiredComponents)
                {
                    setupObject.gameObject.AddComponent(requiredComponent);
                }
            }
        }

        private bool HasComponents()
        {
            List<Component> components = setupObject.gameObject.GetComponents<Component>().ToList();
            return currentRequiredComponents.Except(components.Select(c => c.GetType())).Any() == false;
        }
    }
}