using UnityEngine;

public class Book : MonoBehaviour, InteractableObjectsInterface
{
    private void Awake()
    {
        ObserverManager.Instance.AddInteractibleObject(this);
    }
    public void NotifyInteractableObjects(PlayerActionsEnum action, string objectName)
    {
        if (action == PlayerActionsEnum.Interact && objectName == gameObject.name)
        {
            Debug.Log("Book: NotifyInteractableObjects");
        }
    }
}
