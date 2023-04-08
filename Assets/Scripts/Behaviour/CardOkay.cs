using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardOkay : Leaf
{
    [SerializeField] GameObject card;
    public override Status Process()
    {
        if (card.transform.parent == null)
        {
            return Status.FAILURE;
        }
        else
        {
            return Status.SUCCESS;
        }
    }
}
