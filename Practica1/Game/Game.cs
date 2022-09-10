using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Graphics.OpenGL;
using OpenTK;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using Practica1.Game;
using System.Windows.Input;

namespace BasicOpenTK
{
    public class Game : GameWindow
    {
        Figura a, b, c;
        public Game()
            : base(GameWindowSettings.Default, NativeWindowSettings.Default)
        {
            this.CenterWindow(new Vector2i(1366, 768));

        }
        protected override void OnUpdateFrame(FrameEventArgs args)
        {
          
            
            base.OnUpdateFrame(args);
        }
        protected override void OnLoad()
        {
            GL.ClearColor(new Color4(0.3f, 0.4f, 0.5f, 1f)); //Fondo de color de la ventana

            a = new Figura(new Punto(-0.5f, 0.25f, 0f), Color.rosa);
            b = new Figura(new Punto(), Color.verde);
            c = new Figura(new Punto(0.5f, -0.25f, 0f), Color.naranja);
           
            base.OnLoad();
        }

        protected override void OnUnload()
        {

            a.delete(); 
            b.delete();
            c.delete();

            base.OnUnload();
        }
        protected override void OnResize(ResizeEventArgs e)
        {
            GL.Viewport(0, 0, e.Width, e.Height);
            base.OnResize(e);
        }


        protected override void OnRenderFrame(FrameEventArgs args)
        {

            GL.Clear(ClearBufferMask.ColorBufferBit);//limpiar pantalla
            a.DibujarFigura();
            b.DibujarFigura();
            c.DibujarFigura();

            KeyboardState input = KeyboardState;

            if (input.IsKeyDown(Keys.W))
                a.Mover(Keys.W);
            else if (input.IsKeyDown(Keys.S))
                a.Mover(Keys.S);
            else  if(input.IsKeyDown(Keys.D))
                a.Mover(Keys.D);
            else if(input.IsKeyDown(Keys.A))
                a.Mover(Keys.A);            
            

            
            
            this.Context.SwapBuffers();
            base.OnRenderFrame(args);
        }


    }
}
