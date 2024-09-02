using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class amountObject : MonoBehaviour
{
    public string _nameDish;
    public string _compound;
    public int totalAmount = 0;

    public void giveNameAndCompound(string name, string compound)
    {
        _nameDish = name;
        _compound = compound;
    }
    public string getName()
    {
        return _nameDish;
    }

    public string getCompound()
    {
        return _compound;
    }
}
