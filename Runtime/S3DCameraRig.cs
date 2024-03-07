using UnityEngine;

namespace mgrosser3
{
    [AddComponentMenu("mgrosser3/S3D Camera Rig")]
    public class S3DCameraRig : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Right camera of the rig.")]
        private GameObject cameraLeft = null;

        [SerializeField]
        [Tooltip("Left camera of the rig.")]
        private GameObject cameraRight = null;

        [SerializeField]
        [Tooltip("Distance between the cameras.")]
        private float interocularDistance;

        [SerializeField]
        [Tooltip("Distance to the convergance plane.")]
        private float convergencePlaneDistance;

        [Header("Camera Settings")]

        [SerializeField]
        [Tooltip("Clear flag of the cameras.")]
        private CameraClearFlags clearFlag;

        [SerializeField]
        [Tooltip("Background color of the cameras.")]
        private Color background;

        public CameraClearFlags ClearFlag
        {
            get
            {
                return this.clearFlag;
            }

            set
            {
                this.clearFlag = value;

                System.Action<GameObject> SetCameraClearFlag = (GameObject obj) =>
                {
                    if (obj != null)
                    {

                        Camera cam = obj.GetComponent<Camera>();
                        if (cam != null)
                            cam.clearFlags = this.clearFlag;
                    }
                };

                SetCameraClearFlag(this.cameraLeft);
                SetCameraClearFlag(this.cameraRight);
            }
        }

        /// <summary>
        /// Background color of the cameras.
        /// </summary>
        public Color Background
        {
            get
            {
                return this.background;
            }

            set
            {
                this.background = value;

                System.Action<GameObject> SetCameraBackground = (GameObject obj) =>
                {
                    if (obj != null)
                    {

                        Camera cam = obj.GetComponent<Camera>();
                        if (cam != null)
                            cam.backgroundColor = this.background;
                    }
                };

                SetCameraBackground(this.CameraLeft);
                SetCameraBackground(this.CameraRight);
            }
        }

        /// <summary>
        /// Distance between the cameras.
        /// </summary>
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
        /// Right camera of the rig.
        /// </summary>
        public GameObject CameraRight
        {
            get { return this.cameraRight; }
        }

        /// <summary>
        /// Left camera of the rig.
        /// </summary>
        public GameObject CameraLeft
        {
            get { return this.cameraLeft; }
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

            this.ClearFlag = CameraClearFlags.Color;
            this.Background = new Color32(49, 77, 121, 255);
            this.InterocularDistance = 0.064f;
            this.ConvergencePlaneDistance = 0.8f;

        }

        private void OnValidate()
        {
            this.ClearFlag = this.clearFlag;
            this.Background = this.background;

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