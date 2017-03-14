Funcionalidade: Cálculo de PIS
	Para calcular o valor de PIS de uma operação financeira de qualquer valor
	Como parte de cálculos obrigatórios para realização de operação financeira
	Eu devo informar o valor base da operação em questão e aplicar alíquota fixa de 1,65% sobre o mesmo
	E obter o valor de PIS a ser cobrado

	NARRATIVA:
	A funcionalidade descrita tem como base fórmula matemática para obtenção do valor de PIS a ser cobrado.
	O valor de PIS a ser cobrado é apurado a partir da multiplicação do valor base da operação pela alíquota fixa de 1,65%.

Esquema do Cenário: Calculando o valor de PIS
	Dado que uma operação financeira, onde há incidência de PIS, tem valor de R$ <Valor da Operação>
	Quando for calculado o valor de PIS a ser cobrado
	Entao o valor de PIS a ser cobrado deve ser igual a R$ <PIS Calculado>

Exemplos: 
| Valor da Operação | PIS Calculado |
| 2491,32           | 41,11         |