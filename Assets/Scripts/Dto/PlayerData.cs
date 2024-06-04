using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SH.Dto {
    [CreateAssetMenu(fileName = "PlayerData", menuName = "DataStructures/PlayerData", order = 0)]
    public class PlayerData : ScriptableObject
    {
        [Header("Statistics")]
        [SerializeField] private int maxHp;

        [Header("Movement Variables")]
        [SerializeField] private float speed;

        public int MaxHp => maxHp;

        public float Speed => speed;
    }
}
