using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public string text;
    public bool ip;
    private Node next;
    public List<Node> extraNodes = new List<Node>();

    public Node(string t, bool p) 
    {
        text = t;
        ip = p;
        next = null;
    }

    public string getText()
    {
        if (extraNodes.Count < 2)
        {
            return text;
        }
        return text + "<br>" + extraNodes[0].getText() + "<br>" + extraNodes[1].getText();
    }

    public bool getPrompt()
    {
        return ip;
    }

    public Node getNext()
    {
        return next;
    }

    public void setNode(Node n) 
    {
        next = n;
    }

    public void setPrompt(Node one, Node two) 
    {
        extraNodes.Add(one);
        extraNodes.Add(two);
    }

    public Node nextPrompt(int n)  
    {
        if (n == 0)
        {
            return this;
        }
        else
        {
            return extraNodes[n-1]; //dont care about saftey
        }
    }
}
