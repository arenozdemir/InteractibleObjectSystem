using System;
using UnityEngine;

public class KeyCard : MonoBehaviour,InteractableObjectsInterface
{
    //public event Action OnPlayerTriggered;
    public void NotifyInteractableObjects()
    {
        Debug.Log("KeyCard: NotifyInteractableObjects");
    }
    /*private void OnTriggerEnter(Collider other)
    {
        bu k�s�m UI �al��mas� i�in
        if (other.gameObject.CompareTag("Player"))
            OnPlayerTriggered?.Invoke();
    }*/
}
