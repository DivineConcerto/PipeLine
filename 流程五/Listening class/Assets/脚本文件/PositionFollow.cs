using UnityEngine;

public class PositionFollow : MonoBehaviour
{
    public Transform target;
    public Transform target1;
    public float followSpeed = 0.05f;
    public float rotateSpeed = 5f;  // 旋转速度
    public float distanceAboveTarget = 0.35f;
    private Vector3 offset = Vector3.zero;
    private Vector3 velocity = Vector3.zero;
    private Quaternion initialRotation;
    private bool isFollowing = true;

    private void Start()
    {
        offset = transform.position - target.position;
        initialRotation = transform.rotation;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isFollowing = !isFollowing;

            if (isFollowing)
            {
                // 返回跟随状态时，恢复初始旋转
                transform.rotation = initialRotation;
            }
        }
    }

    private void LateUpdate()
    {
        if (isFollowing)
        {
            Vector3 desiredPosition = target.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, followSpeed);
        }
        else
        {
            // 在不跟随状态下，将摄像机设置到目标物体上方一定距离，并朝向目标物体
            Vector3 desiredPosition = target1.position + Vector3.up * distanceAboveTarget;
            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, followSpeed);

            // 使用 slerp 让摄像机平滑过渡旋转
            Quaternion targetRotation = Quaternion.LookRotation(target1.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }
    }
}











