using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardNotOkay : Leaf
{
    public override Status Process()
    {
        Debug.Log("Kart�� �ald�rd�k amk");
        return Status.SUCCESS;
    }
}
