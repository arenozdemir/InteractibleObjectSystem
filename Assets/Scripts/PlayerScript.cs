using Newtonsoft.Json.Bson;
using System.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
public class PlayerScript : ObserverManager
{
    [SerializeField]
    [Range(0, 2)] private float interactRange = 1f;
    
    NavMeshAgent playerNavMeshAgent;
    private InputManager playerInput;
    
    private bool isInteracted;
    private void Awake()
    {
        playerInput = new InputManager();
        playerNavMeshAgent = GetComponent<NavMeshAgent>();

        playerInput.FindAction("Interact").started += Interact;
        playerInput.FindAction("Interact").performed += Interact;
        playerInput.FindAction("Interact").canceled += Interact;
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPosition();
        RotatePlayer();
        EnvironmentDetecting();
    }
    #region moving
    private void MoveToPosition()
    {
        if (Mouse.current.rightButton.IsPressed())
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                playerNavMeshAgent.SetDestination(hit.point);
            }
        }
    }
    #endregion

    #region rotating
    private void RotatePlayer()
    {
        Vector3 direction = playerNavMeshAgent.steeringTarget - transform.position;
        direction.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 5);
    }
    #endregion

    #region Interact
    private void Interact(InputAction.CallbackContext context)
    {
        isInteracted = context.performed || context.started;
    }
    private void EnvironmentDetecting()
    {
        if (isInteracted)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position + Vector3.up, interactRange);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag("Interactable"))
                {
                    NotifyInteractableObjects(PlayerActionsEnum.Interact, hitCollider.name);
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + Vector3.up, interactRange);
    }
    #endregion
    private void OnEnable()
    {
        playerInput.Enable();
    }
    private void OnDisable()
    {
        playerInput.Disable();
    }
}