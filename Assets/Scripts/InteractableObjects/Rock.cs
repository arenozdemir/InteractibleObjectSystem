using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour, InteractableObjectsInterface
{
    private void Awake()
    {
        ObserverManager.Instance.AddInteractibleObject(this);
    }
    public void NotifyInteractableObjects(PlayerActionsEnum action, string objectName)
    {
        if (action == PlayerActionsEnum.Interact && objectName == gameObject.name)
        {
            Debug.Log("Rock: NotifyInteractableObjects");
        }
    }
}
