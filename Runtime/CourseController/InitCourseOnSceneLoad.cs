using System;
using Innoactive.Creator.Core;
using Innoactive.Creator.Core.Configuration;
using UnityEngine;

namespace Innoactive.Creator.UX
{
    public class InitCourseOnSceneLoad : MonoBehaviour
    {
        private ICourse trainingCourse;

        private void OnEnable()
        {
            InitTraining();
        }

        private void InitTraining()
        {
            // Load training course from a file.
            string coursePath = RuntimeConfigurator.Instance.GetSelectedCourse();

            // Try to load the in the [TRAINING_CONFIGURATION] selected training course.
            try
            {
                trainingCourse = RuntimeConfigurator.Configuration.LoadCourse(coursePath);
            }
            catch (Exception exception)
            {
                Debug.LogError($"{exception.GetType().Name}, {exception.Message}\n{exception.StackTrace}",
                    RuntimeConfigurator.Instance.gameObject);
                return;
            }

            // Initializes the training course. That will synthesize an audio for the training instructions, too.
            CourseRunner.Initialize(trainingCourse);
        }
    }
}