using UnityEngine;

namespace mgrosser3
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(Camera))]
    [AddComponentMenu("mgrosser3/Viewport Camera Constraint")]
    public class ViewportCameraConstraint : MonoBehaviour
    {
        [SerializeField]
        private ViewportProxy viewport = null;

        private new Camera camera;

        public ViewportProxy Viewport
        {
            get
            {
                return this.viewport;
            }
        }

        public Camera Camera
        {
            get
            {
                return this.camera;
            }
        }

        private void Start()
        {
            this.camera = this.GetComponent<Camera>();
            this.camera.ResetProjectionMatrix();
        }

        private void LateUpdate()
        {
            if (this.viewport == null || this.camera == null)
                return;

            var position = this.transform.worldToLocalMatrix * (this.transform.position - this.viewport.transform.position);

            if (position.z >= 0f)
            {
                this.camera.fieldOfView = 30f;
                this.camera.ResetProjectionMatrix();
                return;
            }

            // The Z-Value represents the distance to the
            // Screen / Projection Plane. This value must
            // be less than zero, otherwise the projection
            // matrix becomes invalid.
            if (position.z >= 0.0f)
                return;

            // Adjust projection matrix
            // see https://docs.unity3d.com/Manual/ObliqueFrustum.html
            var aspect = this.camera.aspect;

            var fovV = 2.0f * Mathf.Rad2Deg * Mathf.Atan2(this.viewport.Height, 2.0f * Mathf.Abs(position.z));
            var fovH = Camera.VerticalToHorizontalFieldOfView(fovV, aspect);

            var horizontalShift = -position.x / (-position.z * Mathf.Tan(Mathf.Deg2Rad * 0.5f * fovH));
            var verticalShift = -position.y / (-position.z * Mathf.Tan(Mathf.Deg2Rad * 0.5f * fovV));

            var scaleY = 1f / Mathf.Tan(fovV / (2f * Mathf.Rad2Deg));
            var scaleX = scaleY / aspect;

            Matrix4x4 mat = this.camera.projectionMatrix;
            mat[0, 0] = scaleX;
            mat[1, 1] = scaleY;
            mat[0, 2] = horizontalShift;
            mat[1, 2] = verticalShift;
            this.camera.projectionMatrix = mat;

            // Reset the vertical field of view
            this.transform.rotation = this.viewport.transform.rotation;
            this.camera.fieldOfView = fovV;
        }
    }
}