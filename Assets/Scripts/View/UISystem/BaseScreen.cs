using SH.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SH.View {
    public class BaseScreen : MonoBehaviour, IActivable
    {
        //Buttons

        public void Activate() {
            gameObject.SetActive(true);
            //
        }

        public void Deactivate() {
            gameObject.SetActive(false);
            //
        }
    }
}
