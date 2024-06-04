using SH.BusinessLogic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SH.Model {
    public class PlayerState_Idle : PlayerState
    {
        public PlayerState_Idle(PlayerController owner) : base(owner) {

        }

        public override void Initialize() {
            owner.MyPlayerAnimatorUpdater.GoToIdleBlendTree();
            owner.MyPlayerAnimatorUpdater.UpdateIdleAnimations();
        }

        public override void Execute() {
            if (InputManager.Instance.IsMovingAxis)
                owner.GoToMoveState();
        }

        public override void LateExecute() {

        }

        public override void Exit() {

        }

    }
}
