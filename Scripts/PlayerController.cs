using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotationSpeed = 100f;
    public GameObject laserPrefab;
    public Transform laserSpawn;
    public float laserSpeed = 20f;
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;

    void Update()
    {
        // Movement
        float moveHorizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right arrow keys
        float moveVertical = Input.GetAxis("Vertical"); // W/S or Up/Down arrow keys

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);

        // Rotation
        float rotateHorizontal = Input.GetAxis("HorizontalArrow"); // Left/Right arrow keys
        float rotateVertical = Input.GetAxis("VerticalArrow"); // Up/Down arrow keys

        Vector3 rotation = new Vector3(rotateVertical, rotateHorizontal, 0.0f);
        transform.Rotate(rotation * rotationSpeed * Time.deltaTime, Space.Self);

        // Shooting
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            ShootLaser();
        }
    }

    void ShootLaser()
    {
        GameObject laser = Instantiate(laserPrefab, laserSpawn.position, laserSpawn.rotation);
        Rigidbody rb = laser.GetComponent<Rigidbody>();
        rb.velocity = laserSpawn.forward * laserSpeed;
    }
}