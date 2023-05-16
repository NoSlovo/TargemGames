using System;
using UnityEngine;

public class ShapeElement : MonoBehaviour
{
    private float _repulsiveForce;
    private float _repulsiveMaxValue = 500f;
    private float _repulsiveMinValue = 50f;
    private MeshRenderer _mesh;
    private bool _encountered = false;

    public event Action ObjectsTouched;
    private void Start() => _mesh = GetComponent<MeshRenderer>();
    
    private void OnCollisionEnter(Collision collision)
    {
        ObjectsTouched?.Invoke();
        _mesh.material.color = Color.red;
        
        if (!_encountered)
        {
            _repulsiveForce = _repulsiveMaxValue;
            Repulse(_repulsiveForce);
        }
        else
        {
            _repulsiveForce = _repulsiveMinValue;
            Repulse(_repulsiveForce);
        }
    }
    
    private void Repulse(float power)
    {
        Collider[] overlapperdColliders = Physics.OverlapSphere(transform.position, 10f);

        for (int i = 0; i < overlapperdColliders.Length; i++)
        {
            Rigidbody rigidbody = overlapperdColliders[i].attachedRigidbody;
            if (rigidbody)
            {
                rigidbody.AddExplosionForce(power, transform.position, 10f, 0, ForceMode.Impulse);
            }
        }
    }
}