Funcionalidade: Operação financeira

Contexto: Realização de operação financeira
	Dado que as parcelas abaixo fazem parte de uma operação financeira
	| Valor da Parcela | Data de Vencimento |
	| 540,17           | 03/11/2017         |
	| 980,06           | 03/12/2017         |

Esquema do Cenário: Calculando os impostos que incidem sobre a operação financeira
	E que o tipo dessa operação é <Tipo da Operação>
	E que a data dessa operação é <Data da Operação>
	E a taxa de IOF dessa operação é <Taxa de IOF>%
	E a taxa de juros dessa operação é <Taxa de Juros>%
	Quando eu calcular os impostos da operação
	Então o valor de IOF apurado deve ser de R$ <IOF Apurado>
	E o valor de PIS apurado deve ser de R$ <PIS Apurado>
	E o valor de COFINS apurado deve ser de R$ <COFINS Apurado>

Exemplos: 
| Data da Operação | Tipo da Operação | Taxa de IOF | Taxa de Juros | IOF Apurado | PIS Apurado | COFINS Apurado |
| 03/04/2017       | 0                | 1,5         | 14,2441       | 20,31       | 25,08       | 115,53         |
| 03/04/2017       | 1                | 1,5         | 13,2581       | 20,31       | 25,08       | 0,00           |
| 03/04/2017       | 2                | 1,5         | 10,5410       | 0,00        | 25,08       | 115,53         |
| 10/09/2017       | 0                | 0,61        | 9,1447        | 7,67        | 25,08       | 115,53         |
| 10/09/2017       | 1                | 0,61        | 3,14          | 7,67        | 25,08       | 0,00           |
| 10/09/2017       | 2                | 0,61        | 0,71          | 0,00        | 25,08       | 115,53         |
| 01/10/2017       | 0                | 1,2         | 1,99          | 8,40        | 25,08       | 115,53         |
| 01/10/2017       | 1                | 1,2         | 24,5617       | 8,40        | 25,08       | 0,00           |
| 01/10/2017       | 2                | 1,2         | 5,29          | 0,00        | 25,08       | 115,53         |
| 09/07/2017       | 0                | 0,24        | 34,21         | 7,22        | 25,08       | 115,53         |
| 09/07/2017       | 1                | 0,24        | 1,55          | 7,22        | 25,08       | 0,00           |
| 09/07/2017       | 2                | 0,24        | 7,9854        | 0,00        | 25,08       | 115,53         |