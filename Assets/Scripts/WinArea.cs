using UnityEngine;

[RequireComponent(typeof(CoinSpawner))]
[RequireComponent(typeof(BoxCollider2D))]
public class WinArea : MonoBehaviour
{
    [SerializeField] private int _coinsCountToSpawn = 5;
    [SerializeField] private int _millisecondsToSpawnCoin = 100;
    [SerializeField] private Transform _coinSpawnPoint;
    
    private CoinSpawner _coinSpawner;
    private bool _isActivated;

    private void Awake()
    {
        _coinSpawner = GetComponent<CoinSpawner>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Player>(out _) && !_isActivated)
        {
            _coinSpawner.SpawnCoinWithDelay(_coinSpawnPoint.position, _millisecondsToSpawnCoin.Milliseconds(), _coinsCountToSpawn);
            _isActivated = true;
        }
    }
}
