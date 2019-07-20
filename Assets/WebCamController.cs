using UnityEngine;
using UnityEngine.UI;

public delegate void TextureReceiver(Texture2D webCamTexture);

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
        Texture2D snap = new Texture2D(this.webCamTexture.width, this.webCamTexture.height);
        snap.SetPixels(this.webCamTexture.GetPixels());
        snap.Apply();

        OnTextureShoot?.Invoke(snap);

        this.webCamTexture.Stop();
    }
}
