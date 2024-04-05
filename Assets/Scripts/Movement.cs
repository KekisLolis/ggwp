using UnityEngine;

public class Movement : MonoBehaviour
{
    public Camera mainCamera;
    public Rigidbody rb;
    public float normalSpeed = 12f;
    public float nitroSpeed = 20f;
    public float horizontalInput;
    public float speed;

    private const float RotationSpeed = 2.5f;
    private const float NormalFov = 60f;
    private const float NitroFov = 66f;
    private const float NitroDuration = 3f;
    private const float NitroCooldown = 8f;
    private bool isNitroActive;
    private float nitroTimer;
    private float cooldownTimer;
    
    void Start()
    {
        speed = normalSpeed;
    }
    
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        transform.position = new Vector3 (transform.position.x, 0, transform.position.z);
        horizontalInput = Input.GetAxis("Horizontal");
        
        if (Input.GetKey(KeyCode.LeftShift)&& !isNitroActive && cooldownTimer <= 0f)
        {
            isNitroActive = true;
            speed = nitroSpeed;
            mainCamera.fieldOfView = NitroFov;
            nitroTimer = NitroDuration;
        }
        if (isNitroActive)
        {
            nitroTimer -= Time.deltaTime;
            if (nitroTimer <= 0f)
            {
                isNitroActive = false;
                speed = normalSpeed;
                mainCamera.fieldOfView = NormalFov;
                cooldownTimer = NitroCooldown;
            }
        }
        if (cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime;
        }
    }
    
    private void FixedUpdate()
    {
        rb.velocity = transform.forward * speed;
        rb.angularVelocity = new Vector3(0, RotationSpeed, 0) * horizontalInput;
    }
}