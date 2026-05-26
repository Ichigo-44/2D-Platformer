using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float speed = 3f;
    public float distance = 5f;
    private Vector3 startPos;


    public float jumpForce = 15f;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float offset = Mathf.Sin(Time.time * speed) * distance;
        transform.position = startPos + new Vector3(offset, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();
        if (playerRb != null)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}