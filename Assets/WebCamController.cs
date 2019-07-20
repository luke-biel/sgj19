using UnityEngine;
using UnityEngine.UI;

public delegate void TextureReceiver(WebCamTexture webCamTexture);

public class WebCamController : MonoBehaviour
{
    public RawImage textureTarget;

    private WebCamTexture webCamTexture;

    public event TextureReceiver OnTextureShoot;

    private void Start()
    {
        this.webCamTexture = new WebCamTexture();
        webCamTexture.Play();
    }

    private void Update()
    {
        this.textureTarget.texture = webCamTexture;
    }

    public void Shoot()
    {
        OnTextureShoot?.Invoke(this.webCamTexture);
    }
}
