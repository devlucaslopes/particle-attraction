using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float MoveSpeed;

    [Header("Elements")] 
    [SerializeField] private Animator PlayerAnimator;

    private CharacterController _characterController;
    
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }
    
    void Update()
    {
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        _characterController.Move(direction * MoveSpeed * Time.deltaTime);
        
        PlayerAnimator.SetInteger("Horizontal", (int) direction.x);
        PlayerAnimator.SetInteger("Forward", (int) direction.z);
    }
}
