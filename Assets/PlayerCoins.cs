using UnityEngine;

public class PlayerCoins : MonoBehaviour
{
    public float coin;

    public delegate void CoinChangedHandler(float newCoin, float ammountChanged);
    public event CoinChangedHandler OncoinChanged;

    public delegate void CoinInitialisedHandler(float newCoin);
    public event CoinInitialisedHandler OncoincInitialised;

    public void AddCoins(float coin)
    { }
 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Addcoins(float coinToAdd)
    {
        coin += coinToAdd;
        OncoinChanged?.Invoke(coin, coinToAdd);
    }
}
