using System;
using UnityEngine;

public class LookupHandler : MonoBehaviour
{
    public Transform player;           // 플레이어 Transform
    public float mouseSensitivity = 100f;  // 마우스 감도
    public float distance = 5f;           // 카메라와 플레이어 간 거리
    public float pitchMin = -45f;        // 상하 회전 최소각도
    public float pitchMax = 45f;         // 상하 회전 최대각도

    private float yaw = 0f;              // 카메라의 Y축 회전 (좌우)
    private float pitch = 0f;            // 카메라의 X축 회전 (상하)

    void Update()
    {
        HandleMouseLook();   // 마우스 입력에 따라 시점 변경
    }

    void LateUpdate()
    {
        HandleCameraPosition(); // 카메라의 위치 및 회전 처리
    }

    void HandleMouseLook()
    {
        // 마우스 X, Y 값에 따라 각도 업데이트
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yaw += mouseX;  // 카메라의 Y축 회전 (좌우)
        pitch -= mouseY; // 카메라의 X축 회전 (상하)

        // 상하 회전 각도 제한
        pitch = Mathf.Clamp(pitch, pitchMin, pitchMax);
    }

    void HandleCameraPosition()
    {
        // 카메라 회전 계산
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);  // 상하좌우 회전
        Vector3 direction = rotation * Vector3.back;  // 카메라는 뒤쪽을 바라보도록

        // 카메라 위치를 계산하고, 플레이어 위치를 바라보게 설정
        transform.position = player.position + direction * distance;

        // 항상 플레이어를 바라보도록
        transform.LookAt(player.position);
    }
}