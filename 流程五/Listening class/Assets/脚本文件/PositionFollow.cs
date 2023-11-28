using UnityEngine;

public class PositionFollow : MonoBehaviour
{
    public Transform target;
    public Transform target1;
    public float followSpeed = 0.05f;
    public float rotateSpeed = 5f;  // ��ת�ٶ�
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
                // ���ظ���״̬ʱ���ָ���ʼ��ת
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
            // �ڲ�����״̬�£�����������õ�Ŀ�������Ϸ�һ�����룬������Ŀ������
            Vector3 desiredPosition = target1.position + Vector3.up * distanceAboveTarget;
            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, followSpeed);

            // ʹ�� slerp �������ƽ��������ת
            Quaternion targetRotation = Quaternion.LookRotation(target1.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }
    }
}











