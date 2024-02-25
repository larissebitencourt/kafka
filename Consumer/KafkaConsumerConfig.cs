using Confluent.Kafka;

namespace Kafka.Consumer
{
    public static class KafkaConsumerConfig
    {
        public static ConsumerConfig GetConfig()
        {
            return new ConsumerConfig()
            {
                BootstrapServers = "localhost:9094",
                GroupId = "KafkaConsumer",
                EnableAutoCommit = false,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
        }
    }
}
