using System;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Window decoratedWindow = new HorizontalScrollBarDecorator(new VerticalScrollBarDecorator(new SimpleWindow()));
            decoratedWindow.Draw();

            Console.WriteLine(decoratedWindow.GetDescription());

        }
    }

    public interface Window
    {
        void Draw();
        string GetDescription();
    }

    public class SimpleWindow : Window
    {
        public void Draw()
        {
            //throw new NotImplementedException();
        }

        public string GetDescription()
        {
            return "Simple Window";
        }
    }

    public abstract class WindowDecorator : Window
    {
        protected Window _windowToBeDecorated;

        public WindowDecorator(Window windowToBeDecorated)
        {
            _windowToBeDecorated = windowToBeDecorated;
        }

        public virtual void Draw()
        {
            _windowToBeDecorated.Draw();
        }

        public virtual string GetDescription()
        {
            return _windowToBeDecorated.GetDescription();
        }
    }

    public class VerticalScrollBarDecorator : WindowDecorator
    {
        public VerticalScrollBarDecorator(Window windowToBeDecorated)
            : base(windowToBeDecorated)
        {

        }

        public override void Draw()
        {
            base.Draw();
            DrawVerticalScrollBar();
        }
        private void DrawVerticalScrollBar()
        {
        }

        public override string GetDescription()
        {
            return base.GetDescription() + ", including Vertical Scrollbars";
        }
    }

    public class HorizontalScrollBarDecorator : WindowDecorator
    {
        public HorizontalScrollBarDecorator(Window windowToBeDecorated)
            : base(windowToBeDecorated)
        {

        }

        public override void Draw()
        {
            base.Draw();
            DrawHorizontalScrollBar();
        }
        private void DrawHorizontalScrollBar()
        {
        }

        public override string GetDescription()
        {
            return base.GetDescription() + ", including Horizontal Scrollbars";
        }
    }
}
