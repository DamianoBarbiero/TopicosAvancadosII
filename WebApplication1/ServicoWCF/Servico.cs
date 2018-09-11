using System;
using Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace ServicoWCF
{
    // OBSERVAÇÃO: Você pode usar o comando "Renomear" no menu "Refatorar" para alterar o nome da classe "Service1" no arquivo de código e configuração ao mesmo tempo.
    public class Servico : IServico
    {
        public void DoWork()
        {
        }

        public bool Inserir(EquipamentoVO equipamentoVO)
        {
            return new Dados.Dados().Inserir(equipamentoVO);
        }
    }
}
