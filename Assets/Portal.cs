using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform destination;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.position = destination.position;
    }

}
