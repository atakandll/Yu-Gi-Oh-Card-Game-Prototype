using System;
using System.Linq;
using Extensions;
using UnityEngine;

namespace Utils
{
    public class UITexturePicker : MonoBehaviour
    {
        [SerializeField] private Sprite[] Sprites;
        [SerializeField] private SpriteRenderer Renderer{ get; set; }

        private void Awake()
        {
            Renderer = GetComponent<SpriteRenderer>();
            if(Sprites.Length>0)
                Renderer.sprite = Sprites.ToList().RandomItem();
        }
    }
}