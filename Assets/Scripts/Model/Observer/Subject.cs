using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SH.Model {
    public class Subject : MonoBehaviour
    {
        [SerializeField] private List<IObserver> observers = new List<IObserver>();

        public void NotifyObservers() {
            foreach (IObserver observer in observers) {
                observer.OnNotify();
            }
        }
    }
}
