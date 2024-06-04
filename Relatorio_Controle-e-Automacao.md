## Controle e Automação ##

Relatório com descrição de todas as etapas, sendo elas: 

Introdução, desenvolvimento da análise de circuitos e obtenção das equações, desenvolvimento do software, descrição detalhada do software, aplicação do software para resolver as equações obtidas e validação do sistema utilizando simulador.


### Link do Relatório: ###

### - [docs.google.com/document/d/1CMKNKdv7-q9Bkq4tbYM7Ng_gBm2sA2VbT95HF3UqPbA/edit?usp=sharing](https://docs.google.com/document/d/1CMKNKdv7-q9Bkq4tbYM7Ng_gBm2sA2VbT95HF,3UqPbA/edit?usp=sharing)](https://docs.google.com/document/d/1-D07BaICdD99yDaTF9m1ZUXcMX2q3nHi3IJGzinDZJE/edit) ###

(Faça Login se quiser editar)

### Link úteis para consulta: ###

### - [embarcados.com.br/controlador-proporcional-em-sistemas-de-segunda-ordem](https://embarcados.com.br/controlador-proporcional-em-sistemas-de-segunda-ordem/)/ 

### Como obter equações para o circuito dentro do contexto de Controle e Automação?

Para obter as equações deste circuito e analisá-lo dentro do contexto de controle e automação, é necessário entender a dinâmica do sistema e modelá-lo matematicamente. Aqui estão os seguintes passos:

1. **Identificação dos Componentes do Circuito:**
   - Identificar os elementos principais do circuito, incluindo o sensor de temperatura LM35, o microcontrolador ESP32, o transistor Mosfet IRF540 e os elementos resistivos das estufas de secagem.

2. **Análise dos Componentes e Conexões:**
   - Analisar o funcionamento de cada componente do circuito e como eles estão conectados entre si. Isso envolve entender o comportamento do sensor de temperatura, o controle de potência pelo transistor Mosfet, e como o microcontrolador processa os dados do sensor e controla o sistema.

3. **Formulação do Modelo Matemático:**
   - Utilizar princípios de física e eletrônica para formular as equações que descrevem o comportamento do sistema. Isso pode envolver equações de transferência, equações diferenciais ou outras formas de modelagem, dependendo da complexidade do sistema e dos componentes envolvidos.

4. **Análise da Dinâmica do Sistema:**
   - Analisar a dinâmica do sistema modelado para entender como ele responde a diferentes entradas e condições iniciais. Isso pode incluir a determinação de constantes de tempo, resposta transitória e estabilidade do sistema.

5. **Projeto e Implementação do Controlador:**
   - Com base no modelo matemático obtido, projetar e implementar um controlador que seja capaz de regular a temperatura nas estufas de secagem de acordo com as especificações desejadas. Isso pode envolver técnicas de controle clássicas, como controle PID, ou técnicas mais avançadas, dependendo dos requisitos do sistema.

Ao seguir esses passos, é possível obter as equações que descrevem o comportamento do sistema e utilizá-las para projetar um controlador eficiente que atenda às necessidades de controle de temperatura nas estufas de secagem dos enrolamentos dos motores elétricos. É importante ressaltar que o conhecimento em controle e automação será fundamental para realizar essa análise e modelagem de forma adequada.


-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


# Formulação da Equação para o Controle Térmico em Malha Fechada #

Para formular as equações que descrevem o comportamento do sistema de controle térmico em malha fechada proposto no projeto, precisamos considerar os componentes principais do sistema e suas interações. 

Dado o sistema descrito, podemos começar com algumas suposições e simplificações:

1. **Sensor de Temperatura LM35:** Supomos que o sensor LM35 forneça uma leitura direta e precisa da temperatura ambiente.

2. **Microcontrolador ESP32:** O ESP32 coleta os dados do sensor de temperatura e calcula o erro entre a temperatura medida e o setpoint desejado. Ele então usa esse erro para controlar a potência fornecida ao aquecedor (elementos resistivos).

3. **Transistor Mosfet IRF540:** O transistor Mosfet é usado para controlar a potência entregue aos elementos resistivos, modulando a corrente que passa por eles.

4. **Elementos Resistivos:** Eles funcionam como o sistema de aquecimento das estufas de secagem.

Com base nessas suposições, podemos começar a formular as equações. Vamos designar:

- \( T \) como a temperatura medida pelo sensor LM35.
- \( Ts \) como o setpoint desejado de temperatura.
- \( e \) como o erro entre a temperatura medida e o setpoint: \( e = Ts - T \). 
- \( P \) como a potência fornecida ao aquecedor.

Agora, para manter a temperatura dentro de uma faixa específica, podemos usar um controlador proporcional (P), integral (I) e derivativo (D), conhecido como controlador PID. Neste caso, vamos começar com uma abordagem proporcional, que é mais simples. A potência fornecida ao aquecedor será proporcional ao erro.

Então, uma possível equação seria:

\[ P = Kp × e \]

Onde \( Kp \) é o ganho proporcional do controlador.

Essa é uma equação muito simplificada. Para uma implementação mais robusta, você precisará considerar outros fatores, como a dinâmica térmica do sistema, a resposta do sensor de temperatura, a inércia térmica dos elementos de aquecimento, entre outros. Além disso, para uma abordagem PID completa, você também incluiria os termos integral e derivativo para lidar com o erro acumulado e a taxa de mudança do erro, respectivamente.

Essa equação simples serve como um ponto de partida e pode ser refinada à medida que você avança no projeto e na análise do sistema.
