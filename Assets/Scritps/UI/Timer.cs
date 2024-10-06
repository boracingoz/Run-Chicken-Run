using UnityEngine;
using TMPro;

namespace UI
{
    public class Timer : MonoBehaviour
    {
        private TMP_Text _text;
        private float _curTime;

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
        }

        private void Update()
        {
            _curTime += Time.deltaTime;
            _text.text = ((int)_curTime).ToString();
        }
    }
}