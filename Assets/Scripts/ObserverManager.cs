using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObserverManager : MonoBehaviour
{
    List<InteractableObjectsInterface> interactableObjects = new List<InteractableObjectsInterface>();
    private static ObserverManager instance;
    public static ObserverManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ObserverManager>();
            }
            return instance;
        }
    }
    public void AddInteractibleObject(InteractableObjectsInterface interactableObject) 
    {
        interactableObjects.Add(interactableObject);
    }   
    protected void NotifyInteractableObjects(PlayerActionsEnum action, string objectName)
    {
        interactableObjects.ForEach(interactableObject => interactableObject.NotifyInteractableObjects(action,objectName));
    }
}
