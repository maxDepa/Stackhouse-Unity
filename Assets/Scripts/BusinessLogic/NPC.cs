using SH.View;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SH.BusinessLogic {

    public class NPC : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] private NPCData data;

        [Header("Components")]
        [SerializeField] private SpriteRenderer spriteRenderer;

        void Start () {
            UpdateNPCGfx();
        }

        private void UpdateNPCGfx() {
            spriteRenderer.sprite = data.Gfx;
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            EventManager.Instance.AddListener(MyEventIndex.OnInputConfirm, OnInputConfirm);
        }

        private void OnTriggerExit2D(Collider2D collision) {
            EventManager.Instance.RemoveListener(MyEventIndex.OnInputConfirm, OnInputConfirm);
        }

        private void OnInputConfirm(MyEventArgs arg0) {
            EventManager.Instance.Cast(MyEventIndex.OnDialogueStart, new MyEventArgs(data.Dialogue));
        }
    }
}
