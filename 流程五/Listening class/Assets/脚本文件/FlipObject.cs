using UnityEngine;

public class FlipObject : MonoBehaviour
{
    public bool isUpright = false; // 初始设为false，表示物体开始时是倒的
    public Vector3 uprightRotation = new Vector3(0, 0, 0); // 假设正立时的旋转角度为(0,0,0)

    void Update()
    {
        // 检测是否按下F键，并确保物体不是正立的
        if (Input.GetKeyDown(KeyCode.F) && !isUpright)
        {
            SetUpright();
        }
    }

    void SetUpright()
    {
        transform.eulerAngles = uprightRotation; // 设置物体的旋转角度为正立状态
        isUpright = true;
    }

    // 当物体与其他物体发生碰撞
    void OnCollisionEnter(Collision collision)
    {
        // 假设碰到名为"Cube"的物体时，物体是倒下的
        if (collision.gameObject.name == "Cube" && isUpright)
        {
            isUpright = false;
        }
    }
}
