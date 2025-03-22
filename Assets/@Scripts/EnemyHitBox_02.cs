using UnityEngine;

public class EnemyHitBox_02 : MonoBehaviour
{
    public static EnemyHitBox_02 Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    int _hitCount02 = 0;

    public int HitCount02
    {
        get { return _hitCount02; }
        set { _hitCount02 = value; }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("PLAYER"))
        {
            _hitCount02++;

            Debug.Log(_hitCount02);
        }
    }
}
