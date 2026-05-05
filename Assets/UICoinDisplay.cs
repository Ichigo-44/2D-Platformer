using TMPro;
using UnityEngine;
using System;

public class UICoinDesplay : MonoBehaviour
{
    public TextMeshProUGUI CoinText;
    public PlayerCoins PlayerCoin;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        PlayerCoin.OncoinChanged += OnCoinChanged;
        PlayerCoin.OncoincInitialised += OnCoinChanged;
    }

    private void OnCoinChanged(float newCoin)
    {
        CoinText.text = newCoin.ToString();
    }
    public void OnCoinChanged(float newCoin, float amountChanged)
    {
        CoinText.text = newCoin.ToString();
    }

}