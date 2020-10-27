using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    private string dataType;
    private string value;
    private Node nextNode;

    public Node(string _dataType, string _value)
    {
        dataType = _dataType;
        value = _value;
        nextNode = null;

    }

    public string GetDataType()
    {
        return dataType;
    }

    public string GetValue()
    {
        return value;
    }

    public Node GetNextNode()
    {
        return nextNode;
    }

    public void SetDataType(string _dataType)
    {
        dataType = _dataType;
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
