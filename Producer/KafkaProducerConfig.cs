using Confluent.Kafka;

namespace Kafka.Producer
{
    public class KafkaProducerConfig
    {
        public static ProducerConfig GetConfig()
        {
            return new ProducerConfig()
            {
                BootstrapServers = "localhost:9094",
                ClientId = Guid.NewGuid().ToString()
            };
        }
    }
}
