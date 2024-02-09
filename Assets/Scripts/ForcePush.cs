using UnityEngine;

public class GameObjectController : MonoBehaviour
{
    
    public float pushRadius;
    public float pushAmount;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Push();
        }
    }

    private void Push()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, pushRadius);

        foreach(Collider i in colliders)
        {
            if(i.CompareTag("Enemy"))
            {
                Rigidbody enemy = i.GetComponent<Rigidbody>();
                enemy.AddExplosionForce(pushAmount, Vector3.up, pushRadius);

                // Destroy the enemy after 2 seconds
                Destroy(i.gameObject, 2f);
            }
        }
    }
}
