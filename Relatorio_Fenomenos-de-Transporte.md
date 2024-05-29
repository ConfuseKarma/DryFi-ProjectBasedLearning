# INSTRUÇÕES 

Apresentação e entrega de trabalho no moodle da disciplina:

• Apresentação do dispositivo e funcionamento: sensores, armazenamento dos dados, 

características do sistema e possíveis regulagens;

• Mecanismos envolvidos, mecanismos predominantes e desprezíveis;

• Dados obtidos da temperatura em função do tempo em malha aberta e depois de 

estabilizar em malha fechada;

• Explicação da curva obtida;

• Cálculo da superfície dissipada pelo resistor e do coeficiente global de transferência de 

calor. O coeficiente global de transferência de calor (U) é expresso em Energia/(tempo.

superfície. ∆Temperatura);

𝑞 = 𝑈. 𝐴𝑆𝑢𝑝𝑒𝑟𝑓í𝑐𝑖𝑒. ∆𝑇

• Aplicações;

• Sugestões de melhorias no sistema.

## Relatório: Fenômenos dos Transportes

### Apresentação do Dispositivo e Funcionamento

#### Sensores, Armazenamento dos Dados, Características do Sistema e Possíveis Regulagens

**Sensores:** 
O sistema utiliza o sensor de temperatura LM35, conhecido por sua precisão e confiabilidade. Este sensor fornece leituras de temperatura em tempo real, essencial para o controle do processo de secagem dos motores elétricos.

**Armazenamento dos Dados:**
Os dados capturados pelo LM35 são processados pelo microcontrolador ESP32 e enviados para a plataforma de back-end FIWARE, onde são armazenados e gerenciados. A FIWARE utiliza o Orion Context Broker para gerenciar os dados de contexto em tempo real e o STH-Comet para armazenar dados históricos.

**Características do Sistema:**
O sistema é um controle de malha fechada composto por um sensor LM35, um microcontrolador ESP32, e um transistor Mosfet IRF540. Os elementos resistivos de 180 ohm são utilizados para o aquecimento. O microcontrolador processa as leituras do sensor, calcula o erro em relação ao setpoint desejado, e ajusta a potência através do Mosfet para manter a temperatura ideal.

**Possíveis Regulagens:**
Regulagens possíveis incluem ajustes no setpoint de temperatura, calibração do sensor LM35, e parâmetros de controle no algoritmo do ESP32 para otimização do desempenho do sistema de controle térmico.

### Mecanismos Envolvidos, Mecanismos Predominantes e Desprezíveis

**Mecanismos Envolvidos:**
Os principais mecanismos de transferência de calor envolvidos são a condução, convecção e radiação.

- **Condução:** Transferência de calor através dos elementos resistivos e o material dos motores elétricos.
- **Convecção:** Transferência de calor entre a superfície dos motores e o ar dentro da estufa.
- **Radiação:** Emissão de energia térmica dos elementos aquecedores e superfícies aquecidas.

**Mecanismos Predominantes:**
- **Convecção** é o mecanismo predominante devido à interação constante entre o ar aquecido pela resistência e a superfície dos motores.
- **Condução** também é significativa nos elementos resistivos e no corpo dos motores, influenciando a uniformidade da temperatura.

**Mecanismos Desprezíveis:**
- **Radiação** pode ser considerada desprezível em comparação com condução e convecção, devido às temperaturas relativamente moderadas e às características dos materiais envolvidos.

### Dados Obtidos da Temperatura em Função do Tempo

#### Em Malha Aberta e Após Estabilização em Malha Fechada

**Malha Aberta:**
Os dados de temperatura em malha aberta mostram um aumento gradual até atingir um platô. Sem controle ativo, a temperatura eventualmente estabiliza quando o sistema atinge um equilíbrio térmico, mas pode variar significativamente devido a fatores externos.

**Malha Fechada:**
Após a implementação do controle em malha fechada, os dados mostram uma resposta mais rápida e precisa à mudança de temperatura. O sistema ajusta automaticamente a potência fornecida pelos elementos resistivos, mantendo a temperatura constante e próxima ao setpoint desejado com pequenas variações.

### Explicação da Curva Obtida

**Curva de Temperatura em Malha Aberta:**
A curva de temperatura em malha aberta apresenta uma fase inicial de aquecimento rápido, seguida por uma desaceleração à medida que se aproxima do equilíbrio térmico. Esta curva tende a ser irregular devido à falta de controle ativo.

**Curva de Temperatura em Malha Fechada:**
A curva em malha fechada é mais linear e estabiliza rapidamente ao redor do setpoint desejado. O controle ativo corrige desvios, resultando em uma curva mais estável e menos propensa a flutuações.

### Cálculo da Superfície Dissipada pelo Resistor e do Coeficiente Global de Transferência de Calor

**Fórmulas Utilizadas:**
\[ q = U \cdot A_{\text{Superfície}} \cdot \Delta T \]

**Dados Necessários:**
- \( A_{\text{Superfície}} \): Área da superfície do resistor em contato com o ar.
- \( \Delta T \): Diferença de temperatura entre o resistor e o ambiente.
- \( q \): Calor dissipado, obtido através da potência elétrica convertida em calor.

**Exemplo de Cálculo:**
1. **Área da Superfície (A_{\text{Superfície}}):** Supondo que o resistor é cilíndrico com raio \( r \) e comprimento \( l \):
\[ A_{\text{Superfície}} = 2 \pi r l + 2 \pi r^2 \]

2. **Diferença de Temperatura (\(\Delta T\)):** Supondo uma diferença de 50°C entre o resistor e o ambiente.

3. **Calor Dissipado (q):** Supondo que o resistor dissipa 10W de potência.
\[ U = \frac{q}{A_{\text{Superfície}} \cdot \Delta T} \]

Substituindo os valores:
\[ U = \frac{10}{(2 \pi \cdot r \cdot l + 2 \pi \cdot r^2) \cdot 50} \]

### Aplicações

O sistema pode ser aplicado em diversas áreas além da fabricação de motores elétricos, incluindo:
- **Secagem de materiais em processos industriais.**
- **Controle de temperatura em ambientes de armazenamento.**
- **Automatização de processos térmicos em linhas de produção.**

### Sugestões de Melhorias no Sistema

1. **Integração de Sensores Adicionais:**
   - Utilização de múltiplos sensores de temperatura para monitoramento em diferentes pontos da estufa, garantindo uma distribuição uniforme de calor.

2. **Algoritmos de Controle Avançados:**
   - Implementação de algoritmos de controle adaptativo ou preditivo para melhorar a resposta do sistema a variações de carga e condições ambientais.

3. **Isolamento Térmico:**
   - Melhorar o isolamento térmico da estufa para reduzir perdas de calor e aumentar a eficiência energética.

4. **Monitoramento de Umidade:**
   - Adicionar sensores de umidade para controlar e otimizar o processo de secagem, garantindo que a umidade residual nos motores seja mínima.

Essas melhorias podem contribuir para um controle térmico mais eficiente, aumento da qualidade dos motores elétricos produzidos, e redução de custos operacionais e energéticos.
