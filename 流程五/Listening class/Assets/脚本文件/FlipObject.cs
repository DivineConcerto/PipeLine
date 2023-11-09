using UnityEngine;

public class FlipObject : MonoBehaviour
{
    public bool isUpright = false; // ��ʼ��Ϊfalse����ʾ���忪ʼʱ�ǵ���
    public Vector3 uprightRotation = new Vector3(0, 0, 0); // ��������ʱ����ת�Ƕ�Ϊ(0,0,0)

    void Update()
    {
        // ����Ƿ���F������ȷ�����岻��������
        if (Input.GetKeyDown(KeyCode.F) && !isUpright)
        {
            SetUpright();
        }
    }

    void SetUpright()
    {
        transform.eulerAngles = uprightRotation; // �����������ת�Ƕ�Ϊ����״̬
        isUpright = true;
    }

    // ���������������巢����ײ
    void OnCollisionEnter(Collision collision)
    {
        // ����������Ϊ"Cube"������ʱ�������ǵ��µ�
        if (collision.gameObject.name == "Cube" && isUpright)
        {
            isUpright = false;
        }
    }
}
