using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform cameraTransform; // 카메라 오브젝트
    public Transform sphereCenter;    // 구의 중심
    public float mouseSensitivity = 3f; // 마우스 감도
    public float rotationSpeed = 10f;   // 수직 정렬 속도
    public float cameraDistance = 5f;   // 카메라와 캐릭터 간 거리
    public Vector3 cameraOffset = new Vector3(0, 2, -5); // 초기 카메라 위치 오프셋

    private void Update()
    {
        // 1. 마우스 입력 받기
        var mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;

        // 4. 카메라 위치 및 방향 업데이트
        
    }

    
}
