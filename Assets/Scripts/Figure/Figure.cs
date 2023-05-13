using UnityEngine;

public class Figure : MonoBehaviour
{
   [SerializeField] private GravityPoint gravityPoint;
   
   private Rigidbody _rb;
   private float _spead = 25f;
   private void Start() => _rb = GetComponent<Rigidbody>();

   private void Update() => MovePosition();
   
  private void MovePosition()
   {
      var direction = (gravityPoint.transform.position - transform.position).normalized;
      var distance = Vector3.Distance(gravityPoint.transform.position, transform.position);
      _rb.AddForce(direction * (distance * _spead),ForceMode.Force);
   }
}
