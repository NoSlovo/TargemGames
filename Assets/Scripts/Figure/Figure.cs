using UnityEngine;

public class Figure : MonoBehaviour
{
   private Rigidbody _rb;
   public Rigidbody Rb => _rb;
   private void Start() => _rb = GetComponent<Rigidbody>();
}
