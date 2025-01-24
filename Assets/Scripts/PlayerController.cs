using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform cameraTransform; // 카메라 오브젝트
    public float cameraDistance = 5f;   // 카메라와 캐릭터 간 거리
    public Vector3 cameraOffset = new Vector3(0, 2, -5); // 초기 카메라 위치 오프셋

    public Transform sphereCenter; // 구의 중심
    public float moveSpeed = 5f;   // 이동 속도
    public float rotationSpeed = 10f; // 회전 속도
    public float mouseSensitivity = 3f; // 마우스 감도
    
    void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        var mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        
        // 2. 이동 방향 계산
        var moveDirection = transform.forward * vertical + transform.right * horizontal;
        moveDirection = moveDirection.normalized;

        // 3. 캐릭터 이동
        transform.position += moveDirection * (moveSpeed * Time.deltaTime);

        transform.Rotate(0, mouseX, 0);

        /*// 4. 구 표면에서 위치 고정
        var directionToCenter = (transform.position - sphereCenter.position).normalized;
        transform.position = sphereCenter.position + directionToCenter * Vector3.Distance(transform.position, sphereCenter.position);
        
        // 5. 캐릭터의 로컬 Up 벡터를 구 표면과 수직으로 정렬
        var targetRotation = Quaternion.FromToRotation(transform.up, directionToCenter) * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        */
        
        var directionToCenter = (transform.position - sphereCenter.position).normalized;
        var targetRotation = Quaternion.FromToRotation(transform.up, directionToCenter) * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        
        UpdateCameraPosition();
    }
    
    private void UpdateCameraPosition()
    {
        // 캐릭터의 로컬 좌표계에서 카메라 위치 계산
        var desiredPosition = transform.TransformPoint(cameraOffset);

        // 카메라 위치를 고정된 위치로 업데이트
        cameraTransform.position = desiredPosition;

        // 카메라가 항상 캐릭터를 바라보도록 설정
        var upDirection = (cameraTransform.position - sphereCenter.position).normalized; // 구 표면 방향
        cameraTransform.LookAt(transform.position, upDirection);
    }
}
