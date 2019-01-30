using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace JamBuilder.Rendering
{

	struct GlTexture
	{
		int glID;
		int width, height;
	}

	class RenderManager
	{
		private GLControl glControl;

		private List<GlTexture> textures = new List<GlTexture>();
		/// <summary>filename => index</summary>
		private Dictionary<string, uint> textureDictionary = new Dictionary<string, uint>();

		
		public RenderManager(GLControl glControl)
		{
			this.glControl = glControl;
			glControl.MakeCurrent();
			GL.Enable(EnableCap.Texture2D);
			GL.Enable(EnableCap.Blend);
			GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
			GL.ClearColor(Color.FromArgb(200, 200, 200));
		}

		public int loadTextureFile(string file)
		{
			Bitmap bitmap = new Bitmap("Resources/"+file);

			int tex = GL.GenTexture();
			GL.BindTexture(TextureTarget.Texture2D, tex);

			BitmapData data = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

			GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

			bitmap.UnlockBits(data);

			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Clamp);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Clamp);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);

			return tex;
		}

		public void render()
		{

		}
	}
}
