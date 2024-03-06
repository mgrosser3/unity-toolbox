using UnityEngine;

namespace mgrosser3
{
    [AddComponentMenu("mgrosser3/S3D Camera Rig")]
    public class S3DCameraRig : MonoBehaviour
    {
        [SerializeField]
        private GameObject cameraLeft = null;

        public GameObject CameraLeft
        {
            get { return this.cameraLeft; }
        }

        [SerializeField]
        private GameObject cameraRight = null;

        public GameObject CameraRight
        {
            get { return this.cameraRight; }
        }

        /// <summary>
        /// Distance between the cameras.
        /// </summary>
        [SerializeField]
        private float interocularDistance;

        public float InterocularDistance
        {
            get { return this.interocularDistance; }
            
            set
            {
                if (value < 0f)
                    return;

                this.interocularDistance = value;

                float halfIOD = 0.5f * this.interocularDistance;

                if (this.cameraLeft != null)
                {
                    Vector3 p = this.cameraLeft.transform.localPosition;
                    p.x = -halfIOD;
                    this.cameraLeft.transform.localPosition = p;
                }

                if (this.cameraRight != null)
                {
                    Vector3 p = this.cameraRight.transform.localPosition;
                    p.x = +halfIOD;
                    this.cameraRight.transform.localPosition = p;
                }
            }
        }

        /// <summary>
        /// Distance to the convergance plane.
        /// </summary>
        [SerializeField]
        private float convergencePlaneDistance;

        public float ConvergencePlaneDistance
        {
            get { return this.convergencePlaneDistance; }

            set
            {
                if (value <= 0f)
                    return;

                this.convergencePlaneDistance = value;

                if (this.cameraLeft != null)
                {
                    Vector3 p = this.cameraLeft.transform.localPosition;
                    p.z = -this.convergencePlaneDistance;
                    this.cameraLeft.transform.localPosition = p;
                }

                if (this.cameraRight != null)
                {
                    Vector3 p = this.cameraRight.transform.localPosition;
                    p.z = -this.convergencePlaneDistance;
                    this.cameraRight.transform.localPosition = p;
                }
            }
        }

        /// <summary>
        /// Create all necessary objects and relations
        /// of the camera rig.
        /// </summary>
        private void Setup()
        {
            if (this.cameraLeft == null)
            {
                this.cameraLeft = new GameObject("Camera Left (S3D)");
                this.cameraLeft.transform.parent = this.transform;
                this.cameraLeft.transform.localPosition = Vector3.zero;
                this.cameraLeft.transform.localRotation = Quaternion.identity;
                this.cameraLeft.AddComponent<Camera>();
                this.cameraLeft.AddComponent<ViewportCameraConstraint>().Viewport.Target = this.transform;
            }

            if (this.cameraRight == null)
            {
                this.cameraRight = new GameObject("Camera Right (S3D)");
                this.cameraRight.transform.parent = this.transform;
                this.cameraRight.transform.localPosition = Vector3.zero;
                this.cameraRight.transform.localRotation = Quaternion.identity;
                this.cameraRight.AddComponent<Camera>();
                this.cameraRight.AddComponent<ViewportCameraConstraint>().Viewport.Target = this.transform;
            }

            this.InterocularDistance = 0.064f;
            this.ConvergencePlaneDistance = 0.8f;

        }

        private void OnValidate()
        {
            if (this.interocularDistance < 0f)
                this.interocularDistance = 0f;
            this.InterocularDistance = this.interocularDistance;

            if (this.convergencePlaneDistance <= 0f)
                this.convergencePlaneDistance = 1e-6f;
            this.ConvergencePlaneDistance = this.convergencePlaneDistance;
        }

        private void Reset()
        {
            Setup();
        }

        void Start()
        {
            Setup();
        }

        
    }
}