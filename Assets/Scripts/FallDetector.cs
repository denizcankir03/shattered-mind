using UnityEngine;
using UnityEngine.SceneManagement;

public class FallDetector : MonoBehaviour
{
    public float fallThreshold = -10f;
    Damageable damageable;

    private void Awake()
    {
        damageable = GetComponent<Damageable>();
    }

    private void Update()
    {
        if (transform.position.y < fallThreshold && damageable.IsAlive)
        {
            damageable.Health = 0; // Ölüm tetiklenir
        }
    }
}
