using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

public class PlayerControllerForward : MonoBehaviour
{
    private InputAction moveAction;
    private CinemachineCamera followPlayer;
    private Rigidbody rb;
    private float moveSpeed = 5f;
    private Animator anim;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        followPlayer = GetComponentInChildren<CinemachineCamera>();
        followPlayer.enabled = true;
        followPlayer.Prioritize();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 moveInput = moveAction.ReadValue<Vector2>();

        if (moveInput.x > 0)
        {
            transform.Translate(0, 0, moveInput.x * Time.deltaTime * moveSpeed);
            anim.SetFloat("WalkSpeed", moveInput.x);
        }
        
        anim.SetBool("IsWalking", moveInput.x > 0);
    }
}
