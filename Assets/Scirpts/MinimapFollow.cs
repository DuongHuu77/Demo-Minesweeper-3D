using UnityEngine;

public class MinimapFollow : MonoBehaviour
{
    [Header("Mục tiêu theo dõi")]
    public Transform PlayerTarget;

    [Header("Độ cao của Camera")]
    public float CameraHeight = 30f; // Độ cao bay trên đầu nhân vật

    void LateUpdate()
    {
        if (PlayerTarget != null)
        {
            // Đi theo vị trí X và Z của nhân vật, nhưng giữ nguyên độ cao Y
            Vector3 newPosition = PlayerTarget.position;
            newPosition.y = CameraHeight;
            transform.position = newPosition;

            // Luôn khóa cứng góc nhìn cắm thẳng xuống đất (90 độ trục X)
            // Không bị xoay mòng mòng khi nhân vật quay đầu
            transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        }
    }
}