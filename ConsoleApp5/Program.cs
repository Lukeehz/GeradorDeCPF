namespace GeradorCPF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Class1 cpf = new Class1();

            string cpfCompleto = cpf.GerarCpfCompleto();

            Console.WriteLine(cpfCompleto);
        }
    }
}
