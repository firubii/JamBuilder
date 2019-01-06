using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Drawing.Imaging;

namespace JamBuilder.Rendering
{
    public class Renderer
    {
        public void Draw(int tex, Vector2 pos, Vector2 scale, int width, int height)
        {
            Vector2[] verts = new Vector2[4] { new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1) };

            GL.BindTexture(TextureTarget.Texture2D, tex);

            GL.Begin(PrimitiveType.Quads);

            for (int i = 0; i < verts.Length; i++)
            {
                GL.TexCoord2(verts[i]);

                verts[i].X *= width;
                verts[i].Y *= height;
                verts[i] *= scale;
                verts[i] += pos;

                GL.Vertex2(verts[i]);
            }

            GL.End();
        }

        public void Begin(int w, int h)
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            GL.Ortho(-w / 2f, w / 2f, h / 2f, -h / 2f, 0f, 1f);
        }
    }
}
