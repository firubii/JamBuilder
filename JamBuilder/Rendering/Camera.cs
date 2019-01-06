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
    class Camera
    {
        public Vector2 pos;
        public double zoom = 1.0;

        public Camera(Vector2 stPos, double stZoom)
        {
            pos = stPos;
            zoom = stZoom;
        }

        public void Transform()
        {
            Matrix4 transform = Matrix4.Identity;

            transform = Matrix4.Mult(transform, Matrix4.CreateTranslation(-pos.X, -pos.Y, 0));
            transform = Matrix4.Mult(transform, Matrix4.CreateScale((float)zoom, (float)zoom, 0f));

            GL.MultMatrix(ref transform);
        }
    }
}
