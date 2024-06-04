using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SH.Model {
    public interface IState
    {
        void Initialize();

        void Execute();

        void LateExecute();

        void Exit();

    }
}
