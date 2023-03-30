using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTester : MonoBehaviour, InteractableObjectsInterface
{
    public void NotifyInteractableObjects()
    {
        PlayerScript player = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();
        if (player.GetTestObject() != null)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
        }
    }
}

