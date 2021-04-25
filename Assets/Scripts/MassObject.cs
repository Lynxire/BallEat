using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassObject : MonoBehaviour
{

    [SerializeField] private float _mass;

    public float GetMass() => _mass;
    public void AddMass(float mass) 
    {
        _mass += mass;
    }

    public bool isBiggest(float mass) 
    {
        if (mass > this._mass)
            return true;
        else
            return false;
    }

}
