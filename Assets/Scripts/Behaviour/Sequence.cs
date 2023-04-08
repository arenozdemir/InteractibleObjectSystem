using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Node
{
    public override Status Process()
    {
        while (currentChild < children.Count)
        {
         
            Status s = children[currentChild].Process();
            if (s != Status.SUCCESS)
                return s;
            currentChild++;
        }
        return Status.RUNNING;
    }
    
}
