using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace mgrosser3
{
    public class S3DCameraRigTest
    {
        [UnityTest]
        public IEnumerator DefaultSetupTest()
        {
            GameObject obj = new GameObject("Camera Rig (S3D)");
            S3DCameraRig rig = obj.AddComponent<S3DCameraRig>();

            yield return null;

            // Default interocular distance should be 64 cm.
            Assert.AreEqual(0.064f, rig.InterocularDistance, "Interocular Distance");

            // Default convergence plane distance should be 80 cm.
            Assert.AreEqual(0.8f, rig.ConvergencePlaneDistance, "Convergence Plane Distance");

            // Evaluate left camera position
            Vector3 localPosLeft = rig.CameraLeft.transform.position - obj.transform.position;
            Assert.AreEqual(-0.5f*rig.InterocularDistance, localPosLeft.x, 1e-6f, "Position Camera Left (x)");
            Assert.AreEqual(0f, localPosLeft.y, 1e-6f, "Position Camera Left (y)");
            Assert.AreEqual(-rig.ConvergencePlaneDistance, localPosLeft.z, 1e-6f, "Position Camera Left (z)");

            // Evaluate left camera orientation
            Assert.AreEqual(obj.transform.rotation.w, rig.CameraLeft.transform.rotation.w, 1e-6f, "Orientation Camera Left (w)");
            Assert.AreEqual(obj.transform.rotation.x, rig.CameraLeft.transform.rotation.x, 1e-6f, "Orientation Camera Left (x)");
            Assert.AreEqual(obj.transform.rotation.y, rig.CameraLeft.transform.rotation.y, 1e-6f, "Orientation Camera Left (y)");
            Assert.AreEqual(obj.transform.rotation.z, rig.CameraLeft.transform.rotation.z, 1e-6f, "Orientation Camera Left (z)");

            // Evaluate right camera position
            Vector3 localPosRight = rig.CameraRight.transform.position - obj.transform.position;
            Assert.AreEqual(0.5f * rig.InterocularDistance, localPosRight.x, 1e-6f, "Position Camera Right (x)");
            Assert.AreEqual(0f, localPosRight.y, 1e-6f, "Position Camera Right (y)");
            Assert.AreEqual(-rig.ConvergencePlaneDistance, localPosRight.z, 1e-6f, "Position Camera Right (z)");

            // Evaluate left camera orientation
            Assert.AreEqual(obj.transform.rotation.w, rig.CameraRight.transform.rotation.w, 1e-6f, "Orientation Camera Right (w)");
            Assert.AreEqual(obj.transform.rotation.x, rig.CameraRight.transform.rotation.x, 1e-6f, "Orientation Camera Right (x)");
            Assert.AreEqual(obj.transform.rotation.y, rig.CameraRight.transform.rotation.y, 1e-6f, "Orientation Camera Right (y)");
            Assert.AreEqual(obj.transform.rotation.z, rig.CameraRight.transform.rotation.z, 1e-6f, "Orientation Camera Right (z)");
        }
    }
}