using UnityEngine;

public class GlobalsInit : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameOverMessage;

    public static GameObject gameOverMessage;

    // Use this for initialization
    private void Start()
    {
        gameOverMessage = _gameOverMessage;
    }
}