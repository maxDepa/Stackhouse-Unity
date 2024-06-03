using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SH.Dto
{
    [CreateAssetMenu(fileName = "PD-000", menuName = "DataStructures/PokemonData", order = 0)]
    public class PokemonData : ScriptableObject
    {
        public uint index;
        public string description;
        public Sprite gfx;

        //Mosse
        //Statistiche
        //Elementi
    }
}
