using SH.BusinessLogic;
using SH.Dto;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SH.Model {
    public class Player
    {
        private int currentHp, maxHp;

        private float speed;

        public int MaxHp => maxHp;

        public Player(PlayerData data) {
            this.maxHp = data.MaxHp;
            this.currentHp = data.MaxHp;
            this.speed = data.Speed;
        }

        public void DamageHp(int value) {
            currentHp = Mathf.Clamp(currentHp - value, 0, maxHp);
            EventManager.Instance.Cast(MyEventIndex.OnPlayerDamaged, new MyEventArgs(currentHp));
            if (currentHp == 0)
                Death();
        }

        private void Death() {
            EventManager.Instance.Cast(MyEventIndex.OnPlayerDeath);
        }
    }

}