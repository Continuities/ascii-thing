using UnityEngine;

public class PlayerController : MonoBehaviour
{
  [SerializeField]
  float movementForce = 50000;

  PlayerControls controls;
  Rigidbody rb;

  void Start()
  {
    controls = new PlayerControls();
    controls.Player_Map.Enable();
    rb = GetComponent<Rigidbody>();
  }

  void FixedUpdate()
  {
    var move = controls.Player_Map.Movement.ReadValue<Vector2>();
    // float forcez = move.x * movementForce * Time.deltaTime;
    // float forcex = move.y * movementForce * Time.deltaTime;
    // rb.AddForce(transform.forward * forcex, ForceMode.Force);
    // rb.AddForce(transform.right * forcez, ForceMode.Force);
    rb.velocity = new Vector3(move.x * movementForce * Time.deltaTime, 0, move.y * movementForce * Time.deltaTime);
  }
}
