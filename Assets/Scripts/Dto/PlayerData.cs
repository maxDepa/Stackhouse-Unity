using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SH.Dto {
    [CreateAssetMenu(fileName = "PlayerData", menuName = "DataStructures/PlayerData", order = 0)]
    public class PlayerData : ScriptableObject
    {
        [Header("Movement Variables")]
        [SerializeField] private float speed;

        public float Speed => speed;
    }
}
