using UnityEngine;

public class PlayerController : MonoBehaviour
{
  [SerializeField]
  float movementForce = 50000;
  [SerializeField]
  float lookSensitivity = 1;
  [SerializeField]
  bool lockHoriztonalRotation = false;
  [SerializeField]
  bool lockVerticalRotation = false;

  PlayerControls controls;
  Rigidbody rb;

  private float ClampAngle(float angle, float from, float to)
  {
    // accepts e.g. -80, 80
    if (angle < 0f) angle = 360 + angle;
    if (angle > 180f) return Mathf.Max(angle, 360 + from);
    return Mathf.Min(angle, to);
  }

  private void AimPlayer()
  {
    var look = controls.Player_Map.Look.ReadValue<Vector2>();
    if (!lockHoriztonalRotation)
    {
      transform.Rotate(0, look.x * lookSensitivity * Time.deltaTime, 0);
    }

    if (!lockVerticalRotation)
    {
      Vector3 cameraRotation = Camera.main.transform.rotation.eulerAngles + new Vector3(-look.y * lookSensitivity * Time.deltaTime, 0, 0);
      cameraRotation.x = ClampAngle(cameraRotation.x, -90f, 90f);
      Camera.main.transform.eulerAngles = cameraRotation;
    }
  }

  private void MovePlayer()
  {
    var move = controls.Player_Map.Movement.ReadValue<Vector2>();
    float forcez = move.x * movementForce * Time.deltaTime;
    float forcex = move.y * movementForce * Time.deltaTime;
    rb.AddForce(transform.forward * forcex, ForceMode.Force);
    rb.AddForce(transform.right * forcez, ForceMode.Force);
  }

  void Start()
  {
    controls = new PlayerControls();
    controls.Player_Map.Enable();
    rb = GetComponent<Rigidbody>();
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
  }

  void FixedUpdate()
  {
    AimPlayer();
    MovePlayer();
  }
}
