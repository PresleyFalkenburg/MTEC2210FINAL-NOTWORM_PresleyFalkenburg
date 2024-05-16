using UnityEngine;

public class LandmineManager : MonoBehaviour
{
    public float explosionForce = 10f; // Base explosion force
    public float playerForceMultiplier = 5f; // Additional force multiplier for player
    public float blastRadius = 5f; // Blast radius of the explosion

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if collider belongs to player or bullet
        if (collision.collider.CompareTag("Player") || collision.collider.CompareTag("Bullet"))
        {
            Explode(collision);
        }
    }

    void Explode(Collision2D collision)
    {
        // Visual and sound effects (optional)
        // You can add code to instantiate explosion effects and play sound here

        // Apply physics effects
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, blastRadius);

        foreach (Collider2D collider in colliders)
        {
            Rigidbody2D otherRb = collider.GetComponent<Rigidbody2D>();
            if (otherRb != null)
            {
                // Apply force based on distance to explosion center
                Vector2 direction = otherRb.transform.position - transform.position;
                float distance = direction.magnitude;
                float forceMultiplier = Mathf.InverseLerp(blastRadius, 0.0f, distance); // Higher force closer to center

                // Apply base force
                otherRb.AddForce(direction.normalized * explosionForce * forceMultiplier, ForceMode2D.Impulse);

                // Apply additional force for player
                if (collider.CompareTag("Player"))
                {
                    otherRb.AddForce(direction.normalized * explosionForce * playerForceMultiplier * forceMultiplier, ForceMode2D.Impulse);
                }
            }
        }

        // Destroy the landmine after explosion
        Destroy(gameObject);
    }
}
