using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    public float BulletPower;

    private void Start()
    {
        rigid.AddForce(Vector2.right * BulletPower, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 총알이 서로 부딫혓을 때, 합쳐진다
    }
}
