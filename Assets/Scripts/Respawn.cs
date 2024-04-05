using UnityEngine;

public class Respawn : MonoBehaviour
{
    private Movement movement;

        private void Start()
        {
            movement = GetComponent<Movement>();
            //float speedResp = Movement.speed;
        }

    public float timeRespawn = 3f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            RespawnCar();
        }
    }

    private void RespawnCar()
    {
        timeRespawn -= Time.deltaTime;
        if (timeRespawn >= 3)
        {
            //speedResp = 0;
        }

        transform.position = new Vector3(0, 0, 0);
    }
}