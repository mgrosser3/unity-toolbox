using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace mgrosser3
{
    public class ViewportProxyTest
    {
        private GameObject obj;
        private ViewportProxy viewport;

        [SetUp]
        public void Setup()
        {
            this.obj = new GameObject("Viewport (Proxy)");
            this.viewport = obj.AddComponent<ViewportProxy>();
        }

        [TearDown]
        public void TearDown()
        {
            GameObject.Destroy(this.obj);
        }

        [UnityTest]
        public IEnumerator DefaultSizeTest()
        {
            yield return null;

            Assert.AreEqual(0.708416f, this.viewport.Width, 1e-6);
            Assert.AreEqual(0.398484f, this.viewport.Height, 1e-6);
        }

        [UnityTest]
        public IEnumerator SetSizeTest()
        {
            float size = 35.56f; // 14''
            this.viewport.Size = size;
            yield return null;

            Assert.AreEqual(size, this.viewport.Size, 1e-4);
        }

        [UnityTest]
        public IEnumerator DefaultAspectRatio()
        {
            yield return null;

            Assert.AreEqual(16f, this.viewport.AspectRatio.x, 1e-4);
            Assert.AreEqual(9f, this.viewport.AspectRatio.y, 1e-4);
        }

        [UnityTest]
        public IEnumerator SetAspectRatioTest()
        {
            Vector2 ratio = new Vector2(4,3);
            this.viewport.AspectRatio = ratio;
            yield return null;

            Assert.AreEqual(ratio.x, this.viewport.AspectRatio.x, 1e-4);
            Assert.AreEqual(ratio.y, this.viewport.AspectRatio.y, 1e-4);
        }


    }
}