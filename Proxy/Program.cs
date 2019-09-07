/*
* GOF #12
* Proxy (Заместитель - паттерн, структурирующий объекты.)
* Является суррогатом другого объекта и контролирует доступ к нему.
* 22/08/2019
*/

using System;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            var proxy = new ImageProxy("1.png");
            var fileName = proxy.GetFileName();
            proxy.Draw();

            Console.ReadLine();
        }
    }

    abstract class Graphic
    {
        protected String FileName;

        public abstract void Draw();

        public String GetFileName()
        {
            return FileName;
        }
    }

    class Image : Graphic
    {
        public Image(String fileName)
        {
            FileName = fileName;
        }

        public override void Draw()
        {
            Console.WriteLine("draw " + FileName);
        }
    }

    class ImageProxy : Graphic
    {
        Image _image;

        public ImageProxy(String fileName)
        {
            FileName = fileName;
        }

        public override void Draw()
        {
            GetImage().Draw();
        }

        private Image GetImage()
        {
            return _image ?? (_image = new Image(FileName));
        }
    }
}
