
using UnityEngine;

public class CharacterMovementController : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Vector3 moveDirection = Vector3.zero;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 移動角色（世界座標）
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

        // 限制移動範圍：X[-5,5] Z[-5,5] Y固定-2
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -5f, 5f);
        pos.z = Mathf.Clamp(pos.z, -5f, 5f);
        pos.y = -2f;
        transform.position = pos;

        // 轉向
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }

        // 動畫控制
        if (animator != null)
        {
            animator.SetBool("isWalking", moveDirection != Vector3.zero);
        }
    }

    // UI 控制方法
    public void MoveForward() => moveDirection = Vector3.forward;
    public void MoveBackward() => moveDirection = Vector3.back;
    public void MoveLeft() => moveDirection = Vector3.left;
    public void MoveRight() => moveDirection = Vector3.right;
    public void Stop() => moveDirection = Vector3.zero;
}
