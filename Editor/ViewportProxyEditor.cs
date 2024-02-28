//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEditor;

//namespace mgrosser3
//{
//    [CustomEditor(typeof(Viewport))]
//    public class ViewportProxyEditor : Editor
//    {
//        public override void OnInspectorGUI()
//        {
//            //base.OnInspectorGUI();

//            var viewport = (Viewport)this.target;

//            EditorGUI.BeginChangeCheck();

//            var size = EditorGUILayout.FloatField("Viewport Diagonal", viewport.Size);
//            Vector2 aspectRatio = EditorGUILayout.Vector2Field("Aspect Ratio", viewport.AspectRatio);
            
//            if (EditorGUI.EndChangeCheck())
//            {
//                viewport.Size = size;
//                viewport.AspectRatio = aspectRatio;
//                EditorUtility.SetDirty(viewport);
//            }

//        }
//    }
//}