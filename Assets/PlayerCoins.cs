using UnityEngine;

public class PlayerCoins : MonoBehaviour
{
    public float coin;

    public delegate void CoinChangedHandler(float newCoin, float ammountChanged);
    public event CoinChangedHandler OncoinChanged;

    public delegate void CoinInitialisedHandler(float newCoin);
    public event CoinInitialisedHandler OncoincInitialised;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCoin(float coinToAdd)
    {
        coin += coinToAdd;
        OncoinChanged?.Invoke(coin, coinToAdd);
    }
}
