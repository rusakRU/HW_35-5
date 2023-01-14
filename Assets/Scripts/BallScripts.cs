using UnityEngine;

namespace Assets.Scripts
{
    internal class BallScripts : MonoBehaviour
    {
        private GameManager _sceneManage;

        private void Start()
        {
            _sceneManage = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<GameManager>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Finish"))
            {
                _sceneManage.LoadWinMenu();
            }
        }
    }
}
