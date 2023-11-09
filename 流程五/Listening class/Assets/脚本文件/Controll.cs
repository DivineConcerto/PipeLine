using UnityEngine;

public class Controll : MonoBehaviour
{
    private Animator animator;
    private float moveSpeed = 0.5f;
    private const float walkSpeed = 0.5f;
    private const float runSpeed = 1f;
    private bool isRunning = false;

    private const float rotationSpeed = 3f; // 控制旋转的速度

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(horizontal, 0, vertical);

        if (Input.GetKeyDown(KeyCode.C))
        {
            isRunning = !isRunning;
        }

        if (dir.magnitude > 0f)
        {
            animator.SetBool("isWalk", true);

            if (isRunning)
            {
                moveSpeed = runSpeed;
                animator.SetBool("isRun", true);
            }
            else
            {
                moveSpeed = walkSpeed;
                animator.SetBool("isRun", false);
            }

            // 平滑旋转代码
            Quaternion targetRotation = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("isWalk", false);
            animator.SetBool("isRun", false);
        }
    }
}


