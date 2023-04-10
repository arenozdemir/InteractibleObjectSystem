using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : Node
{
    protected Animator animator;

    private void Awake()
    {
        animator = transform.root.GetComponent<Animator>();
    }
    //public delegate Status Tick();
    //public Tick ProcessMethod;

    //public Leaf() { }

    //public Leaf(string n, Tick pm)
    //{
    //    name = n;
    //    ProcessMethod = pm;
    //}
    //public override Status Process()
    //{
    //    if (ProcessMethod != null)
    //        return ProcessMethod();
    //    return Status.FAILURE;
    //}

}
