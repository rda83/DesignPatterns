/*
* GOF #13
* ChainOfResponsibility (Цепочка обязанностей - паттерн поведения объектов.)
* Позволяет избежать привязки отправителя запроса к его получателю, давая шанс обработать запрос нескольким объектам.
* Связывает объекты - получатели в цепочку и передает запрос вдоль этой цепочки, пока его не о работают.
* 04/08/2019
*/

using System;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {

            var GraphicRenderer_PNG = new PngRenderer();
            var GraphicRenderer_JPEG = new JpegRenderer(GraphicRenderer_PNG);
            var GraphicRenderer = new BmpRenderer(GraphicRenderer_JPEG);

            var PNG_Object = new GraphicDataContainer(DataFormat.PNG, "PNG data");
            var JPEG_Object = new GraphicDataContainer(DataFormat.JPEG, "JPEG data");
            var BMP_Object = new GraphicDataContainer(DataFormat.BMP, "BMP data");

            GraphicRenderer.Hanble(BMP_Object);
            GraphicRenderer.Hanble(JPEG_Object);
            GraphicRenderer.Hanble(PNG_Object);

            Console.ReadLine();

        }
    }

    public enum DataFormat
    {
        BMP,
        JPEG,
        PNG
    }

    public class GraphicDataContainer
    {
        public DataFormat Format { get; private set; }
        public string Data { get; private set; }

        public GraphicDataContainer(DataFormat format, string data)
        {
            this.Format = format;
            this.Data = data;
        }
    }

    public abstract class Renderer
    {
        protected Renderer Next { private get; set; }
        protected DataFormat Format { get; set; }

        public abstract void Draw(GraphicDataContainer GDC);

        public void Hanble(GraphicDataContainer GDC)
        {
            if (GDC.Format == Format)
            {
                Draw(GDC);
            }
            else if (Next != null)
            {
                Next.Hanble(GDC);
            }
        }
    }

    public class BmpRenderer : Renderer
    {
        public BmpRenderer(Renderer next = null)
        {
            this.Next = next;
            this.Format = DataFormat.BMP;
        }

        public override void Draw(GraphicDataContainer GDC)
        {
            Console.Write("BMP renderer -> ");
            Console.WriteLine(GDC.Data);
        }
    }

    public class JpegRenderer : Renderer
    {
        public JpegRenderer(Renderer next = null)
        {
            this.Next = next;
            this.Format = DataFormat.JPEG;
        }

        public override void Draw(GraphicDataContainer GDC)
        {
            Console.Write("JPEG renderer -> ");
            Console.WriteLine(GDC.Data);
        }
    }

    public class PngRenderer : Renderer
    {
        public PngRenderer(Renderer next = null)
        {
            this.Next = next;
            this.Format = DataFormat.PNG;
        }

        public override void Draw(GraphicDataContainer GDC)
        {
            Console.Write("PNG renderer -> ");
            Console.WriteLine(GDC.Data);
        }
    }
}
