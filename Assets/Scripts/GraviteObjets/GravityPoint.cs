using System;
using UnityEngine;

public class GravityPoint : MonoBehaviour
{
    [SerializeField] private Figure[] _figures;
    
    private float _force = 25f;
    
    private void Update() => MoveFigures();
    
    private void MoveFigures()
    {
        for (int i = 0; i < _figures.Length; i++)
        {
            var direction = (transform.position - _figures[i].transform.position ).normalized;
            var distance = Vector3.Distance(_figures[i].transform.position, transform.position);
            _figures[i].Rb.AddForce(direction * (distance * _force),ForceMode.Force);
        }
    }
}
