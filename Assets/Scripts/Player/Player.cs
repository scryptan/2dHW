using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _coinsCount = 0;

    public Action<int> CoinTook;
    public void TakeCoin(Coin coin)
    {
        _coinsCount++;
        Destroy(coin.gameObject);
        CoinTook(_coinsCount);
    }
}