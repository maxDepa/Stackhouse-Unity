using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SH.BusinessLogic {
    public enum MyEventIndex
    {
        OnGameStart,

        OnPlayerInitialized,
        OnPlayerDamaged,
        OnPlayerDeath,
        OnPokemonDamaged,
        OnRandomEncounter,
        OnDialogueStart,

        OnInputConfirm,
        OnInputInventory,
        OnInputCancel,
        OnInputRightArrow,
        OnInputUpArrow,
        OnInputLeftArrow,
        OnInputDownArrow
    }
}
