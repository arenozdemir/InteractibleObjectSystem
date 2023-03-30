using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour, InteractableObjectsInterface
{
    //Enemy'nin �zerinde sahip oldu�u bir item olabilir. E�er bir iteme sahipse bu item'de kart gibi bir 
    //interactible obje olacakt�r. Dolay�s�yla her enemy ile etkile�ime girdi�imizde bu enemynin �zerinde varsa
    //interactible obje tipinde bir childa sahipse, bu childla etkile�ime girip onu alaca��z
    public void NotifyInteractableObjects()
    {
        Debug.Log("EnemyScript: NotifyInteractableObjects");
        ObjectControl();
    }
    
    private void ObjectControl()
    {
        foreach (Transform child in transform)
        {
            if (child.GetComponent<InteractableObjectsInterface>() != null)
            {
                child.parent = null;
                child.gameObject.SetActive(false);
                PlayerScript player = FindObjectOfType<PlayerScript>();
                player.SetTestObject(child.gameObject);
            }
        }
    }
}
