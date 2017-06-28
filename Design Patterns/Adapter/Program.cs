using System;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client(new Adapter());
            client.MakeRequest();
        }
    }

    public class Client
    {
        private ITarget _target;

        public Client(ITarget target)
        {
            _target = target;
        }

        public void MakeRequest()
        {
            _target.MethodA();
        }
    }


    public interface ITarget
    {
        void MethodA();
    }


    public class Adaptee
    {
        public void MethodB()
        {
            Console.WriteLine("MethodB called");
        }
    }


    public class Adapter : ITarget
    {
        Adaptee _adaptee = new Adaptee();

        public void MethodA()
        {
            _adaptee.MethodB();
        }
    }
}
