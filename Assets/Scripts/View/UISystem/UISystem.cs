using SH.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SH.View {
    public abstract class UISystem : MonoBehaviour, IActivable
    {
        [SerializeField] private BaseScreen startScreen;
        private BaseScreen currentScreen;

        public void Activate() {
            ActivateScreen(startScreen);
        }

        public void Deactivate() {
            DeactivateCurrentScreen();
        }

        public void ActivateScreen(BaseScreen screen) {
            DeactivateCurrentScreen();
            currentScreen = screen;
            currentScreen.Activate();
        }

        private void DeactivateCurrentScreen() {
            currentScreen?.Deactivate();
        }
    }
}
