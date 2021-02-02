using System.Data;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _additionCameraPositionOnY = 1;

    private Player _player;
    private const float _cameraPositionOnZ = -10;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        if (_player == null)
            throw new ConstraintException("has no player on scene");
    }

    private void Update()
    {
        var playerPosition = _player.transform.position;
        playerPosition.z = _cameraPositionOnZ;
        playerPosition.y += _additionCameraPositionOnY;
        transform.position = Vector3.Lerp(transform.position, playerPosition, _speed);
    }
}