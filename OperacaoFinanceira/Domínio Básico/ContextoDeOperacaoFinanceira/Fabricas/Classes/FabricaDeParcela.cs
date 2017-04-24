﻿using ContextoDeOperacaoFinanceira.Agregacoes.Entidades;
using ContextoDeOperacaoFinanceira.Servicos.Dominio;
using Impostos.Fabricas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextoDeOperacaoFinanceira.Fabricas
{
    internal class FabricaDeParcela : IFabricaDeParcela
    {
        private readonly IFabricaDeImpostos _fabricaDeImpostos;

        /// <summary>
        /// Cria uma nova instância de <see cref="FabricaDeParcela"/>.
        /// </summary>
        /// <param name="fabricaDeImpostos">Fábrica de impostos incidentes na parcela.</param>
        public FabricaDeParcela(IFabricaDeImpostos fabricaDeImpostos)
        {
            _fabricaDeImpostos = fabricaDeImpostos;
        }

        /// <summary>
        /// Cria uma coleção vazia de parcelas.
        /// </summary>
        /// <returns>Coleção vazia de parcelas.</returns>
        public ICollection<IParcela> CriarColecaoVaziaDeParcelas()
        {
            return new HashSet<IParcela>();
        }

        /// <summary>
        /// Cria uma parcela para uma operação.
        /// </summary>
        /// <param name="operacao">Operação à qual a parcela será vinculada.</param>
        /// <param name="valorDaParcela">Valor da parcela.</param>
        /// <param name="dataDeVencimento">Data de vencimento da parcela.</param>
        /// <returns>Parcela criada.</returns>
        public IParcela CriarParcela(IOperacao operacao, decimal valorDaParcela, DateTime dataDeVencimento)
        {
            return new Parcela(operacao, valorDaParcela, dataDeVencimento, new ServicoDeImpostosPorOperacao(_fabricaDeImpostos, operacao.TipoDeOperacao));
        }
    }
}
