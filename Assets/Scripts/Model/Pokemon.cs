using SH.Dto;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SH.Model {
    public class Pokemon
    {
        public uint index;
        public string description;
        public Sprite gfx;

        public Stat atk;

        public Pokemon(PokemonData data) { 
            this.index = data.index;
            this.description = data.description;
            gfx = data.gfx;

            this.atk = new Stat(data.atk);
        }
    }

    [System.Serializable]
    public class Stat {
        public int value;

        public Stat(Stat s) {
            this.value = s.value;
        }

        public void SetValue(int v) {
            value = v;
        }
    }
}
