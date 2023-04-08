using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static VIPBehaviour;
using UnityEngine.EventSystems;

public class GoToBar : Leaf
{
    [SerializeField] GameObject bar;
    [SerializeField] VIPBehaviour vipBehaviour;
    public override Status Process()
    {
        Node.Status status = GoToLocation(bar.transform.position);
        return status;
    }
    Node.Status GoToLocation(Vector3 destination)
    {
        float distanceToTarget = Vector3.Distance(transform.position, destination);
        if (vipBehaviour.state == ActionState.IDLE)
        {
            vipBehaviour.agent.SetDestination(destination);
            vipBehaviour.state = ActionState.WORKING;
        }
        else if (Vector3.Distance(vipBehaviour.agent.pathEndPosition, destination) >= 2f)
        {
            vipBehaviour.state = ActionState.IDLE;
            return Node.Status.FAILURE;
        }
        else if (distanceToTarget < 2)
        {
            vipBehaviour.state = ActionState.IDLE;
            return Node.Status.SUCCESS;
        }
        return Node.Status.RUNNING;
    }
}