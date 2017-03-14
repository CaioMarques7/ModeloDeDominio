Funcionalidade: Cálculo de COFINS - (Contribuição para o Financiamento da Seguridade Social)
	Para calcular o valor de COFINS de uma operação financeira de qualquer valor
	Como parte de cálculos obrigatórios para realização de operação financeira
	Eu devo informar o valor base da operação em questão e aplicar alíquota de 7,6% sobre o mesmo
	E obter o valor de COFINS a ser cobrado

	NARRATIVA:
	A funcionalidade descrita tem como base fórmula matemática para obtenção do valor de COFINS a ser cobrado.
	O valor de COFINS a ser cobrado é apurado a partir da multiplicação do valor base da operação pela alíquota fixa de 7,6%.

Esquema do Cenário: Calculando o valor de COFINS
	Dado que uma operação financeira, onde há incidência de COFINS, tem valor de R$ <Valor da Operação>
	Quando for calculado o valor de COFINS a ser cobrado
	Entao o valor de COFINS a ser cobrado deve ser igual a R$ <COFINS Calculado>

Exemplos: 
| Valor da Operação | COFINS Calculado |
| 2491,32           | 189,34           |