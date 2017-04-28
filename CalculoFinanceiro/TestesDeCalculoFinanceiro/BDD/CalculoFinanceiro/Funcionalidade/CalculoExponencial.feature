Funcionalidade: Cálculo Financeiro com Correção Exponencial

Esquema do Cenário: Apuração do valor corrigido aplicando correção exponencial
	Dado que o valor de uma parcela para correção exponencial é R$ <Valor da Parcela>
	E que o período de apropriação para correção exponencial é <Dias de Apropriação>
	E que a taxa de juros para correção exponencial é <Taxa de Juros>%
	E que a periodicidade de apuração para correção exponencial é <Periodicidade>
	Quando eu calcular o valor corrigido aplicando correção exponencial
	Então o valor corrigido aplicando correção exponencial deve ser de R$ <Valor Corrigido>

Exemplos: 
| Valor da Parcela | Dias de Apropriação | Taxa de Juros | Periodicidade | Valor Corrigido |
| 1000,00          | 105                 | 8,00          | 1             | 1309,13         |