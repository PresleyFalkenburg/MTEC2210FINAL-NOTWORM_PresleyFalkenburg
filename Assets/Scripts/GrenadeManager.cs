using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeManager : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float shootForce;
    public float explosionForce;
    public float timer = 5.0f; // Time before explosion (in seconds)
    private float countdown;

    // References to explosion sprite
    public SpriteRenderer explosionSprite;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * shootForce;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);

        // Ensure explosion sprite is initially disabled
        explosionSprite.enabled = false;

        countdown = timer;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0)
        {
            Explode();
        }
    }

    // Function to handle the explosion
    void Explode()
    {
        // Get all colliders within the radius
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, GetBlastRadius());

        // Loop through each collider
        foreach (Collider2D collider in colliders)
        {
            Rigidbody2D otherRb = collider.GetComponent<Rigidbody2D>();
            if (otherRb != null)
            {
                Vector2 direction = otherRb.transform.position - transform.position;
                float distance = direction.magnitude;
                float forceMultiplier = Mathf.InverseLerp(GetBlastRadius(), 0.0f, distance);
                otherRb.AddForce(direction.normalized * explosionForce * forceMultiplier, ForceMode2D.Impulse);
            }
        }

        // Enable explosion sprite on explosion
        explosionSprite.enabled = true;
        new WaitForSeconds(0.5f);

        // Destroy the grenade after explosion (optional)
        Destroy(gameObject);
    }

    // Function to get the blast radius (you can adjust this value)
    float GetBlastRadius()
    {
        return 5.0f; // adjust as needed
    }
}
