using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpforce;
    [SerializeField] private float _groundCheckerRadius;
    [SerializeField] private Transform _groundCheckerPosition;
    [SerializeField] private LayerMask _groundMask;

    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private bool _isGrounded;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Movement();
        Jump();
        GroundCheck();
    }

    private void Movement()
    {
        var x = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.A))
            transform.rotation = Quaternion.Euler(0, 180, 0);

        if (Input.GetKeyDown(KeyCode.D))
            transform.rotation = Quaternion.Euler(0, 0, 0);

        _animator.SetFloat("Speed", Mathf.Abs(x));
        transform.position += Vector3.right * (x * _speed * Time.deltaTime);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rigidbody.AddForce(Vector2.up * _jumpforce, ForceMode2D.Impulse);
            _animator.SetTrigger("Jump");
        }
    }

    private void GroundCheck()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheckerPosition.position, _groundCheckerRadius, _groundMask);
    }
}