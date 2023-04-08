using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static VIPBehaviour;

public class GoToSecurity : Leaf
{
    [SerializeField] GameObject security;
    [SerializeField] VIPBehaviour vipBehaviour;
    public override Status Process()
    {
        Node.Status status = GoToLocation(security.transform.position);
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
            Debug.Log("GoTOSecurity : Fail");
            vipBehaviour.state = ActionState.IDLE;
            return Node.Status.FAILURE;
        }
        else if (distanceToTarget < 2)
        {
            Debug.Log("GoTOSecurity : Success");
            vipBehaviour.state = ActionState.IDLE;
            return Node.Status.SUCCESS;
        }
        Debug.Log("GoTOSecurity : run");
        return Node.Status.RUNNING;
    }
}
