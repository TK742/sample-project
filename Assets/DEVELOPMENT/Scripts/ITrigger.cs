using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ITrigger : MonoBehaviour
{
    public UnityEvent ResultAction => resultAction;
    [SerializeField] private UnityEvent resultAction;
}