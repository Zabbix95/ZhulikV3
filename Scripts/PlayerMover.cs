using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CharacterController))]
public class PlayerMover : MonoBehaviour
{    
    private CharacterController _controller;  
    private float _currentSpeed;
    private float _speedWalk = 2.0f;
    private float _speedRun = 4.0f;    
    private float _playerRotationSpeed = 150f;

    public UnityAction<float> SpeedChanged;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();        
    }

    private void Update()
    {
        float _currentSpeed = Input.GetKey(KeyCode.LeftShift) ? _speedRun : _speedWalk;
        float upDownVector = Input.GetAxis("Horizontal");
        float leftRightVector = Input.GetAxis("Vertical");        

        if (leftRightVector != 0)
        {   
            SpeedChanged?.Invoke(leftRightVector * _currentSpeed);            
            _controller.Move(transform.forward * leftRightVector * _currentSpeed * Time.deltaTime);
        }   
        if (upDownVector != 0)        
            transform.Rotate(transform.up * upDownVector * _playerRotationSpeed * Time.deltaTime);        
    }
}