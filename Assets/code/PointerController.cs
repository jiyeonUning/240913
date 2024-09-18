using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PointerController : MonoBehaviour
{
    [SerializeField] BulletController bulletController;

    [SerializeField] float angle;    // 각도
    [SerializeField] Vector2 Pointer;  // 화살표의 각도
    [SerializeField] Vector2 mouse;    // 마우스의 각도

    public float rotationZ = 0f;

    private void Start()
    {
        Pointer = transform.position;
    }

    private void Update()
    {
        Rotate();

        // 우클릭 시, 조준 모드 실행 (레이캐스트로 점선)
        if (Input.GetMouseButton(1))
        {
            bulletController.TargetModeOn();
        }
        // 우클릭 해제 시, 행성 발사 (지구)
        if (Input.GetMouseButtonUp(1)) { bulletController.Fire(); }
    }

    void Rotate()
    {
        // Gnaseel님 티스토리 참고 : https://gnaseel.tistory.com/17

        // 마우스의 각도 = 화면상에서의 마우스 위치를 파악 후, 해당 정보를 좌표값으로 변환한 값
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // MathflAtan2 = 탄젠트 값으로 y/x 를 가지는 radian을 반환해주는 함수.
        // 원리 :
        // 마우스의 벡터값과 포인터의 벡터값을 뺀 벡터값 = 포인터 -> 마우스 방향의 벡터값
        // 해당 벡터값의 x, y값을 이용해 해당하는 탄젠트 값을 가진 각도를 찾아, angle에 해당값을 반환하였다.
        // + Mathf.Rad2Deg : 180 / π 를 뜻함. 해당 상수를 곱함으로써 우리가 아는 일반적인 각도를 구할 수 있다.
        angle = Mathf.Atan2(mouse.y - Pointer.y, mouse.x = Pointer.x) * Mathf.Rad2Deg;

        // AngleAxis : 두 번째 인자값을 기준축으로 두어, 첫 번째 인자만큼 회전한 값을 반환하는 함수.
        // 두 번째 인자값 = Vector3.forward는 (0, 0, 1) 값을 반환하기 때문에, 해당 키워드를 통해서 z축을 기준으로만 하여 회전시켜줄 수 있다.
        // 첫 번째 인자값 angle에서 90을 뺄셈하는 이유 = angle은 x축을 기준으로 각도값을 반환하기 때문에,
        //                                               z축을 기준으로 우측에서만 회전시키려면, angle의 값을 -로 만들어 반전시키고 -180을 해주어 x축의 값을 미리 중간값인 0으로 맞추어줄 필요성이 있기 때문
        transform.rotation = Quaternion.AngleAxis(-angle - 180, Vector3.forward);
    }
}
