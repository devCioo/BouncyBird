using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [SerializeField] private float _velocity = 1.5f;
    [SerializeField] private float _rotationSpeed = 10f;

    private Rigidbody2D _rb;
    private Animator _anim;

    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        transform.position = new Vector3(transform.position.x, 0.3f, transform.position.z);
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rb.velocity = Vector2.up * _velocity;
            _anim.SetTrigger("flap");
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, _rb.velocity.y * _rotationSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            GameManager.instance.GameOver();
        }
        if (other.CompareTag("Scoring"))
        {
            GameManager.instance.IncreaseScore();
        }
    }
}
