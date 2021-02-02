using System;
using System.Threading.Tasks;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private float _coinForce;
    [SerializeField] private float _coinWidthForce;
    
    public async Task SpawnCoinWithDelay(Vector3 position, TimeSpan delay, int count)
    {
        for (int i = 0; i < count; i++)
        {
            var coinForceDirection = Vector2.up;
            coinForceDirection.x = Random.Range(-_coinWidthForce, _coinWidthForce);
            var coin = Instantiate(_coinPrefab, position, quaternion.identity);
            coin.GetComponent<Rigidbody2D>().AddForce(coinForceDirection * _coinForce, ForceMode2D.Force);
            await Task.Delay(delay);
        }
    }
}
