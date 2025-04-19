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
        // 移動角色
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

        // ✅ 自動轉向移動方向
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }

        // 控制動畫
        if (animator != null)
        {
            animator.SetBool("isWalking", moveDirection != Vector3.zero);
        }
    }

    // UI 按鈕控制方法
    public void MoveForward() => moveDirection = Vector3.forward;
    public void MoveBackward() => moveDirection = Vector3.back;
    public void MoveLeft() => moveDirection = Vector3.left;
    public void MoveRight() => moveDirection = Vector3.right;
    public void Stop() => moveDirection = Vector3.zero;
}
