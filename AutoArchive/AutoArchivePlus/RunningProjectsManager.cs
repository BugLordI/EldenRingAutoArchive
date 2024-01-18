using AutoArchivePlus.Model;
using System;
using System.Collections.Generic;

namespace AutoArchivePlus
{
    public class RunningProjectsManager
    {
        private static List<Project> runningList = new List<Project>();
        private static List<Action<Project>> onStopSubscriber=new List<Action<Project>>();
        private static List<Action<Project>> onRunningSubscriber = new List<Action<Project>>();

        private RunningProjectsManager()
        {
        }

        public static void Add(Project project)
        {
            if (project != null)
            {
                runningList.Add(project);
                runningNotification(project);
            }
        }

        public static void Remove(Project project)
        {
            if (project != null)
            {
                runningList.Remove(project);
                //TODO Subscribe call
            }
        }

        public static void OnStopSubscribe(Action<Project> action)
        {
            if (action != null)
            {
                onStopSubscriber.Add(action);
            }
        }

        public static void OnRunningSubscribe(Action<Project> action)
        {
            if (action != null)
            {
                onRunningSubscriber.Add(action);
            }
        }


        public static bool IsRunning(Project project)
        {
            return runningList.Contains(project);
        }

        private static void runningNotification(Project project)
        {
            foreach (var item in onRunningSubscriber)
            {
                item.Invoke(project);
            }
        }

    }
}
