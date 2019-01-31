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
		public int glID;
		public int width, height;
	}

	struct Gl2DModel
	{
		public int glID;
		public int vertCount;
	}

	struct Gl3DModel
	{
		public int glID;
		public int vertCount;
	}

	struct GLShader
	{
		public int glID;
	}

	public class RenderManager
	{
		private GLControl glControl;

		private List<GlTexture> textures = new List<GlTexture>();
		/// <summary>filename => index</summary>
		private Dictionary<string, uint> textureDictionary = new Dictionary<string, uint>();

		private List<Gl2DModel> models2d = new List<Gl2DModel>();
		private List<Gl3DModel> models3d = new List<Gl3DModel>();

		/// <summary>Shorthand for performance</summary>
		private Gl2DModel centeredQuad;

		private GLShader testShader;

		public RenderManager(GLControl glControl)
		{
			this.glControl = glControl;
			glControl.MakeCurrent();
			GL.Enable(EnableCap.Texture2D);
			GL.Enable(EnableCap.Blend);
			GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
			float[] centeredQuadData =
			{
				//VX	VY			TX		TY
				//Tri1
				-0.5f,	-0.5f,		0.0f,	0.0f,
				0.5f,	-0.5f,		1.0f,	0.0f,
				-0.5f,	0.5f,		0.0f,	1.0f,
				//Tri2
				-0.5f,	0.5f,       0.0f,	1.0f,
				0.5f,	0.5f,       1.0f,	1.0f,
				0.5f,	-0.5f,		1.0f,	0.0f
			};
			centeredQuad = models2d[loadModel2D(centeredQuadData)];
			testShader = loadShader("shader/test.vert", "shader/test.frag");
		}

		~RenderManager()
		{
			for(int i = 0; i < textures.Count; i++)
			{
				GL.DeleteTexture(textures[i].glID);
			}
			for (int i = 0; i < textures.Count; i++)
			{
				GL.DeleteVertexArray(models2d[i].glID);
			}
			for (int i = 0; i < textures.Count; i++)
			{
				GL.DeleteVertexArray(models3d[i].glID);
			}
		}

		public int loadTextureFile(string file)
		{
			Console.WriteLine("Loading Texture \"" + file + "\"");
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

			GlTexture gTex;
			gTex.glID = tex;
			gTex.width = data.Width;
			gTex.height = data.Height;

			textures.Add(gTex);
			textureDictionary[file] = (uint)(textures.Count - 1);

			return textures.Count-1;
		}

		private GLShader loadShader(string vertFile, string fragFile)
		{
			Console.WriteLine("Loading Shader v:\"" + vertFile + "\" f:\"" + fragFile + "\"");
			string vertStr = System.IO.File.ReadAllText("Resources/" + vertFile);
			string fragStr = System.IO.File.ReadAllText("Resources/" + fragFile);
			int vertSh = GL.CreateShader(ShaderType.VertexShader);
			int fragSh = GL.CreateShader(ShaderType.FragmentShader);
			GL.ShaderSource(vertSh, vertStr);
			GL.ShaderSource(fragSh, fragStr);

			int prog = GL.CreateProgram();
			GL.AttachShader(prog, vertSh);
			GL.AttachShader(prog, fragSh);
			GL.BindAttribLocation(prog, 0, "inPos");
			GL.BindAttribLocation(prog, 1, "inTex");
			GL.LinkProgram(prog);
			GL.DetachShader(prog, vertSh);
			GL.DetachShader(prog, fragSh);

			int c;
			GL.GetShader(vertSh, ShaderParameter.CompileStatus, out c);
			Console.WriteLine("VertC " + c);
			GL.GetShader(fragSh, ShaderParameter.CompileStatus, out c);
			Console.WriteLine("FragC " + c);
			GL.GetProgram(prog, GetProgramParameterName.LinkStatus, out c);
			Console.WriteLine("ProgC " + c);
			GL.DeleteShader(vertSh);
			GL.DeleteShader(fragSh);
			GLShader sh;
			sh.glID = prog;
			return sh;
		}

		/// <summary>
		/// Loads a 2-dimensional model.
		/// Length must be a minimum of 12 and a multiple of 4. Format: x, y, texX, texY...
		/// </summary>
		public int loadModel2D(float[] vertData)
		{
			Console.WriteLine("Loading 2DModel");
			if (vertData.Length < 12 || vertData.Length % 4 != 0)
			{
				Console.WriteLine("Warning: 2DModel length is invalid (" + vertData.Length + ")");
			}

			int vao = GL.GenVertexArray();
			GL.BindVertexArray(vao);
			int vbo = GL.GenBuffer();
			GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
			Console.WriteLine("2D " + GL.GetError());
			int fs = sizeof(float);
			GL.BufferData(BufferTarget.ArrayBuffer, vertData.Length * fs, vertData, BufferUsageHint.StaticDraw);
			Console.WriteLine("2D " + GL.GetError());
			GL.VertexAttribPointer(0, 2, VertexAttribPointerType.Float, false, 4 * fs, 0);
			GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, 4 * fs, 2 * fs);
			Console.WriteLine("2D " + GL.GetError());

			Gl2DModel mdl;
			mdl.glID = vao;
			mdl.vertCount = vertData.Length / 4;

			models2d.Add(mdl);
			Console.WriteLine("2D "+GL.GetError());
			return models2d.Count - 1;
		}

		/// <summary>
		/// Loads a 2-dimensional model.
		/// Length must be a minimum of 15 and a multiple of 5. Format: x, y, z, texX, texY...
		/// </summary>
		public int loadModel3D(float[] vertData)
		{
			Console.WriteLine("Loading 3DModel");
			if (vertData.Length < 15 || vertData.Length % 5 != 0)
			{
				Console.WriteLine("Warning: 2DModel length is invalid (" + vertData.Length + ")");
			}

			int vao = GL.GenVertexArray();
			GL.BindVertexArray(vao);
			int vbo = GL.GenBuffer();
			GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
			int fs = sizeof(float);
			GL.BufferData(BufferTarget.ArrayBuffer, vertData.Length * fs, vertData, BufferUsageHint.StaticDraw);
			GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 5 * fs, 0);
			GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, 5 * fs, 3 * fs);

			Gl3DModel mdl;
			mdl.glID = vao;
			mdl.vertCount = vertData.Length / 5;

			models3d.Add(mdl);

			return models3d.Count-1;
		}

		public void render()
		{
			GL.ClearColor(0.6f, 0.6f, 0.6f, 1.0f);
			GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
			GL.UseProgram(testShader.glID);
			Console.WriteLine("Use" + GL.GetError());
			GL.BindVertexArray(centeredQuad.glID);
			GL.EnableVertexAttribArray(0);
			GL.EnableVertexAttribArray(1);
			Console.WriteLine("Bind" + GL.GetError());
			GL.DrawArrays(PrimitiveType.Triangles, 0, centeredQuad.vertCount);
			GL.DisableVertexAttribArray(1);
			GL.DisableVertexAttribArray(0);
			Console.WriteLine(GL.GetError());
			//GL.BindTexture(TextureTarget.Texture2D, )
			glControl.SwapBuffers();
		}
	}
}
