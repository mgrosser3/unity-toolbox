using UnityEngine;

namespace mgrosser3
{

    [AddComponentMenu("mgrosser3/Viewport (Proxy)")]
    public class ViewportProxy : MonoBehaviour
    {

        /// <summary>
        /// If possible, use the public property Size instead of
        /// the internal state of the size.
        /// </summary>
        [SerializeField]
        private float size = 81.28f; // default is 32''

        /// <summary>
        /// If possible, use the public property AspectRatio instead of
        /// the internal state of the aspect ratio.
        /// </summary>
        [SerializeField]
        private Vector2 aspectRatio = new Vector2(16, 9);

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
                return 0.01f * (this.AspectRatio.x / t) * this.size;
            }
        }

        public float Height
        {
            get
            {
                // Wikipedia: https://de.wikipedia.org/wiki/Bildschirmdiagonale#Seitenl%C3%A4ngen_und_Fl%C3%A4che
                float t = Mathf.Sqrt(this.AspectRatio.x * this.AspectRatio.x + this.AspectRatio.y * this.AspectRatio.y);
                return 0.01f * (this.AspectRatio.y / t) * this.size;
            }
        }

        private void Start()
        {
            ;
        }

        private void OnDrawGizmos()
        {
            if (this.enabled == false)
                return;

            var positions = new Vector3[] {
                this.transform.position + this.transform.rotation * new Vector3(-0.5f * this.Width, -0.5f * this.Height),
                this.transform.position + this.transform.rotation * new Vector3(-0.5f * this.Width, +0.5f * this.Height),
                this.transform.position + this.transform.rotation * new Vector3(+0.5f * this.Width, +0.5f * this.Height),
                this.transform.position + this.transform.rotation * new Vector3(+0.5f * this.Width, -0.5f * this.Height)
            };

            Gizmos.DrawLine(positions[0], positions[1]);
            Gizmos.DrawLine(positions[1], positions[2]);
            Gizmos.DrawLine(positions[2], positions[3]);
            Gizmos.DrawLine(positions[3], positions[0]);
        }

    }

}
