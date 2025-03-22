using UnityEngine;

// 백그라운드 스크롤

public class BackGround : MonoBehaviour
{
    // public
    public MeshRenderer meshRenderer; // 머티리얼
    public float ScrollSpeed; // 배경 스크롤 속도

    void Update()
    {
        Vector2 newOffset = meshRenderer.material.mainTextureOffset; // 머티리얼 오프셋
        newOffset.y += ScrollSpeed * Time.deltaTime; // Y축 움직임

        meshRenderer.material.mainTextureOffset = newOffset;
    }
}
