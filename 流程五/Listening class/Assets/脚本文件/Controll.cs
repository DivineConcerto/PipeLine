using UnityEngine;

public class Controll : MonoBehaviour
{
    private Animator animator;
    private float moveSpeed = 0.5f;
    private const float walkSpeed = 0.5f;
    private const float runSpeed = 1f;
    private bool isRunning = false;
    private bool isMovingAllowed = true;
    private int spacePressCount = 0;

    private const float rotationSpeed = 3f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spacePressCount++;
            isMovingAllowed = spacePressCount % 2 == 0;
        }

        if (!isMovingAllowed) return;

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

            Quaternion targetRotation = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World);
        }
        else
        {
            animator.SetBool("isWalk", false);
            animator.SetBool("isRun", false);
        }
    }
}



