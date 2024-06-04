#include <WiFi.h>
#include <PubSubClient.h>

const char* SSID = "PBLMAXXING"; // Nome da rede Wi-Fi
const char* PASSWORD = "amogus01"; // Senha da rede Wi-Fi
const char* BROKER_MQTT = "20.185.230.186"; // IP do Broker MQTT
const int BROKER_PORT = 1883; // Porta do Broker MQTT
const char* TOPICO_SUBSCRIBE = "/TEF/temp001/cmd"; // Tópico MQTT de escuta
const char* TOPICO_PUBLISH_1 = "/TEF/temp001/attrs"; // Tópico MQTT de envio de informações para Broker
const char* TOPICO_PUBLISH_2 = "/TEF/temp001/attrs/t"; // Tópico MQTT de envio de informações para Broker
const char* ID_MQTT = "fiware_001"; // ID MQTT
const int D4 = 2; // Pino do LED onboard
const char* topicPrefix = "temp001"; // Prefixo do tópico

WiFiClient espClient;
PubSubClient MQTT(espClient);
char EstadoSaida = '0';
const int potPin = 34;

void initSerial() {
    Serial.begin(115200);
}

void initWiFi() {
    delay(10);
    Serial.println("------Conexao WI-FI------");
    Serial.print("Conectando-se na rede: ");
    Serial.println(SSID);
    Serial.println("Aguarde");
    reconectWiFi();
}

void initMQTT() {
    MQTT.setServer(BROKER_MQTT, BROKER_PORT);
    MQTT.setCallback(mqtt_callback);
}

void setup() {
    InitOutput();
    initSerial();
    initWiFi();
    initMQTT();
    delay(5000);
    MQTT.publish(TOPICO_PUBLISH_1, "s|on");
}

void loop() {
    VerificaConexoesWiFIEMQTT();
    EnviaEstadoOutputMQTT();
    handleTemperature();
    MQTT.loop();
}

void reconectWiFi() {
    if (WiFi.status() == WL_CONNECTED)
        return;
    WiFi.begin(SSID, PASSWORD);
    while (WiFi.status() != WL_CONNECTED) {
        delay(100);
        Serial.print(".");
    }
    Serial.println();
    Serial.println("Conectado com sucesso na rede ");
    Serial.print(SSID);
    Serial.println("IP obtido: ");
    Serial.println(WiFi.localIP());

    // Garantir que o LED inicie desligado
    digitalWrite(D4, LOW);
}

void mqtt_callback(char* topic, byte* payload, unsigned int length) {
    String msg;
    for (int i = 0; i < length; i++) {
        char c = (char)payload[i];
        msg += c;
    }
    Serial.print("- Mensagem recebida: ");
    Serial.println(msg);

    // Forma o padrão de tópico para comparação
    String onTopic = String(topicPrefix) + "@on|";
    String offTopic = String(topicPrefix) + "@off|";

    // Compara com o tópico recebido
    if (msg.equals(onTopic)) {
        digitalWrite(D4, HIGH);
        EstadoSaida = '1';
    }

    if (msg.equals(offTopic)) {
        digitalWrite(D4, LOW);
        EstadoSaida = '0';
    }
}

void VerificaConexoesWiFIEMQTT() {
    if (!MQTT.connected())
        reconnectMQTT();
    reconectWiFi();
}

void EnviaEstadoOutputMQTT() {
    if (EstadoSaida == '1') {
        MQTT.publish(TOPICO_PUBLISH_1, "s|on");
        Serial.println("- Led Ligado");
    }

    if (EstadoSaida == '0') {
        MQTT.publish(TOPICO_PUBLISH_1, "s|off");
        Serial.println("- Led Desligado");
    }
    Serial.println("- Estado do LED onboard enviado ao broker!");
    delay(10000);
}

void InitOutput() {
    pinMode(D4, OUTPUT);
    digitalWrite(D4, HIGH);
    boolean toggle = false;

    for (int i = 0; i <= 10; i++) {
        toggle = !toggle;
        digitalWrite(D4, toggle);
        delay(200);
    }
}

void reconnectMQTT() {
    while (!MQTT.connected()) {
        Serial.print("* Tentando se conectar ao Broker MQTT: ");
        Serial.println(BROKER_MQTT);
        if (MQTT.connect(ID_MQTT)) {
            Serial.println("Conectado com sucesso ao broker MQTT!");
            MQTT.subscribe(TOPICO_SUBSCRIBE);
        } else {
            Serial.println("Falha ao reconectar no broker.");
            Serial.println("Haverá nova tentativa de conexão em 2s");
            delay(2000);
        }
    }
}

void handleTemperature() {
    float sensorValue = analogRead(potPin);
    float temperature = sensorValue * 100/4095 * 1.1035388; //uma constante de ganho é adicionada que corrige o desvio dos valores 
    sendTemperature(float temperature)                      //coletados em relação aos valores reais
}

void sendTemperature(float temperature) {
    Serial.print("Valor da temperatura: ");
    Serial.println(mensagem.c_str());
    MQTT.publish(TOPICO_PUBLISH_2, mensagem.c_str());
}
