using UnityEngine;

public class PositionFollow : MonoBehaviour
{
    public Transform target;  // ��Ϊ������۾�
    public float followSpeed = 0.05f;

    private Vector3 offset;
    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, followSpeed);
    }
}







