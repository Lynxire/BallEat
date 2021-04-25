using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _curentMass, _targetMass;
    [SerializeField] private float _speedSizeAdd;
    private Rigidbody _rb;
    private Transform transform;
    private MassObject _mass;
    


    private void Start()
    {

        _mass = GetComponent<MassObject>();
        _rb = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
      
    }

    private void FixedUpdate()
    {
        transform.localScale = new Vector3(_curentMass,  _curentMass, _curentMass);
        _curentMass = Mathf.LerpUnclamped(_curentMass, _targetMass, _speedSizeAdd);
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(moveHorizontal, 0.0f, moveVertical);
        _rb.AddForce(move * _speed);
    }
    void OnCollisionEnter(Collision myCollision)
    {
        if (myCollision.gameObject.tag == "Destr")
        {
            if (!myCollision.gameObject.GetComponent<Destroy>().GetStay())
            {
                if (myCollision.gameObject.GetComponent<MassObject>().isBiggest(_mass.GetMass()))
                {
                    _targetMass += 0.5F;
                    _mass.AddMass(myCollision.gameObject.GetComponent<MassObject>().GetMass() / 2);
                    _speed -= _mass.GetMass() / 10;
                    myCollision.gameObject.GetComponent<Destroy>().DestroyObj();
                    myCollision.gameObject.GetComponent<Destroy>().SetStay(true);
                }
            }

        }
    }
}