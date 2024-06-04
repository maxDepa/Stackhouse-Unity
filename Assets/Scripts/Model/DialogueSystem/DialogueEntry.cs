using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SH.Model {
    public class DialogueEntry
    {
        private string talker;
        private string message;

        public string Talker => talker;

        public string Message => message;

        public DialogueEntry(string talker, string message) {
            this.talker = talker;
            this.message = message;
        }
    }
}
