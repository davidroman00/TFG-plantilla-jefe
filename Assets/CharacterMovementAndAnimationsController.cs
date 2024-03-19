using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementAndAnimationsController : MonoBehaviour
{
    [SerializeField]
    float Speed = 10f;
    float _turnSmoothTime = .1f;
    float _turnSmoothVelocity;
    [SerializeField]
    Transform Camera;
    CharacterController _characterController;

    void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3 (horizontal, 0f, vertical).normalized;

        if (direction.magnitude > .1f){

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            _characterController.Move(moveDirection.normalized * Speed * Time.deltaTime);
        }
    }
}
