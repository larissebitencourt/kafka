# Kafka

📝 **Resumo**

Essa branch foi desenvolvida a partir do estudo no curso de Kafka da Full Cycle. Aqui você irá encontrar uma forma de simples de construir um publicador e um consumidor de mensagens utilizando o Apache Kafka.

🚀 **Tecnologias**

- .NET Core 6.0
- Confluent Kafka .NET
- Apache Kafka
- Zookeeper
- Control Center for Confluent Platform

Docker-compose utilizado para subir o Kafka, Zookeeper e Control Center:

```version: "3"
services:  
  zookeeper:
    image: confluentinc/cp-zookeeper:latest
    environment:
      ZOOKEEPER_CLIENT_PORT: 2181
    extra_hosts:
      - "host.docker.internal:172.17.0.1"

  kafka:
    image: confluentinc/cp-kafka:6.0.0
    depends_on:
      - zookeeper
    ports:
      - "9092:9092"
      - "9094:9094"
    environment:
      KAFKA_BROKER_ID: 1
      KAFKA_OFFSETS_TOPIC_REPLICATION_FACTOR: 1
      KAFKA_ZOOKEEPER_CONNECT: zookeeper:2181
      KAFKA_INTER_BROKER_LISTENER_NAME: INTERNAL
      KAFKA_LISTENERS: INTERNAL://:9092,OUTSIDE://0.0.0.0:9094
      KAFKA_ADVERTISED_LISTENERS: INTERNAL://kafka:9092,OUTSIDE://localhost:9094
      KAFKA_LISTENER_SECURITY_PROTOCOL_MAP: INTERNAL:PLAINTEXT,OUTSIDE:PLAINTEXT
    extra_hosts:
      - "host.docker.internal:172.17.0.1"

  control-center:
    image: confluentinc/cp-enterprise-control-center:6.0.0
    hostname: control-center
    depends_on:
      - kafka
    ports:
      - "9021:9021"
    environment:
      CONTROL_CENTER_BOOTSTRAP_SERVERS: 'kafka:9092'
      CONTROL_CENTER_REPLICATION_FACTOR: 1
      CONTROL_CENTER_CONNECT_CLUSTER: http://kafka-connect:8083
      PORT: 9021
    extra_hosts:
      - "host.docker.internal:172.17.0.1"```

✅ **Solução**

Executar ` docker-compose up ` na pasta onde o arquivo docker-compose.yml se encontra.

Após a subida dos containers, acessar: `http://localhost:9021/` > Topics > Add a topic > em Topic Name escrever **topic-hello-kafka** 

Executar a aplicação e tudo deverá funcionar corretamente.

Evidência de que as mensagens estão sendo publicadas no tópico.
<img width="400" alt="topic" src="https://github.com/larissebitencourt/kafka/assets/26878743/d437d25b-ddb7-4976-ae13-274f77fd61df">

