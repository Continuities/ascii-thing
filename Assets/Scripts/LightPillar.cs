using UnityEngine;

public class LightPillar : MonoBehaviour
{
  [SerializeField]
  float animationDelay = 0f;
  [SerializeField]
  Transform target = null;

  Light light;

  void Start()
  {
    Invoke("StartAnimation", animationDelay);
    light = GetComponentInChildren<Light>();
    if (target == null)
    {
      target = GameObject.FindWithTag("Player").transform;
    }
  }

  void Update()
  {
    var axisTarget = new Vector3(target.position.x, transform.position.y, target.position.z);
    transform.LookAt(axisTarget, Vector3.up);
    // light.intensity = Random.Range(1.4f, 1.6f);
  }

  void StartAnimation()
  {
    var animator = GetComponent<Animator>();
    animator.enabled = true;
    // animator.Play("Base Layer.LightPillar", 0, 0);
  }
}