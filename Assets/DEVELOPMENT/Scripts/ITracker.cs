using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ITracker : MonoBehaviour
{
    public ICondition condition;
    public UnityEvent resultAction;

    public void CheckConditions()
    {
        if (!condition.CheckCondition()) return;
        resultAction?.Invoke();
    }

    [System.Serializable]
    public class ICondition
    {
        public GameObject[] trackedActors;
        public IConditionAction actionType;

        public bool CheckCondition()
        {
            switch (actionType)
            {
                case IConditionAction.Active:
                    foreach (var actor in trackedActors)
                        if (!actor.activeSelf)
                            return false;
                    break;
                case IConditionAction.Inactive:
                    foreach (var actor in trackedActors)
                        if (actor.activeSelf)
                            return false;
                    break;
                case IConditionAction.Destroyed:
                    foreach (var actor in trackedActors)
                        if (actor != null)
                            return false;
                    break;
            }
            return true;
        }

        public enum IConditionAction { Active, Inactive, Destroyed }
    }
}
