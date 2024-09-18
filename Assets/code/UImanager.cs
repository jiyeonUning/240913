using UnityEngine.UI;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    // ������ ���¸� ��Ÿ���� ������
    public enum GameState { Ready, Runnig, GameOver }

    [SerializeField] GameState curState; // ������ �� ����
    [SerializeField] GameObject[] Prefab;  // ��ü ������ (�ٱ� �� ������ ������ ���� ������ �ν��ϱ� ���� ����)
    [SerializeField] GameObject GameOver; // ���� ���� ���� : �ٱ� �� ������ ������ ���� ������ �Ǵ� ����

    [Header("UI")]
    [SerializeField] Button readyButton;
    [SerializeField] Button gameOverButton;


}
