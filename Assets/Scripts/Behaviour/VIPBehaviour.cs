using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class VIPBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject backDoor;
    [SerializeField] private GameObject bar;

    Node vipAiTree;
    
    NavMeshAgent agent;
    public enum ActionState
    {
        IDLE,
        WORKING
    }
    ActionState state = ActionState.IDLE;

    Node.Status treeStatus = Node.Status.RUNNING;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        vipAiTree = new Node("VIP AI Tree");

        Sequence cardControl = new Sequence("Card Control");
        Leaf goToBackDoor = new Leaf("Go to back door", () => GoToLocation(backDoor.transform.position));
        //Leaf hasCard = new Leaf("Has card ?", () =>
        //{
        //    if (transform.Find("Card") != null)
        //    {
        //        return Node.Status.SUCCESS;
        //    }
        //});
        Leaf enterBar = new Leaf("Go to bar", () => GoToLocation(bar.transform.position));

        
    }
    /*Node.Status GoToDoor(GameObject door)
    {
        Node.Status status = GoToLocation(door.transform.position);
        if (status == Node.Status.SUCCESS)
        {
            Lock doorLock = door.GetComponent<Lock>();
            if (!doorLock.isLocked)
            {
                door.SetActive(false);
                return Node.Status.SUCCESS;
            }
            return Node.Status.FAILURE;
        }
        else return status;
    }*/
    Node.Status GoToLocation(Vector3 destination)
    {
        float distanceToTarget = Vector3.Distance(transform.position, destination);
        if (state == ActionState.IDLE)
        {
            agent.SetDestination(destination);
            state = ActionState.WORKING;
        }
        else if (Vector3.Distance(agent.pathEndPosition, destination) >= 2f)
        {
            state = ActionState.IDLE;
            return Node.Status.FAILURE;
        }
        else if (distanceToTarget < 2)
        {
            state = ActionState.IDLE;
            return Node.Status.SUCCESS;
        }
        return Node.Status.RUNNING;
    }
    void Update()
    {
        if (treeStatus != Node.Status.SUCCESS)
        {
            treeStatus = vipAiTree.Process();
        }
    }
}
