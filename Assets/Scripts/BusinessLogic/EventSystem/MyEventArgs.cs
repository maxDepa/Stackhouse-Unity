using SH.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SH.BusinessLogic {
    public class MyEventArgs
    {
        public string additionalString;
        public int additionalInt;
        public Vector2Int additionalVector2;
        public DialogueEntry additionalDialogueEntry;
        //...

        public MyEventArgs(int additionalInt) { 
            this.additionalInt = additionalInt;
        }

        public MyEventArgs(Vector2Int additionalVector2) {
            this.additionalVector2 = additionalVector2;
        }

        public MyEventArgs(DialogueEntry additionalDialogueEntry) { 
            this.additionalDialogueEntry = additionalDialogueEntry;
        }
    }
}
