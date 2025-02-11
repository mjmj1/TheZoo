using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform cameraTransform; // 카메라 오브젝트
    public float cameraDistance = 5f; // 카메라와 캐릭터 간 거리
    public Vector3 cameraOffset = new Vector3(0, 2, -5); // 초기 카메라 위치 오프셋

    public Transform sphereCenter; // 구의 중심
    public float moveSpeed = 5f; // 이동 속도
    public float rotationSpeed = 10f; // 회전 속도
    public float mouseSensitivity = 3f; // 마우스 감도
    public float pitchMax = 20f;
    public float pitchMin = -5f;
    
    private float _pitch = 0f; // 상하 회전 각도
    

    void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        var mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        var mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
    
        _pitch -= mouseY;
        _pitch = Mathf.Clamp(_pitch, pitchMin, pitchMax);

        var moveDirection = transform.forward * vertical + transform.right * horizontal;
        moveDirection = moveDirection.normalized;

        transform.position += moveDirection * (moveSpeed * Time.deltaTime);
        
        var directionToCenter = (transform.position - sphereCenter.position).normalized;
        
        transform.Rotate(0, mouseX, 0);
        transform.up = directionToCenter;
        
        var targetRotation = Quaternion.FromToRotation(transform.up, directionToCenter) * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        
        UpdateCameraPosition();
    }

    private void UpdateCameraPosition()
    {
        cameraTransform.position = transform.TransformPoint(cameraOffset);;

        // 카메라가 항상 캐릭터를 바라보도록 설정
        var directionToPlayer = transform.position - cameraTransform.position;
        var upDirection = (cameraTransform.position - sphereCenter.position).normalized;

        // 피치 회전 적용
        var rotation = Quaternion.LookRotation(directionToPlayer, upDirection);
        rotation *= Quaternion.Euler(_pitch, 0, 0); // 상하 회전 추가

        cameraTransform.rotation = rotation;
    }
}
