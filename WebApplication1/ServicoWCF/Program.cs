using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ServicoWCF
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(Servico), new Uri[] { });
            host.Open();
            Console.WriteLine("Em andamento");
            Console.WriteLine("Para Sair, tecle algo.");
            Console.ReadKey();
            host.Close();
        }
    }
}
