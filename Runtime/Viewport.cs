using System;
using UnityEngine;

namespace mgrosser3
{

    [Serializable]
    public class Viewport
    {
        /// <summary>
        /// If possible, use the public property Size instead of
        /// the internal state of the size.
        /// </summary>
        [SerializeField]
        private float size = 0.8128f; // default is 32''

        /// <summary>
        /// If possible, use the public property AspectRatio instead of
        /// the internal state of the aspect ratio.
        /// </summary>
        private Vector2 aspectRatio = new Vector2(16, 9);

        [SerializeField]
        private Transform target = null;

        public Vector2 AspectRatio
        {
            get { return this.aspectRatio; }
            set
            {
                // The aspect ratio of the viewport
                // cannot be negative or zero.
                if (value.x <= 0f || value.y <= 0f)
                    return;

                this.aspectRatio = value;
            }
        }

        /// <summary>
        /// Size of the viewport can be defined by the
        /// length of the diagonal.
        /// </summary>
        public float Size
        {
            get { return this.size; }
            set
            {
                // The size of the viewport
                // cannot be negative or zero.
                if (value <= 0f)
                    return;

                this.size = value;
            }
        }

        public float Width
        {
            get
            {
                // Wikipedia: https://de.wikipedia.org/wiki/Bildschirmdiagonale#Seitenl%C3%A4ngen_und_Fl%C3%A4che
                float t = Mathf.Sqrt(this.AspectRatio.x * this.AspectRatio.x + this.AspectRatio.y * this.AspectRatio.y);
                return (this.AspectRatio.x / t) * this.size;
            }
        }

        public float Height
        {
            get
            {
                // Wikipedia: https://de.wikipedia.org/wiki/Bildschirmdiagonale#Seitenl%C3%A4ngen_und_Fl%C3%A4che
                float t = Mathf.Sqrt(this.AspectRatio.x * this.AspectRatio.x + this.AspectRatio.y * this.AspectRatio.y);
                return (this.AspectRatio.y / t) * this.size;
            }
        }

        public Vector3 Position
        {
            get
            {
                return this.target != null ? this.target.position : Vector3.zero;
            }
        }

        public Quaternion Rotation
        {
            get
            {
                return this.target != null ? this.target.rotation : Quaternion.identity;
            }
        }
    }

}
