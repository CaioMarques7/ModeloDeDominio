Funcionalidade: Cálculo de IOF - (Imposto sobre Operações Financeiras)
	Para calcular o valor de IOF de uma operação financeira de qualquer valor
	Como parte de cálculos obrigatórios para realização de operação financeira
	Eu devo informar o valor base da operação em questão, prazo em dias para incidência do imposto e a taxa de IOF a ser cobrada, bem como aplicar alíquota de 0,38% ao valor da operação
	E obter o valor de IOF a ser cobrado

	NARRATIVA:
	A funcionalidade descrita tem como base fórmula matemática para obtenção do valor de IOF a ser cobrado.
	O valor de IOF a ser cobrado é apurado a partir da soma do valor de IOF no período com o valor de IOF adicional.
	A fórmula deve ser aplicada da seguinte forma:

	Passo 1: Divida a taxa de IOF informada por 365 dias e arredonde o resultado final em 4 casas decimais. Dessa forma será obtida a taxa diária.
	Passo 2: Multiplique a taxa diária pelo prazo em dias que foi informado. Dessa forma será obtida a taxa de IOF no período.
	Passo 3: Multiplique o valor base da operação pela taxa de IOF no período. Dessa forma será obtido o valor de IOF no período.
	Passo 4: Multiplique o valor base da operação pela alíquota. Dessa forma será obtido o valor de IOF adicional.
	Passo 5: Some o valor de IOF no período com o valor de IOF adicional. Dessa forma será obtido o valor de IOF a ser cobrado.
	
Esquema do Cenário: Cálculo de IOF
	Dado que uma operação financeira, onde há incidência de IOF, tem valor de R$ <Valor da Operação>
	E que essa operação tem prazo de <Prazo> dias
	E que a taxa de IOF é de <Taxa>%
	Quando for calculado o valor de IOF a ser cobrado
	Entao o valor de IOF a ser cobrado deve ser igual a R$ <IOF Calculado>

Exemplos: 
| Valor da Operação | Prazo | Taxa | IOF Calculado |
| 2491,32           | 105   | 1,31 | 951,19        |
| 413,47            | 57    | 0,5  | 34,57         |