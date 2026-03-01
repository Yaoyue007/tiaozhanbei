using UnityEngine;

public class WalkWithRootMotion : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // 获取键盘输入（WASD 或 上下左右键）
        float h = Input.GetAxis("Horizontal"); // A/D 或 左右箭头
        float v = Input.GetAxis("Vertical");   // W/S 或 上下箭头

        // 计算移动方向的大小（0~1）
        float speed = new Vector3(h, 0, v).magnitude;

        // 把速度值传给动画器的 Speed 参数
        anim.SetFloat("Speed", speed);
    }
}