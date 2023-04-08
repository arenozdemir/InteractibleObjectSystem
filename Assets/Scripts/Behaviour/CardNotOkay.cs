using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardNotOkay : Leaf
{
    public override Status Process()
    {
        Debug.Log("Kartçý çaldýrdýk amk");
        return Status.SUCCESS;
    }
}
