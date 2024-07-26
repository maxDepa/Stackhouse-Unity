using SH.Dto;
using UnityEditor;

public class PokemonCreator : EditorWindow
{
    [MenuItem("PokemonExtensions/CreatePokemonDatas")]
    public static void CreatePokemonDatas() {
        for(int i = 0; i < 151; i++) {
            PokemonData data = CreateInstance<PokemonData>();
            data.index = (uint)i + 1;
            AssetDatabase.CreateAsset(data, "Assets/Database/PokemonDatas/PD_" + i + ".asset");
        }
    }
}
