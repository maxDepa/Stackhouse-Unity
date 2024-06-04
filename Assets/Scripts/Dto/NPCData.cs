using SH.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SH.View {
    [CreateAssetMenu(fileName = "ND-000", menuName = "DataStructures/NPCData", order = 2)]
    public class NPCData : ScriptableObject
    {
        [SerializeField] private string talker;
        [SerializeField] private string message;
        [SerializeField] private Sprite gfx;

        public string Talker => talker;

        public string Message => message;

        public Sprite Gfx => gfx;

        public DialogueEntry Dialogue => new DialogueEntry(talker, message);
    }
}
