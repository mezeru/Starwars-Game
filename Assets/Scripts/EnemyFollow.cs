using UnityEngine;

public class BossController : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    public float retreatDistance = 2f;
    public float knockbackDistance = 4f;
    public float knockbackDuration = 0.5f; // Duration of knockback movement

    private Rigidbody rb;
    private Vector3 initialPosition;
    private Vector3 knockbackStartPosition;
    private Vector3 knockbackTargetPosition;
    private bool isKnockedBack = false;
    private float knockbackTimer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;
    }

    void Update()
    {
        if (!isKnockedBack)
        {
            if (player != null)
            {
                Vector3 direction = player.position - transform.position;
                rb.velocity = direction.normalized * moveSpeed;
            }
            transform.LookAt(player);
            transform.eulerAngles = new Vector3(0, -90, 0);
        }
        else
        {
            // Move towards the knockback target position
            transform.position = Vector3.Lerp(knockbackStartPosition, knockbackTargetPosition, knockbackTimer / knockbackDuration);
            
            // Update the knockback timer
            knockbackTimer += Time.deltaTime;
            
            // Check if knockback duration has elapsed
            if (knockbackTimer >= knockbackDuration)
            {
                // Reset knockback state
                isKnockedBack = false;
                knockbackTimer = 0f;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HitByPlayer();
        }

        if (collision.gameObject.CompareTag("Sword") || collision.gameObject.CompareTag("RO"))
        {
            HitBySword();
        }
    }

    public void HitByPlayer()
{
    // Move slightly back
    transform.position -= transform.forward * retreatDistance;
    isKnockedBack = true;
    knockbackStartPosition = transform.position;
    knockbackTargetPosition = initialPosition;
}

public void HitBySword()
{
    // Move back a lot
    transform.position -= transform.forward * knockbackDistance;
    isKnockedBack = true;
    knockbackStartPosition = transform.position;
    knockbackTargetPosition = initialPosition;
}
}
