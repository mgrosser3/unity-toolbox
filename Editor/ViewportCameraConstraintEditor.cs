using UnityEditor;

namespace mgrosser3
{
    [CustomEditor(typeof(ViewportCameraConstraint))]
    public class ViewportCameraConstraintEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var constraint = (ViewportCameraConstraint)this.target;

            //float viewportAspect = constraint.Viewport.AspectRatio.x / constraint.Viewport.AspectRatio.y;
            //if ((int)(viewportAspect * 100) != (int)(constraint.Camera.aspect * 100))
            //{
            //    EditorGUILayout.HelpBox("The aspect ratio (width divided by height) of the viewport differs from the aspect ratio of the camera!\n\n" +
            //        $"Camera: {constraint.Camera.aspect:F2}\nViewport: {viewportAspect:F2}",
            //        MessageType.Warning);
            //}
        }
    }
}