using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace SH.Model {
    public abstract class State<T> : IState where T : MonoBehaviour
    {

        protected T owner;

        public State(T owner) {
            this.owner = owner;
        }

        public abstract void Initialize();
        
        public abstract void Execute();
        
        public abstract void LateExecute();

        public abstract void Exit();
    }

}