using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public string namee;
    public enum Status{
        SUCCESS,
        FAILURE,
        RUNNING
    }
    public Status status;
    public List<Node> children = new List<Node>();
    public int currentChild = 0;
    public virtual Status Process()
    {
        return children[currentChild].Process();    
    }
    public void AddChild(Node n)
    {
        children.Add(n);
    }
}
