# Kafka Samples

Simple samples of producer and consumer for Kafka.

## Components

1. DockerCompose
	- Main Confluentic Kafka (Raft mode without zookeeper)
	- Confluentic Kafka (For initial topic creation)
	- ProvectusLabs Kafka UI

2. Kafka Producer
3. Kafka Consumer

## Running

1. Run the below command to set the cluster up.
```
docker compose up -d
```

> The cluster can be managed on the UI at http://localhost15001

2. Run Kafka Producer, you can type a message, and press enter to submit it to Kafka
3. Run Kafka Consumer, it will display the messages along with their offsets.
