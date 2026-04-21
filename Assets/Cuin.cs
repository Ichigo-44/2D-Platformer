using Unity.VisualScripting;
using UnityEngine;

public class cuin : MonoBehaviour
{
    public float coin = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        Debug.Log(collision);
        collision.GetComponent<PlayerCoins>().AddCoins(coin);
    }
}

