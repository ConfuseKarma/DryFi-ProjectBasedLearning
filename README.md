# DryFi: Aplicação de IoT no monitoramento de estufas utilizadas na construção de motores elétricos

![PBL](https://github.com/ConfuseKarma/DryFi-ProjectBasedLearning/assets/145780136/0b524d20-9c2a-4933-a8b1-2ce07323772f)

## Grupo:
- Aparecida Joana Moreto, RA: 082210001
- Eduardo Accacio Spedine Toledo, RA: 081220018
- Guilherme Rodrigues dos Santos, RA: 081220010
- Kauê de Souza Silva, RA: 081220003
- Marcos Felipe Correa dos Santos, RA: 081220020

## Objetivo:
O projeto DryFi visa desenvolver e implementar um sistema de controle e monitoramento IoT para estufas de secagem de motores elétricos. A plataforma de back-end FIWARE será utilizada para processamento e armazenamento das informações de contexto, com o objetivo de otimizar o processo global de fabricação, garantir a precisão na regulação de temperatura, permitir o monitoramento remoto em tempo real e melhorar a eficiência operacional, resultando em motores elétricos de alta qualidade e consistência em todas as unidades da empresa. O sistema será suportado por uma plataforma na web desenvolvida em Asp.net MVC, que fornecerá suporte aos cadastros e exibirá os dados no formato de consultas e dashboards.

## Descrição do Projeto:
A produção global de motores elétricos enfrenta desafios críticos no controle e monitoramento da temperatura durante o processo de secagem do enrolamento dos motores. A qualidade e durabilidade desses motores dependem diretamente do tratamento térmico adequado durante esta fase de fabricação. A proposta do DryFi é implementar um sistema de controle em malha fechada, utilizando sensores de temperatura LM35, microcontroladores ESP32 e transistores Mosfet IRF540 para garantir um aquecimento controlado e eficiente.

A implementação de dispositivos IoT é essencial para permitir o monitoramento remoto e em tempo real das condições térmicas nas estufas de secagem, independentemente da localização das instalações. Isso possibilitará que engenheiros e operadores monitorem e controlem os parâmetros térmicos essenciais, garantindo a consistência e qualidade dos enrolamentos dos motores elétricos.

As informações geradas pelo dispositivo de IoT serão gerenciadas por uma plataforma de back-end aberta, FIWARE, que disponibiliza um conjunto de APIs especializadas para consumo pelo front-end.

O projeto está alinhado com os Objetivos de Desenvolvimento Sustentável (ODS), especialmente:

- ODS 9: Indústria, inovação e infraestrutura.
- ODS 12: Consumo e produção responsáveis.

Esses ODS destacam a importância da inovação na indústria de motores elétricos, assim como a necessidade de práticas de produção responsáveis e sustentáveis.

## Critérios de Aceitação de Cada Disciplina:

### Sistemas Embarcados (Fábio Cabrini):
1. Diagrama completo da arquitetura, incluindo as camadas de IoT, back-end e front-end.
2. Implementação de um servidor FIWARE em ambiente de nuvem. - https://github.com/fabiocabrini/fiware
3. Visualização das informações do sensor em tempo de execução consumidas através da API do Orion Context Broker.
4. Visualização das informações históricas através do consumo da API do STH-Comet.

### Fenômeno dos Transportes (Ricardo Calvo Costa):
- Análise dos mecanismos de transferência de calor envolvidos.
- Simulação e obtenção de dados do estudo de transferência de calor para a obtenção do coeficiente global de transferência de calor do sistema.

### Controle e Automação (Marcones Brito):
- Relatório detalhado de todas as etapas do desenvolvimento.
- Descrição e validação do sistema utilizando simulador.

### Linguagem de Programação I (Eduardo Rosalem Marcelino):
- Desenvolvimento de uma aplicação Web em Asp.net Core MVC que dê suporte ao sistema desenvolvido pelas demais disciplinas.
- Implementação de pelo menos 3 CRUDs com relacionamentos, manipulação de imagens, área "Sobre" e duas telas de consulta com filtros.
- Utilização de Ajax em pelo menos duas partes do sistema.
- Desenvolvimento de pelo menos 2 Dashboards.
- Aplicação dos conceitos e boas práticas de programação ensinados na disciplina.

Este relatório será atualizado conforme o andamento do projeto.
