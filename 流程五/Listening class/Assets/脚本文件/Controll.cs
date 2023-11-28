using UnityEngine;
using System.Collections;

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
    private bool isTurning = false;
    private Quaternion targetRotation;

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

        if (!isMovingAllowed)
        {
            // 如果不能移动，重置动画状态
            ResetAnimationStates();
            return;
        }

        // 按下"A"键或者"←"键时向左转身
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            TurnCharacter(-90);
        }
        // 按下"D"键或者"→"键时向右转身
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            TurnCharacter(90);
        }
        // 按下"S"键或者"↓"键时向后转身
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            TurnCharacter(180);
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 inputDir = new Vector3(horizontal, 0, vertical).normalized;

        if (Input.GetKeyDown(KeyCode.C))
        {
            isRunning = !isRunning;
        }

        if (inputDir != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(inputDir, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        bool isMovingForward = Vector3.Dot(transform.forward, inputDir) > 0.4f;

        SetAnimationStates(isMovingForward);
        MoveCharacter(inputDir);
    }

    void SetAnimationStates(bool isMovingForward)
    {
        if (isMovingForward)
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
        }
        else
        {
            ResetAnimationStates();
        }
    }

    void ResetAnimationStates()
    {
        animator.SetBool("isWalk", false);
        animator.SetBool("isRun", false);
    }

    void MoveCharacter(Vector3 direction)
    {
        transform.Translate(direction * (isRunning ? runSpeed : walkSpeed) * Time.deltaTime, Space.Self);
    }

    void TurnCharacter(float angle)
    {
        if (!isTurning)
        {
            Quaternion targetRotation = transform.rotation * Quaternion.Euler(0, angle, 0);
            StartCoroutine(TurnSmoothly(targetRotation));
        }
    }

    IEnumerator TurnSmoothly(Quaternion targetRotation)
    {
        isTurning = true;
        Quaternion startRotation = transform.rotation;
        float elapsedTime = 0f;
        float turnDuration = 0.5f; // 转身持续时间

        while (elapsedTime < turnDuration)
        {
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, elapsedTime / turnDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.rotation = targetRotation;
        isTurning = false;
    }

}










