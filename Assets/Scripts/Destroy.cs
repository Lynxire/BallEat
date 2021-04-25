using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private BoxCollider _bx;

    private bool _isTake;

    private void Start()
    {
        _bx = GetComponent<BoxCollider>();
    }

    public bool GetStay() => _isTake;
    public void SetStay(bool value) 
    {
        _isTake = value;
    }

    public void DestroyObj() 
    {

        Invoke("DestroyThisObj",2);

    }

    private void DestroyThisObj() 
    {
        Destroy(gameObject);
    }
    
}

