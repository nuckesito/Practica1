using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.GraphicsLibraryFramework;
namespace Practica1.Game
{
    public class Figura
    {

        public string Color { get; set; }
        public Punto Coordenada {get;set;}
        private float[] Vertices { get; set; }
        private int CtrlBufVer { get; set; }
        private int CtrlProgSomb { get; set; }
        private int CtrlArrayVer { get; set; }
        private int Visible { get; set; }

        public Figura(Punto p, string c)
        {
            this.Coordenada = p;
            
            this.Color = c;
            this.Visible = 1;

            CargarFigura();

        }

        public void CargarFigura()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.DeleteBuffer(this.CtrlBufVer);

            GL.UseProgram(0);
            GL.DeleteProgram(this.CtrlProgSomb);

            
            Vertices = new float[]
            {
                Coordenada.x,Coordenada.y+0.25f,Coordenada.z,
                Coordenada.x+0.25f,Coordenada.y-0.25f,Coordenada.z,
                Coordenada.x-0.25f,Coordenada.y-0.25f,Coordenada.z
            };

            this.CtrlBufVer = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, this.CtrlBufVer);
            GL.BufferData(BufferTarget.ArrayBuffer, Vertices.Length * sizeof(float), Vertices, BufferUsageHint.StaticDraw);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);

            this.CtrlArrayVer = GL.GenVertexArray();
            GL.BindVertexArray(this.CtrlArrayVer);

            GL.BindBuffer(BufferTarget.ArrayBuffer, this.CtrlBufVer);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            GL.BindVertexArray(0);

            string vertexShaderCode =
                @"
                #version 330 core

                layout (location = 0) in vec3 aPosition;

                out vec4 vertexColor;
                
                void main()
                {
                    gl_Position = vec4(aPosition, 1.0);
                    
                }";

            string pixelShaderCode =
                @"
                #version 330 core
                
                out vec4 FragColor;                
                
                void main()
                { 
                    FragColor = vec4(" + $"{this.Color}" + @");
                }
                ";
            int vertexShaderObject = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vertexShaderObject, vertexShaderCode);
            GL.CompileShader(vertexShaderObject);

            int pixelShaderObject = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(pixelShaderObject, pixelShaderCode);
            GL.CompileShader(pixelShaderObject);

            this.CtrlProgSomb = GL.CreateProgram();

            GL.AttachShader(this.CtrlProgSomb, vertexShaderObject);
            GL.AttachShader(this.CtrlProgSomb, pixelShaderObject);

            GL.LinkProgram(this.CtrlProgSomb);

            GL.DetachShader(this.CtrlProgSomb, vertexShaderObject);
            GL.DetachShader(this.CtrlProgSomb, pixelShaderObject);

            GL.DeleteShader(vertexShaderObject);
            GL.DeleteShader(pixelShaderObject);
        }
        public void DibujarFigura()
        {
            if (Visible == 1)
            {
                
                GL.UseProgram(this.CtrlProgSomb);
                GL.BindVertexArray(this.CtrlArrayVer);


                GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
            }
        }

        public void DibujarFigura(float x, float y)
        {
            /*if (this.Visible == true)
            {
                GL.UseProgram(this.CtrlProgSomb);
                GL.BindVertexArray(this.CtrlArrayVer);
                GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
            }*/
        }

        public void BorrarFigura()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.DeleteBuffer(this.CtrlBufVer);

            GL.UseProgram(0);
            GL.DeleteProgram(this.CtrlProgSomb);

            //this.Visible = -1;

        }

        public void delete()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.DeleteBuffer(this.CtrlBufVer);

            GL.UseProgram(0);
            GL.DeleteProgram(this.CtrlProgSomb);
        }

        public bool esVisible(Figura a)
        {
            return a.Visible == 1;
        }

        public void ToggleMostrar() 
        {
            this.Visible = this.Visible * (-1);
        }

        public void Mover(Keys k)
        {
            
            switch(k)
            {
                case Keys.W:
                    MovArriba();
                    CargarFigura();
                    break;
      
                case Keys.D:
                    MovDerecha();
                    CargarFigura();
                    break;

                case Keys.S:
                    MovAbajo();
                    CargarFigura();
                    break;

                case Keys.A:
                    MovIzquierda();
                    CargarFigura();
                    break;

                case Keys.Escape:
                    break;

                case Keys.M:

                    break;
                default:
                    break;
            }
        }

        private void MovArriba()
        {
            Coordenada.MoverArriba();
        }

        private void MovDerecha()
        {
            Coordenada.MoverDerecha();
        }
        private void MovAbajo()
        {
            Coordenada.MoverAbajo();
        }

        private void MovIzquierda()
        {
            Coordenada.MoverIzquierda();
        }
    }
}
