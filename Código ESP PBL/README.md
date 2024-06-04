
README - Projeto de Monitoramento de Temperatura com ESP32
Descrição
Este projeto é um sketch para ESP32 que permite a conexão a uma rede Wi-Fi, o envio e recebimento de mensagens via MQTT e o monitoramento de temperatura usando um sensor analógico. O sistema é configurado para enviar os dados de temperatura lidos para um broker MQTT.

Funcionalidades
Conexão Wi-Fi:

Conecta-se à rede Wi-Fi especificada.
Exibe o status da conexão e o endereço IP obtido.
Configuração MQTT:

Configura a conexão com um broker MQTT utilizando as credenciais fornecidas.
Define os tópicos para publicação e subscrição.
Implementa um callback para tratar mensagens recebidas.
Monitoramento de Temperatura:

Lê valores de um sensor analógico de temperatura.
Converte o valor lido para uma temperatura.
Envia o valor da temperatura ao broker MQTT.
Configurações
Wi-Fi:

SSID: Nome da rede Wi-Fi.
PASSWORD: Senha da rede Wi-Fi.
MQTT:

BROKER_MQTT: Endereço IP do broker MQTT.
BROKER_PORT: Porta do broker MQTT.
TOPICO_SUBSCRIBE: Tópico para receber comandos.
TOPICO_PUBLISH_1: Tópico para enviar dados.
TOPICO_PUBLISH_2: Tópico para enviar temperatura.
ID_MQTT: ID do cliente MQTT.
Hardware:

potPin: Pino do sensor de temperatura.
Estrutura do Código
Funções de Inicialização:

initSerial(): Inicializa a comunicação serial.
initWiFi(): Configura a conexão Wi-Fi.
initMQTT(): Configura a conexão MQTT e define o callback.
Setup:

setup(): Configura o hardware, inicializa a comunicação serial, Wi-Fi, MQTT, e publica uma mensagem inicial.
Loop Principal:

loop(): Verifica conexões Wi-Fi e MQTT, lê a temperatura e envia ao broker MQTT.
Funções Auxiliares:

reconectWiFi(): Reestabelece a conexão Wi-Fi, se necessário.
mqtt_callback(): Trata mensagens recebidas via MQTT.
VerificaConexoesWiFIEMQTT(): Verifica e reestabelece conexões Wi-Fi e MQTT.
handleTemperature(): Lê o valor do sensor de temperatura e envia ao broker MQTT.
sendTemperature(): Envia o valor da temperatura ao broker MQTT.
Como Usar
Configurar Credenciais:

Defina as credenciais da rede Wi-Fi e do broker MQTT nas variáveis apropriadas.
Carregar o Sketch:

Carregue o sketch no ESP32 usando o Arduino IDE ou outra ferramenta compatível.
Monitorar a Saída Serial:

Use um monitor serial para observar as mensagens de debug e status.
Interagir via MQTT:

Observe as mensagens publicadas nos tópicos de estado e temperatura.
Este sketch proporciona uma base para projetos de IoT com ESP32, permitindo o monitoramento de sensores via MQTT e uma interface Wi-Fi.
