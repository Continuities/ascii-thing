using UnityEngine;

public class LightPillar : MonoBehaviour
{
  [SerializeField]
  float minDelay = 0f;
  [SerializeField]
  float maxDelay = 0f;
  [SerializeField]
  Transform target = null;

  void Start()
  {
    var animationDelay = Random.Range(minDelay, maxDelay);
    Invoke("StartAnimation", animationDelay);
    if (target == null)
    {
      target = GameObject.FindWithTag("Player").transform;
    }
  }

  void Update()
  {
    var axisTarget = new Vector3(target.position.x, transform.position.y, target.position.z);
    transform.LookAt(axisTarget, Vector3.up);
  }

  void StartAnimation()
  {
    var animator = GetComponent<Animator>();
    animator.enabled = true;
  }
}