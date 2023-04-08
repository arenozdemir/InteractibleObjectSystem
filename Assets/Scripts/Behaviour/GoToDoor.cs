using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static VIPBehaviour;

public class GoToDoor : Leaf
{
    [SerializeField] GameObject door;

    [SerializeField] VIPBehaviour vipBehaviour;
    public override Status Process()
    {
        Node.Status status = GoToLocation(door.transform.position);
        return status;
    }
    Node.Status GoToLocation(Vector3 destination)
    {
        float distanceToTarget = Vector3.Distance(vipBehaviour.transform.position, destination);
        if (vipBehaviour.state == ActionState.IDLE)
        {
            vipBehaviour.agent.SetDestination(destination);
            vipBehaviour.state = ActionState.WORKING;
        }
        else if (Vector3.Distance(vipBehaviour.agent.pathEndPosition, destination) >= 2f)
        {
            Debug.Log("GoToDoor: Failed to reach door");
            vipBehaviour.state = ActionState.IDLE;
            return Node.Status.FAILURE;
        }
        else if (distanceToTarget < 2)
        {
            Debug.Log("GoToDoor: Reached door");
            vipBehaviour.state = ActionState.IDLE;
            return Node.Status.SUCCESS;
        }
        Debug.Log("GoToDoor: Running");
        return Node.Status.RUNNING;
    }
}
