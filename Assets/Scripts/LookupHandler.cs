using System;
using UnityEngine;

public class LookupHandler : MonoBehaviour
{
    public Transform player;           // 플레이어 Transform
    public float mouseSensitivity = 100f;  // 마우스 감도
    public float distance = 5f;           // 카메라와 플레이어 간 거리
    public float pitchMin = 0f;        // 상하 회전 최소각도
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
        var mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        var mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yaw += mouseX;
        pitch -= mouseY;

        pitch = Mathf.Clamp(pitch, pitchMin, pitchMax);
    }

    void HandleCameraPosition()
    {
        var rotation = Quaternion.Euler(pitch, yaw, 0);
        var direction = rotation * Vector3.back;

        transform.position = player.position + direction * distance;

        transform.LookAt(player.position);
    }
}