using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IArea : MonoBehaviour
{
    public ICondition condition;
    public UnityEvent resultAction;

    private void OnTriggerEnter(Collider other)
    {
        if (condition.actionType == ICondition.IConditionAction.Enters
            && condition.CheckActor(other.gameObject))
            resultAction?.Invoke();
    }

    private void OnTriggerStay(Collider other)
    {
        if (condition.actionType == ICondition.IConditionAction.Stay
            && condition.CheckActor(other.gameObject))
            resultAction?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (condition.actionType == ICondition.IConditionAction.Exits
            && condition.CheckActor(other.gameObject))
            resultAction?.Invoke();
    }

    [System.Serializable] public class ICondition
    {
        public string actorName;
        public IConditionActor actorType;
        public IConditionAction actionType;

        public bool CheckActor(GameObject actor)
        {
            return (actorType == IConditionActor.Any
                || (actorType == IConditionActor.Object && actor.name == actorName)
                || (actorType != IConditionActor.Object && actor.CompareTag(actorType.ToString())));
        }

        public enum IConditionActor { Player, Enemy, Object, Any }
        public enum IConditionAction { Enters, Exits, Stay }
    }
}
