using SH.Dto;
using SH.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SH.BusinessLogic {
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] private PlayerData playerData;

        [Header("Components")]
        [SerializeField] private Rigidbody2D myRigidbody;
        [SerializeField] private PlayerAnimatorUpdater myPlayerAnimatorUpdater;


        private Player player;
        private StateMachine<PlayerStateIndex> stateMachine;

        //Properties
        public float Speed => playerData.Speed;

        public Rigidbody2D MyRigidbody2D {
            get {
                if (myRigidbody == null) { 
                    myRigidbody = GetComponent<Rigidbody2D>();
                }
                return myRigidbody;
            }
        }

        public PlayerAnimatorUpdater MyPlayerAnimatorUpdater => myPlayerAnimatorUpdater;

        //MonoBehaviour
        private IEnumerator Start() {
            InitializeStateMachine();
            EventManager.Instance.AddListener(MyEventIndex.OnPlayerDeath, OnPlayerDeath);
            yield return null;
            InitializePlayer();
        }

        private void Update() {
            stateMachine.Execute();

            //TEST
            if (Input.GetKeyDown(KeyCode.P))
                player.DamageHp(10);
        }

        private void LateUpdate() {
            stateMachine.LateExecute();
        }

        private void OnDestroy() {
            EventManager.Instance.RemoveListener(MyEventIndex.OnPlayerDeath, OnPlayerDeath);
        }

        //
        private void InitializePlayer() {
            player = new Player(playerData);
            EventManager.Instance.Cast(MyEventIndex.OnPlayerInitialized, new MyEventArgs(new Vector2Int(0, player.MaxHp)));
        }

        private void InitializeStateMachine() {
            stateMachine = new StateMachine<PlayerStateIndex>();
            stateMachine.AddState(PlayerStateIndex.Idle, new PlayerState_Idle(this));
            stateMachine.AddState(PlayerStateIndex.Move, new PlayerState_Move(this, new RigidbodyMovementStrategy()));
            stateMachine.ChangeState(PlayerStateIndex.Idle);
        }

        public void GoToIdleState() {
            stateMachine.ChangeState(PlayerStateIndex.Idle);
        }

        public void GoToMoveState() {
            stateMachine.ChangeState(PlayerStateIndex.Move);
        }

        private void OnPlayerDeath(MyEventArgs arg0) {
            gameObject.SetActive(false);
        }

    }
}
