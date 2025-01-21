using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;   // 캐릭터 이동 속도
    public float rotationSpeed = 10f; // 회전 속도
    public Transform sphereCenter; // 구의 중심 (구체의 Transform)

    void Update()
    {
        // 캐릭터 이동
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");

        var moveDirection = new Vector3(horizontal, 0, vertical).normalized;
        if (moveDirection.magnitude >= 0.1f)
        {
            // 이동 방향 계산
            var worldDirection = transform.TransformDirection(moveDirection);
            transform.position += worldDirection * (moveSpeed * Time.deltaTime);

            // 구 표면 정렬
            AlignToSurface();
        }
    }

    void AlignToSurface()
    {
        // 구 중심 방향 계산
        var surfaceNormal = (transform.position - sphereCenter.position).normalized;

        // 캐릭터가 표면을 따라 정렬되도록 회전
        var toSurfaceRotation = Quaternion.FromToRotation(transform.up, surfaceNormal) * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, toSurfaceRotation, rotationSpeed * Time.deltaTime);
    }
}
