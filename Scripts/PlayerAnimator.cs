using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMover))]
public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();       
    }
    private void OnEnable() 
    {
        _mover.SpeedChanged += OnSpeedChanged;
    }

    private void OnDisable() 
    {
        _mover.SpeedChanged -= OnSpeedChanged;
    }

    private void OnSpeedChanged(float speed)
    {
        _animator.SetFloat("Speed", speed);
    }
}
