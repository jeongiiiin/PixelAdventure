using UnityEngine;

public class EnemyHitBox_01 : MonoBehaviour
{
    public static EnemyHitBox_01 Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    int _hitCount01 = 0;

    public int HitCount01
    {
        get { return _hitCount01; }
        set { _hitCount01 = value; }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("PLAYER"))
        {
            _hitCount01++;

            Debug.Log(_hitCount01);
        }
    }
}
