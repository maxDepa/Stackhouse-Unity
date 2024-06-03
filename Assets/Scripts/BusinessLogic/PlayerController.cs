using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SH.BusinessLogic {
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Animator))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D myRigidbody;
        [SerializeField] private Animator myAnimator;
        [SerializeField] private float speed = 5;
        public Rigidbody2D MyRigidbody2D {
            get {
                if (myRigidbody == null) { 
                    myRigidbody = GetComponent<Rigidbody2D>();
                }
                return myRigidbody;
            }
        }

        public Animator MyAnimator {
            get {
                if(myAnimator == null) {
                    myAnimator = GetComponent<Animator>();
                }
                return myAnimator;
            }
        }


        private void Update() {
            Vector2 inputVector = new Vector2(
                Input.GetAxis("Horizontal"),
                Input.GetAxis("Vertical"));

            MyAnimator.SetFloat("Horizontal", inputVector.x);
            MyAnimator.SetFloat("Vertical", inputVector.y);
            MyAnimator.SetFloat("Speed", inputVector.magnitude);

            MyRigidbody2D.velocity = inputVector * speed;


        }

    }
}
