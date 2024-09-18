using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PointerController : MonoBehaviour
{
    [SerializeField] BulletController bulletController;

    [SerializeField] float angle;    // ����
    [SerializeField] Vector2 Pointer;  // ȭ��ǥ�� ����
    [SerializeField] Vector2 mouse;    // ���콺�� ����

    public float rotationZ = 0f;

    private void Start()
    {
        Pointer = transform.position;
    }

    private void Update()
    {
        Rotate();

        // ��Ŭ�� ��, ���� ��� ���� (����ĳ��Ʈ�� ����)
        if (Input.GetMouseButton(1))
        {
            bulletController.TargetModeOn();
        }
        // ��Ŭ�� ���� ��, �༺ �߻� (����)
        if (Input.GetMouseButtonUp(1)) { bulletController.Fire(); }
    }

    void Rotate()
    {
        // Gnaseel�� Ƽ���丮 ���� : https://gnaseel.tistory.com/17

        // ���콺�� ���� = ȭ��󿡼��� ���콺 ��ġ�� �ľ� ��, �ش� ������ ��ǥ������ ��ȯ�� ��
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // MathflAtan2 = ź��Ʈ ������ y/x �� ������ radian�� ��ȯ���ִ� �Լ�.
        // ���� :
        // ���콺�� ���Ͱ��� �������� ���Ͱ��� �� ���Ͱ� = ������ -> ���콺 ������ ���Ͱ�
        // �ش� ���Ͱ��� x, y���� �̿��� �ش��ϴ� ź��Ʈ ���� ���� ������ ã��, angle�� �ش簪�� ��ȯ�Ͽ���.
        // + Mathf.Rad2Deg : 180 / �� �� ����. �ش� ����� �������ν� �츮�� �ƴ� �Ϲ����� ������ ���� �� �ִ�.
        angle = Mathf.Atan2(mouse.y - Pointer.y, mouse.x = Pointer.x) * Mathf.Rad2Deg;

        // AngleAxis : �� ��° ���ڰ��� ���������� �ξ�, ù ��° ���ڸ�ŭ ȸ���� ���� ��ȯ�ϴ� �Լ�.
        // �� ��° ���ڰ� = Vector3.forward�� (0, 0, 1) ���� ��ȯ�ϱ� ������, �ش� Ű���带 ���ؼ� z���� �������θ� �Ͽ� ȸ�������� �� �ִ�.
        // ù ��° ���ڰ� angle���� 90�� �����ϴ� ���� = angle�� x���� �������� �������� ��ȯ�ϱ� ������,
        //                                               z���� �������� ���������� ȸ����Ű����, angle�� ���� -�� ����� ������Ű�� -180�� ���־� x���� ���� �̸� �߰����� 0���� ���߾��� �ʿ伺�� �ֱ� ����
        transform.rotation = Quaternion.AngleAxis(-angle - 180, Vector3.forward);
    }
}
