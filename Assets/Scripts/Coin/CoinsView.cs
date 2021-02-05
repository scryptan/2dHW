using System;
using System.Data;
using TMPro;
using UnityEngine;

public class CoinsView : MonoBehaviour
{
    [SerializeField] private TMP_Text _text; 
    
    private Player _player;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        if (_player == null)
            throw new ConstraintException("has no player on scene");
    }

    private void OnEnable()
    {
        _player.CoinTook += SetCoinsCount;
    }

    private void OnDisable()
    {
        _player.CoinTook -= SetCoinsCount;
    }

    private void SetCoinsCount(int count)
    {
        _text.SetText($"Coins: {count}");
    }
}