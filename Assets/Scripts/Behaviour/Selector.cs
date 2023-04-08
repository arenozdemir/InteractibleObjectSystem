using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Node
{
    public Selector(string name) : base(name) { }

    public override Status Process()
    {
        Status childStatus = children[currentChild].Process();
        if (childStatus == Status.SUCCESS)
        {
            return Status.SUCCESS;
        }
        else if (childStatus == Status.FAILURE)
        {
            currentChild++;
            if (currentChild >= children.Count)
            {
                currentChild = 0;
                return Status.FAILURE;
            }
            else
            {
                return Status.RUNNING;
            }
        }
        else
        {
            return Status.RUNNING;
        }
    }

}
