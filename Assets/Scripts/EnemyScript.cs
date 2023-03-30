using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour, InteractableObjectsInterface
{
    //Enemy'nin üzerinde sahip olduðu bir item olabilir. Eðer bir iteme sahipse bu item'de kart gibi bir 
    //interactible obje olacaktýr. Dolayýsýyla her enemy ile etkileþime girdiðimizde bu enemynin üzerinde varsa
    //interactible obje tipinde bir childa sahipse, bu childla etkileþime girip onu alacaðýz
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
