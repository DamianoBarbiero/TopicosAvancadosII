using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class Dados
    {
        public bool Inserir(EquipamentoVO equipamentoVO)
        {
            EquipamentoEntities context = new EquipamentoEntities();
            context.Equipamento.Add(Converte.ToEquipamento(equipamentoVO));
            int retorno = context.SaveChanges();
            return retorno == 1;
        }
    }
}
