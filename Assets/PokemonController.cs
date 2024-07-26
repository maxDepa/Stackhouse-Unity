using SH.Dto;
using SH.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonController : MonoBehaviour
{
    [SerializeField] private PokemonData data;
    private Pokemon _pokemon;

    List<PokemonData> _data;
    GameObject pokemonPrefab;

    void Start()
    {
        foreach (PokemonData data in _data) {
            GameObject go = new GameObject();
            //GameObject.Instantiate(pokemonPrefab);
            PokemonController pc = go.AddComponent<PokemonController>();
            pc.Initialize(data);
        }
    }

    public void Initialize(PokemonData data) {
        _pokemon = new Pokemon(data);
        _pokemon.description = "LALALSLDLALA";
    }
}
