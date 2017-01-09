using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace View.ComponentTypes
{
    public abstract class ViewType<T> : MonoBehaviour where T : Component
    {
        public T[] Elements { get; private set; }

        private void Awake()
        {
            Elements = GetComponentsInChildren<T>();
        }

        public void DoEach(UnityAction<T> doAction)
        {
            foreach (var t in Elements)
            {
                doAction.Invoke(t);
            }
        }

        public void DoEach(UnityAction<T, int> doAction)
        {
            for (var i = 0; i < Elements.Length; i++)
            {
                doAction.Invoke(Elements[i], i);
            }
        }

        public void UpdateView(int collectionSize)
        {
            for (var i = 0; i < Elements.Length; i++)
            {
                var isOn = i < collectionSize;
                Elements[i].gameObject.SetActive(isOn);
            }
        }

        public void UpdateView(int collectionSize, UnityAction<T> updateAction)
        {
            for (var i = 0; i < Elements.Length; i++)
            {
                var isOn = i < collectionSize;
                var element = Elements[i];
                Elements[i].gameObject.SetActive(isOn);
                if(isOn)
                    updateAction.Invoke(element);
            }
        }

        public void UpdateView(int collectionSize, UnityAction<T, int> updateAction)
        {
            for (var i = 0; i < Elements.Length; i++)
            {
                var isOn = i < collectionSize;
                var element = Elements[i];
                Elements[i].gameObject.SetActive(isOn);
                if(isOn)
                    updateAction.Invoke(element, i);
            }
        }
    }
}