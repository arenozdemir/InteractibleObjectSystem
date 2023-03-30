using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour, InteractableObjectsInterface
{
    public void NotifyInteractableObjects()
    {
        Debug.Log("EnemyScript: NotifyInteractableObjects");
    }
}
