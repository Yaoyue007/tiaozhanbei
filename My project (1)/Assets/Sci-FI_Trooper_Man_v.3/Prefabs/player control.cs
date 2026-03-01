using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Animator anim;
    private CharacterController controller;

    public float moveSpeed = 3f;
    public float rotateSpeed = 10f;

    private float h, v;

    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // 读取输入（WASD）
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        // 计算速度并传给动画器（控制走路动画）
        Vector3 inputDir = new Vector3(h, 0, v).normalized;
        float speed = inputDir.magnitude;
        anim.SetFloat("Speed", speed);

        // ===== 按 E 触发捡东西 =====
        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetTrigger("PickUp");
        }
    }

    void FixedUpdate()
    {
        // 物理移动（WASD 移动角色的实际位置）
        Vector3 inputDir = new Vector3(h, 0, v).normalized;
        float speed = inputDir.magnitude;

        if (speed > 0.1f)
        {
            // 旋转
            Quaternion targetRotation = Quaternion.LookRotation(inputDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.fixedDeltaTime * rotateSpeed);

            // 移动
            Vector3 move = transform.forward * moveSpeed * Time.fixedDeltaTime;
            controller.Move(move);
        }
    }
}