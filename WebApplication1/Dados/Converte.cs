using System;
using Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class Converte
    {
        public static Equipamento ToEquipamento(EquipamentoVO equipamentoVO)
        {
            return new Equipamento()
            {
                id = equipamentoVO.Id,
                nome = equipamentoVO.Nome,
                valor = equipamentoVO.Valor,
                DataCadastro = equipamentoVO.DataCadastro
            };
        }
        public static EquipamentoVO ToEquipamentoVO(Equipamento equipamento)
        {
            return new EquipamentoVO()
            {
                Id = equipamento.id,
                Nome = equipamento.nome,
                Valor = (decimal)equipamento.valor,
                DataCadastro = (DateTime)equipamento.DataCadastro
            };
        }

    }
}
