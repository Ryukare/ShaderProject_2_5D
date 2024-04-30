using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private float speed;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody _rigidbody;
    private Animator _animator;
    
    private float _xInput;
    private float _zInput;
    
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }
    
    private void Update()
    {
        _xInput = Input.GetAxis("Horizontal");
        _zInput = Input.GetAxis("Vertical");
        if (_xInput != 0 || _zInput != 0)
        {
            _animator.SetBool("Run",true);
        }
        else
        {
            _animator.SetBool("Run",false);
        }
    }
    
    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_xInput, 0, _zInput).normalized * speed;
        FlipX();
    }

    private void FlipX()
    {
        if (_xInput > 0)
        {
            _spriteRenderer.flipX = false;
;        }
        else if (_xInput < 0)
        {
            _spriteRenderer.flipX = true;
        }
    }
}
