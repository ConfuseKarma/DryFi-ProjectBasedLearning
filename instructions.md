# DryFi: Aplicação de IoT no monitoramento de estufas utilizadas na construção de motores elétricos

## Objetivo:
Desenvolver e implementar um sistema de controle e monitoramento IoT para as estufas de secagem de motores elétricos, utilizando a plataforma de back-end FIWARE para realizar o processamento e armazenamento das informações de contexto, visando otimizar o processo global de fabricação, assegurando precisão na regulação de temperatura, monitoramento remoto em tempo real e aprimoramento da eficiência operacional, resultando em motores elétricos de alta qualidade e consistência em todas as unidades da empresa. O sistema proposto será apoiado por uma plataforma na Web desenvolvida em Asp.net MVC que dará suporte aos cadastros com exibição dos dados no formato de consultas e dashboards.

## Descrição da Proposta:
Em um cenário global de produção de motores elétricos, uma empresa líder na indústria enfrenta um desafio crítico relacionado ao controle e monitoramento de temperatura em suas estufas de secagem do enrolamento dos motores. Essas estufas desempenham um papel essencial na fase de fabricação, onde o correto tratamento térmico é crucial para garantir a qualidade e durabilidade dos motores elétricos produzidos em diversas unidades ao redor do mundo.

A área de atuação dessa empresa abrange a fabricação de motores elétricos destinados a uma variedade de aplicações industriais, comerciais e residenciais. A eficiência e confiabilidade desses motores estão diretamente ligadas à precisão no controle térmico durante o processo de secagem do enrolamento.

A necessidade premente da indústria é estabelecer um sistema avançado de controle e monitoramento de temperatura nas estufas de secagem. Para atender a essa demanda, propõe-se a implementação de um sistema de controle em malha fechada mostrado na figura 1, onde elementos essenciais incluem um sensor de temperatura LM35, um microcontrolador ESP32 e um transistor Mosfet IRF540. Além disso, a estufa utiliza elementos resistivos de 180 ohm para viabilizar o aquecimento.

![pbl image](https://github.com/ConfuseKarma/DryFi-ProjectBasedLearning/assets/145780136/c67884b3-7a04-48d6-a9e5-190e555915e9)


O sensor de temperatura LM35 desempenha um papel crucial ao fornecer leituras precisas e em tempo real da temperatura do enrolamento dos motores. O microcontrolador ESP32 age como o cérebro do sistema, processando dados, calculando erros em relação aos Setpoints desejados e tomando decisões de controle. O transistor Mosfet IRF540 atua como o atuador, regulando a potência fornecida aos elementos resistivos para assegurar um aquecimento controlado e eficiente.

A implementação de dispositivos IoT é imperativa, permitindo o monitoramento remoto e em tempo real das condições térmicas nas estufas de secagem em unidades distribuídas globalmente. Essa abordagem inovadora possibilita que os engenheiros e operadores monitorem e controlem os parâmetros térmicos essenciais, garantindo a consistência e qualidade dos enrolamentos dos motores elétricos, independentemente da localização das instalações.

O monitoramento e o armazenamento das informações geradas pelo dispositivo de IoT serão gerenciadas por uma plataforma de back-end aberta, denominada FIWARE. O FIWARE disponibiliza um conjunto de API especializada que serão consumidas pelo front-end.

A proposta é alinhada aos seguintes ODS (Objetivos de Desenvolvimento Sustentável):

- ODS 9: Indústria, inovação e infraestrutura. O projeto pode promover a inovação e o desenvolvimento tecnológico na indústria de motores elétricos, aumentando a produtividade, a qualidade e a competitividade do setor, e também melhorando a infraestrutura de comunicação e informação, através do uso de IoT e plataformas web.
  
- ODS 12: Consumo e produção responsáveis. O projeto pode estimular o consumo e a produção responsáveis de recursos naturais, materiais e energia, adotando práticas de gestão ambiental, eficiência energética, reciclagem e redução de resíduos, e também sensibilizando os consumidores e os produtores sobre a importância da sustentabilidade.

Portanto, a proposta desse sistema de controle térmico em malha fechada, utilizando dispositivos IoT, não apenas atende às necessidades críticas da empresa na produção de motores elétricos, mas também representa uma solução estratégica para otimizar os processos de secagem, melhorando a eficiência operacional e garantindo a excelência na fabricação dos motores elétricos em escala global.

## Critérios de Aceitação de Cada Disciplina:

### Sistemas Embarcados (Fábio Cabrini)
1. Diagrama completo da arquitetura incluindo as camadas de IoT, back-end e front-end.
2. Implementação de um servidor FIWARE em ambiente de cloud (nuvem).
3. Visualização das informações do sensor em tempo de execução consumidas através da API do Orion Context Broker.
4. Visualização das informações históricas através do consumo da API do STH-Comet (Lembrando que o gráfico deve apresentar as unidades de medidas correspondentes ao projeto).

### Fenômeno dos Transportes (Ricardo Calvo Costa)
Análise dos mecanismos de transferência de calor envolvidos. Simulação e obtenção de dados do estudo de transferência de calor para a obtenção do coeficiente global de transferência de calor do sistema.

### Controle e Automação (Marcones Brito)
Relatório com descrição de todas as etapas, sendo elas: Introdução, desenvolvimento da análise de circuitos e obtenção das equações, desenvolvimento do software, descrição detalhada do software, aplicação do software para resolver as equações obtidas e validação do sistema utilizando simulador.

### Linguagem de Programação I (Eduardo Rosalem Marcelino)
- Desenvolvimento de uma aplicação Web em Asp.net Core MVC que dê suporte ao sistema desenvolvido pelas demais disciplinas. Este sistema envolve o desenvolvimento de cadastros, dashboards, telas de consulta envolvendo os conteúdos ministrados na disciplina.
- O programa deve possuir as seguintes características:
  - Pelo menos 3 CRUDs, sendo que todos deverão possuir relacionamento com outra tabela. As listagens de tabelas que possuam relacionamento devem fazer o "join" e exibir o campo relacionado.
  - Ao menos um CRUD deverá se utilizar das APIs fornecidas no seguinte endereço: [https://github.com/fabiocabrini/fiware](https://github.com/fabiocabrini/fiware).
  - Utilização de herança nas classes, como explicado em aula.
  - Ao menos 1 dos cadastros deverá manipular imagem (ex: foto do funcionário, do produto).
  - Área "Sobre", exibindo informações acerca do sistema, além do nome e o RA dos alunos.
  - Duas telas de consulta que permitam filtros para exibição de dados. Os dados deverão ser consultados nas APIs: [https://github.com/fabiocabrini/fiware](https://github.com/fabiocabrini/fiware).
  - Utilização de Ajax em pelo menos duas partes do sistema.
  - O sistema deve possuir uma página inicial (Home).
  - Ao menos 2 Dashboards, que podem se valer dos mesmos filtros criados nas telas de consulta.
  - Todos os conceitos e boas práticas de programação que já foram tratadas em outras disciplinas devem ser aplicadas aqui, como identação do código, controle de exceção, orientação a objetos, complexidade ciclomática, etc.

