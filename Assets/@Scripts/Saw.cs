using UnityEditor.Experimental.GraphView;
using UnityEngine;

// 톱 움직임

public class Saw : MonoBehaviour
{
    //public
    public float RightMax; // 오른쪽 최댓값
    public float LeftMax; // 왼쪽 최댓값

    // private
    float _currentPosX; // 현재 X값 위치
    [SerializeField] // private 변수 인스펙터에 표시
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
            _direction *= -1; // 방향 전환
            _currentPosX = RightMax;
        }
        else if (_currentPosX <= LeftMax)
        {
            _direction *= -1; // 방향 전환
            _currentPosX = LeftMax;
        }

        transform.position = new Vector3(_currentPosX, transform.position.y, transform.position.z);
    }

    // <<< 더 간지나는 방법... >>>

    //Vector3 currentPos; // 현재 위치
    //public float Delta = 0f; // 좌/우로 이동가능한 X 포지션의 최댓값
    //public float Speed = 0f; // 이동 속도

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
