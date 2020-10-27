using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    private string classType;
    private string value;
    private Node nextNode;

    public Node(string _classType, string _value)
    {
        classType = _classType;
        value = _value;
        nextNode = null;
    }

    public string GetClassType()
    {
        return classType;
    }

    public string GetValue()
    {
        return value;
    }

    public Node GetNextNode()
    {
        return nextNode;
    }

    public void SetClassType(string _classType)
    {
        classType = _classType;
    }

    public void SetValue(string _value)
    {
        value = _value;
    }

    public void SetNextNode(Node _nextNode)
    {
        nextNode = _nextNode;
    }
}
