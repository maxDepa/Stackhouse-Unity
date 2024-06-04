using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SH.BusinessLogic {
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimatorUpdater : MonoBehaviour
    {
        [SerializeField] private Animator myAnimator;

        public Animator MyAnimator {
            get {
                if (myAnimator == null) {
                    myAnimator = GetComponent<Animator>();
                }
                return myAnimator;
            }
        }

        public void GoToIdleBlendTree() {
            MyAnimator.Play("Idle");
        }

        public void GoToMoveBlendTree() {
            MyAnimator.Play("Move");
        }

        public void UpdateMoveAnimations() {
            UpdateAnimatorAxis(InputManager.Instance.InputAxis);
        }

        public void UpdateIdleAnimations() {
            switch (InputManager.Instance.LastArrowUp) {
                case KeyCode.RightArrow:
                    UpdateAnimatorAxis(Vector2.right);
                    break;
                case KeyCode.UpArrow:
                    UpdateAnimatorAxis(Vector2.up);
                    break;
                case KeyCode.LeftArrow:
                    UpdateAnimatorAxis(Vector2.left);
                    break;
                case KeyCode.DownArrow:
                    UpdateAnimatorAxis(Vector2.down);
                    break;
            }
        }

        private void UpdateAnimatorAxis(Vector2 input) {
            MyAnimator.SetFloat("Horizontal", input.x);
            MyAnimator.SetFloat("Vertical", input.y);
        }
    }
}
