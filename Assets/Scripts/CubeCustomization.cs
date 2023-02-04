using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CC.Cube.Customization
{
    public class CubeCustomization : MonoBehaviour
    {
        [SerializeField] private MeshRenderer meshRenderer;

        public enum ColorType
        {
            BlackHoleColor,
            SpecificColor
        }
        private ColorType colorType;

        internal void ChangeCubeColor()
        {
            if (colorType == ColorType.BlackHoleColor)
            {

            }
        }
    }
}

