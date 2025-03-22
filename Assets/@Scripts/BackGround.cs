using UnityEngine;

// ��׶��� ��ũ��

public class BackGround : MonoBehaviour
{
    // public
    public MeshRenderer meshRenderer; // ��Ƽ����
    public float ScrollSpeed; // ��� ��ũ�� �ӵ�

    void Update()
    {
        Vector2 newOffset = meshRenderer.material.mainTextureOffset; // ��Ƽ���� ������
        newOffset.y += ScrollSpeed * Time.deltaTime; // Y�� ������

        meshRenderer.material.mainTextureOffset = newOffset;
    }
}
