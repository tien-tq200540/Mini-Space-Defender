using UnityEngine;

public class PlayerMovement : TienMonoBehaviour
{
    private PlayerActions inputActions;
    [SerializeField] private float speed = 5f;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Vector2 direction;

    protected override void LoadComponents()
    {
        inputActions = new PlayerActions();
        LoadRigidbody2D();   
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void Update()
    {
        direction = Vector2.zero;

        if (inputActions.Move.MoveUp.IsPressed()) direction.y = 1f;
        else if (inputActions.Move.MoveDown.IsPressed()) direction.y = -1f;

        if (inputActions.Move.MoveLeft.IsPressed()) direction.x = -1f;
        else if (inputActions.Move.MoveRight.IsPressed()) direction.x = 1f;

        _rigidbody2D.velocity = direction * speed;
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void LoadRigidbody2D()
    {
        if (_rigidbody2D != null) return;
        _rigidbody2D = GetComponentInParent<Rigidbody2D>();
        _rigidbody2D.gravityScale = 0f;
    }
}
