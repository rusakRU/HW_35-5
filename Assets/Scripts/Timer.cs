using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text _timerText;
    public float timeLeft = 2f;
    private GameManager _sceneManage;

    private void Start()
    {
        _sceneManage = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<GameManager>();
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        _timerText.text = Mathf.Round(timeLeft).ToString();

        if (timeLeft <= 0)
        {
            Time.timeScale = 0f;
            Lose();
            timeLeft = 10000f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    private void Lose()
    {
        _sceneManage.LoadLoseMenu();
    }
}
