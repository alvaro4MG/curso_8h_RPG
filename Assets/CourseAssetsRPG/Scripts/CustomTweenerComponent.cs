using System;
using UnityEngine;
using UnityEngine.Events;

namespace JackSParrot.UI.DOTween
{
    public class CustomTweenerComponent : MonoBehaviour
    {
        [SerializeField]
        UITweenData _data = null;
        [SerializeField]
        bool _showOnEnable = true;
        [SerializeField]
        UnityEvent _onComplete = new UnityEvent();
        CustomTweener _tweener = new CustomTweener();

        void OnEnable()
        {
            if (_data.Target == null)
                _data.Target = gameObject;

            if (_showOnEnable)
            {
                _tweener.Play(_data, () => _onComplete?.Invoke());
            }
        }

        void OnDisable()
        {
            Stop();
        }

        public void Stop()
        {
            _tweener.Stop();
        }

        public void Play(Action callback)
        {
            if (_data.Target == null)
                _data.Target = gameObject;

            _tweener.Play(_data, () =>
            {
                _onComplete?.Invoke();
                callback?.Invoke();
            });
        }
    }
}