using UnityEngine;

public class CameraFollow : MonoBehaviour
{
<<<<<<< Updated upstream
    public Transform target; // 目标物体，相机将跟随的对象
    public float smoothSpeed = 0.125f; // 相机跟随的平滑速度
    public Vector3 offset; // 相机与目标物体之间的偏移量

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset; // 计算相机期望的位置
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // 使用线性插值平滑移动相机
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, offset.z); // 更新相机位置，锁定Z轴

        // 可选：如果你想让相机始终指向目标，取消下面一行的注释
        // transform.LookAt(target);
=======
    public Transform target; // 玩家角色的Transform组件
    public float smoothSpeed = 5f; // 调整此值来控制摄像机跟随速度
    public Vector3 offset;

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
>>>>>>> Stashed changes
    }
}
