using NUnit.Framework;
using UnityEngine;

namespace mgrosser3
{
    public class ViewportTest
    {
        [Test]
        public void DefaultSizeTest()
        {
            Viewport viewport = new Viewport();
            Assert.AreEqual(0.8128f, viewport.Size, 1e-6);
        }

        [Test]
        public void SetSizeTest()
        {
            float size = 35.56f; // 14''

            Viewport viewport = new Viewport();
            viewport.Size = size;

            Assert.AreEqual(size, viewport.Size, 1e-4);
        }

        [Test]
        public void DefaultAspectRatio()
        {
            Viewport viewport = new Viewport();
            Assert.AreEqual(16f, viewport.AspectRatio.x, 1e-4);
            Assert.AreEqual(9f, viewport.AspectRatio.y, 1e-4);
        }

        [Test]
        public void SetAspectRatioTest()
        {
            Vector2 ratio = new Vector2(4,3);

            Viewport viewport = new Viewport();
            viewport.AspectRatio = ratio;

            Assert.AreEqual(ratio.x, viewport.AspectRatio.x, 1e-4);
            Assert.AreEqual(ratio.y, viewport.AspectRatio.y, 1e-4);
        }

        [Test]
        public void GetWidthTest()
        {
            Viewport viewport = new Viewport();
            Assert.AreEqual(0.708416f, viewport.Width, 1e-6);
            
        }

        [Test]
        public void GetHeightTest()
        {
            Viewport viewport = new Viewport();
            Assert.AreEqual(0.398484f, viewport.Height, 1e-6);
        }
    }
}