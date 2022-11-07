using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string ANIM_RUNNING = "running";
    private bool _isInJump;
    private float _dirX = 0f;

    private Rigidbody2D _rb;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _boxCollider;

    [SerializeField] private LayerMask _jumpableGround;

    [SerializeField] float moveSpeed = 7f;
    [SerializeField] float jumpSpeed = 10f;

    private enum MovemementState
    {
        idle,
        running,
        jumping,
        falling
    }

    // Start is called before the first frame update
    private void Start()
    {
        Init();
    }

    // Update is called once per frame
    private void Update()
    {
        _dirX = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2(_dirX * moveSpeed, _rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded() /*!_isInJump*/)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, jumpSpeed);
            //_isInJump = true;
        }

        UpdateAnimationsState();
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    _isInJump = false;
    //}

    private void UpdateAnimationsState()
    {
        MovemementState movementState;

        if (_dirX > 0f)
        {
            // _animator.SetBool(ANIM_RUNNING, true);
            movementState = MovemementState.running;
            _spriteRenderer.flipX = false;
        }
        else if (_dirX < 0f)
        {
            // _animator.SetBool(ANIM_RUNNING, true);
            movementState = MovemementState.running;

            _spriteRenderer.flipX = true;
        }
        else
        {
            movementState = MovemementState.idle;
            // _animator.SetBool(ANIM_RUNNING, false);
        }

        // if (_isInJump)
        // {
        //     movementState = MovemementState.jumping;
        // }
        if (_rb.velocity.y > .1f)
        {
            movementState = MovemementState.jumping;
        }
        else if (_rb.velocity.y < -.1f)
        {
            movementState = MovemementState.falling;
        }

        _animator.SetInteger("movementState", (int)movementState);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(_boxCollider.bounds.center, _boxCollider.bounds.size, 0f, Vector2.down, .1f, _jumpableGround);
    }

    private void Init()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _isInJump = false;
    }
}
