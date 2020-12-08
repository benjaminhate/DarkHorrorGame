using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Controller")]
    public CharacterController controller;
    
    [Header("Speed")]
    public float speed = 10f;
    private Vector3 _velocity;
    
    [Header("Ground")]
    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;
    private bool _isGrounded;
    
    private void Update()
    {
        _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }
        
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");

        var move = transform.right * x + transform.forward * z;
        
        controller.Move(move * (speed * Time.deltaTime));

        _velocity.y += Physics.gravity.y * Time.deltaTime;
        controller.Move(_velocity * Time.deltaTime);
    }
}
