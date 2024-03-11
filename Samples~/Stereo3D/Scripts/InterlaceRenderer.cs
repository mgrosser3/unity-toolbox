using UnityEngine;
using UnityEngine.Rendering;

public class InterlaceRenderer : MonoBehaviour
{
    public Material mat = null;

    // Start is called before the first frame update
    void Start()
    {
        Camera cam = this.GetComponent<Camera>();
        
        if (cam == null)
            return;

        CommandBuffer cb = new CommandBuffer();
        cb.Blit(null, Graphics.activeColorBuffer, this.mat);
        cam.AddCommandBuffer(CameraEvent.AfterEverything, cb);
    }
}
