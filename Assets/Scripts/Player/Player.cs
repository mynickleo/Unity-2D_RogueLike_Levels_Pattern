using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))] //necessary need boxCollider
public class Player : MonoBehaviour
{
    //Available for Inspector -->
    [SerializeField] private BoxCollider2D _boxCollider;
    [SerializeField] private Animator _animatorPlayer;
    //<--

    private Vector3 _moveDelta;
    private RaycastHit2D _hit;
    private float _moveSpeed = 3f;

    private void Start()
    {
        if(_boxCollider == null)
            _boxCollider = GetComponent<BoxCollider2D>();

        if (_animatorPlayer == null)
            _animatorPlayer = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        movePlayer();
    }

    private void movePlayer()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        //Reset moveDelta
        _moveDelta = new Vector3(x, y, 0);

        //Change Sprite and Animation
        if (_moveDelta.x > 0)
        {
            transform.localScale = Vector3.one;
            _animatorPlayer.SetInteger("animationType", 1);
        }
        else if (_moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            _animatorPlayer.SetInteger("animationType", 1);
        }
        else if (_moveDelta.y > 0)
            _animatorPlayer.SetInteger("animationType", 2);
        else if (_moveDelta.y < 0)
            _animatorPlayer.SetInteger("animationType", 3);

        if (_moveDelta.x == 0 && _moveDelta.y == 0)
            _animatorPlayer.SetInteger("animationType", 0);


        //Make sure that we can move in this direction with Raycast hit
        _hit = Physics2D.BoxCast(transform.position, _boxCollider.size, 0, new Vector2(_moveDelta.x, 0), Mathf.Abs(_moveDelta.x * Time.deltaTime * _moveSpeed), LayerMask.GetMask("Actor", "Blocking"));
        if (_hit.collider == null)
        {
            transform.Translate(_moveDelta.x * Time.deltaTime * _moveSpeed, 0, 0);
        }

        _hit = Physics2D.BoxCast(transform.position, _boxCollider.size, 0, new Vector2(0, _moveDelta.y), Mathf.Abs(_moveDelta.y * Time.deltaTime * _moveSpeed), LayerMask.GetMask("Actor", "Blocking"));
        if(_hit.collider == null)
        {
            transform.Translate(0, _moveDelta.y * Time.deltaTime * _moveSpeed, 0);
        }

    }
}
