using UnityEngine.UI;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    // 게임의 상태를 나타내는 열거형
    public enum GameState { Ready, Runnig, GameOver }

    [SerializeField] GameState curState; // 게임의 현 상태
    [SerializeField] GameObject[] Prefab;  // 구체 프리팹 (바깥 원 밖으로 나가면 게임 오버로 인식하기 위해 만듦)
    [SerializeField] GameObject GameOver; // 게임 오버 조건 : 바깥 원 밖으로 나가면 게임 오버가 되는 형식

    [Header("UI")]
    [SerializeField] Button readyButton;
    [SerializeField] Button gameOverButton;


}
