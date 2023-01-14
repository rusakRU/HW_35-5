using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    internal class MenuButtonScripts : MonoBehaviour
    {
        private GameManager _sceneManage;
        private Button _button;

        private void Start()
        {
            _sceneManage = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<GameManager>();
            _button = this.GetComponent<Button>();
            _button.onClick.AddListener(TaskOnClick);
        }

        void TaskOnClick()
        {
            Debug.Log("You have clicked the button!");
            if (_button.tag == Tags.ReloadLevelTagName)
            {
                _sceneManage.ReloadLevel();
            }
            else if (_button.tag == Tags.BackButtonTagName)
            {
                _sceneManage.LoadMainMenu();
            }
            else
            {
                _sceneManage.LoadNextLevel();
            }
        }
    }
}
