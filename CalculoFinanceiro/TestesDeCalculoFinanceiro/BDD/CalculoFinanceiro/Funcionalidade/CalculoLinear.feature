﻿Funcionalidade: Cálculo Financeiro com Correção Linear

Esquema do Cenário: Apuração do valor corrigido aplicando correção linear
	Dado que o valor de uma parcela para correção linear é R$ <Valor da Parcela>
	E que o período de apropriação para correção linear é <Dias de Apropriação>
	E que a taxa de juros para correção linear é <Taxa de Juros>%
	E que a periodicidade de apuração para correção linear é <Periodicidade>
	Quando eu calcular o valor corrigido aplicando correção linear
	Então o valor corrigido aplicando correção linear deve ser de R$ <Valor Corrigido>

Exemplos: 
| Valor da Parcela | Dias de Apropriação | Taxa de Juros | Periodicidade | Valor Corrigido |
| 1000,00          | 105                 | 8,00          | 1             | 1310,10         |