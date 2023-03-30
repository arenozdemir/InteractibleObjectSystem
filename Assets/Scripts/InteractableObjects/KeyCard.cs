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
        bu kýsým UI çalýþmasý için
        if (other.gameObject.CompareTag("Player"))
            OnPlayerTriggered?.Invoke();
    }*/
}
