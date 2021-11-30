using UnityEngine;
using UnityEngine.Rendering;

public class ScissorTest : MonoBehaviour
{
    [SerializeField]
    private Mesh _mesh;

    private void Awake()
    {
        var commandBuffer = new CommandBuffer();
        commandBuffer.name = "Scissor Test";
        int w = Screen.width / 2;
        int h = Screen.height;
        commandBuffer.EnableScissorRect(new Rect(0, 0, w, h));

        var material = new Material(Shader.Find("Standard"));
        commandBuffer.DrawMesh(_mesh, Matrix4x4.identity, material, 0, 0);

        var camera = GetComponent<Camera>();

        camera.AddCommandBuffer(CameraEvent.BeforeForwardOpaque, commandBuffer);
    }
}
