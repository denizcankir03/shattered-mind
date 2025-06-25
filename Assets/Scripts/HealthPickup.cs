using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthRestore = 20;
    public Vector3 spinRotationSpeed = new Vector3(0, 100, 0); 

    
    void Start()
    {
        
    }

   
    void Update()
    {
        transform.eulerAngles += spinRotationSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable damageable = collision.GetComponent<Damageable>();

        if(damageable)
        {
            bool wasHealed = damageable.Heal(healthRestore);

            if (wasHealed)           
            Destroy(gameObject);
        }


    }

}
