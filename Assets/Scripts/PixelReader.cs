using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PixelReader : MonoBehaviour {
    public Texture2D tex;
    public List<Color32> colors = new List<Color32>(512);
    HashSet<Color32> colors_hash = new HashSet<Color32>();
    Color32[] colors_all;
    void Awake() {
        colors_all = tex.GetPixels32();
        foreach (var color in colors_all) {
            if (color.a == 0)
                continue;
            colors_hash.Add(color);
        }
        foreach (var color in colors_hash) {
            colors.Add(color);
        }
    }
}
