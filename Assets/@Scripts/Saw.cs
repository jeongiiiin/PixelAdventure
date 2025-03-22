using UnityEditor.Experimental.GraphView;
using UnityEngine;

// �� ������

public class Saw : MonoBehaviour
{
    //public
    public float RightMax; // ������ �ִ�
    public float LeftMax; // ���� �ִ�

    // private
    float _currentPosX; // ���� X�� ��ġ
    [SerializeField] // private ���� �ν����Ϳ� ǥ��
    float _direction;

    private void Start()
    {
        _currentPosX = transform.position.x;
    }

    private void Update()
    {
        _currentPosX += Time.deltaTime * _direction;

        if (_currentPosX >= RightMax)
        {
            _direction *= -1; // ���� ��ȯ
            _currentPosX = RightMax;
        }
        else if (_currentPosX <= LeftMax)
        {
            _direction *= -1; // ���� ��ȯ
            _currentPosX = LeftMax;
        }

        transform.position = new Vector3(_currentPosX, transform.position.y, transform.position.z);
    }

    // <<< �� �������� ���... >>>

    //Vector3 currentPos; // ���� ��ġ
    //public float Delta = 0f; // ��/��� �̵������� X �������� �ִ�
    //public float Speed = 0f; // �̵� �ӵ�

    //void Start()
    //{
    //    currentPos = transform.position;
    //}

    //void Update()
    //{
    //    Vector3 movePos = currentPos;
    //    movePos.x += Delta * Mathf.Sin(Time.time * Speed);

    //    transform.position = movePos;
    //}
}
