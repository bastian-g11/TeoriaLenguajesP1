using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglyLinkedList
{
    private Node firstNode, lastNode;

    public SinglyLinkedList()
    {
        firstNode = null;
        lastNode = null;
    }

    public Node GetFirstNode()
    {
        return firstNode;
    }

    public Node GetLastNode()
    {
        return lastNode;
    }

    //Recorrer Lista Simplemente Ligada
    public void TraverseLinkedList()
    {
        Node node = firstNode;
        while(node != null)
        {
            //Lo que vayamos a hacer
            Debug.Log("Nodo: " + node.GetValue());
            node = node.GetNextNode();
        }
    }

    public void InsertNode(string _dataType, string _value, Node y)
    {
        Node node = new Node(_dataType, _value);
        //Debug.Log("<color=yellow>IN Lista: </color>" + SinglyLinkedListController.instance.singlyLinkedList.GetFirstNode());
        //Debug.Log("<color=yellow>IN Nodo insertado: </color>" + node);
        //Debug.Log("<color=yellow>IN Nodo Y: </color>" + y);
        ConnectNode(node, y);
    }

    public void ConnectNode(Node node, Node y)
    {
        //if (y == null)
        //{
        //    if (y == lastNode)
        //    {
        //        lastNode = node;
        //    }
        //    else
        //    {
        //        node.SetNextNode(firstNode);
        //    }
        //    firstNode = node;
        //    return;
        //}
        //node.SetNextNode(y.GetNextNode());
        //y.SetNextNode(node);
        //if (y == lastNode)
        //{
        //    lastNode = node;
        //}

        if (y != null)
        {
            node.SetNextNode(y.GetNextNode());
            y.SetNextNode(node);
            if (y == lastNode)
            {
                lastNode = node;
            }
        }
        else
        {
            node.SetNextNode(firstNode);
            if (firstNode == null)
            {
                lastNode = node;
            }
            firstNode = node;
        }
        UIController.instance.createdNode = node;
    }
}
