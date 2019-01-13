using System;
using System.Collections;
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
        public Vector4 WHITE = new Vector4(1f, 1f, 1f, 1f);

        public void Draw(int tex, Vector2 pos, Vector2 scale, int width, int height, Vector4 color)
        {
            Vector2[] verts = new Vector2[4] { new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1) };

            GL.BindTexture(TextureTarget.Texture2D, tex);

            GL.Begin(PrimitiveType.Quads);
            GL.Color4(color);

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

        public void Draw(int tex, Vector2 pos, Vector2 scale, int width, int height)
        {
            Draw(tex, pos, scale, width, height, WHITE);
        }


        private void stringVertex(Vector2 v, Vector2 t, Vector2 pos, Vector2 scale)
        {
            GL.TexCoord2(t);
            GL.Vertex2(v.X * scale.X + pos.X, v.Y * scale.Y + pos.Y);
        }

        public void DrawString(int tex, ArrayList stringData, Vector2 pos, Vector2 scale, Vector4 color)
        {
            GL.BindTexture(TextureTarget.Texture2D, tex);

            GL.Begin(PrimitiveType.Quads);

            GL.Color4(color);

            for (int i = 0; i <= stringData.Count-8; i+=8)
            {
                stringVertex((Vector2)stringData[i], (Vector2)stringData[i + 1], pos, scale);
                stringVertex((Vector2)stringData[i + 2], (Vector2)stringData[i + 3], pos, scale);
                stringVertex((Vector2)stringData[i + 4], (Vector2)stringData[i + 5], pos, scale);
                stringVertex((Vector2)stringData[i + 6], (Vector2)stringData[i + 7], pos, scale);
            }

            GL.End();
        }

        public void DrawString(int tex, ArrayList stringData, Vector2 pos, Vector2 scale)
        {
            DrawString(tex, stringData, pos, scale, WHITE);
        }

        public void DrawString(string t, BmFont font, Vector2 pos, Vector2 scale)
        {
            DrawString(font.getTextureId(), font.buildString(t), pos, scale, WHITE);
        }

        public void DrawString(string t, BmFont font, Vector2 pos, Vector2 scale, Vector4 color)
        {
            DrawString(font.getTextureId(), font.buildString(t), pos, scale, color);
        }

        public void Init(int w, int h)
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            GL.Ortho(-w / 2f, w / 2f, h / 2f, -h / 2f, 0f, 1f);
        }
    }
}
