using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float speed = 5f;

    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    PlayerController controller;
    [SerializeField] Camera cam;

    [Header("Input References")]
    [SerializeField] private Vector2 moveInput;
    [SerializeField] private Vector2 mousePos;

    void Awake()
    {
        controller = new PlayerController();
        Movement();
    }

    void OnEnable()
    {
        controller.Player.Enable();
    }

    private void OnDisable()
    {
        controller.Player.Disable();
    }

    void Movement()
    {
        controller.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controller.Player.Move.canceled += ctx => moveInput = Vector2.zero;
    }

    private void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        HandleMovement();
        MouseLook();
    }

    void HandleMovement()
    {
        Vector2 move = rb.position + moveInput * speed * Time.deltaTime;
        rb.MovePosition(move);
    }

    void MouseLook()
    {
        Vector2 direction = mousePos - rb.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}