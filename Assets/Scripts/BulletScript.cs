using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Camera mainCam;
    private Rigidbody2D rb;
    public float bulletSpeed;
    public float spreadAngle; 
    public float lifetime = 3f;// Angle for bullet spread (in degrees)

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();

        // Calculate a random direction based on spread angle
        Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        float randomAngleOffset = Random.Range(-spreadAngle / 2f, spreadAngle / 2f);
        direction = Quaternion.Euler(0, 0, randomAngleOffset) * direction;

        // Set velocity with the adjusted direction
        rb.velocity = direction.normalized * bulletSpeed;
        Destroy(gameObject, lifetime);
        // Optional: Destroy the bullet after a set time (if needed)
        // Destroy(gameObject, timeToLive);
    }
}
