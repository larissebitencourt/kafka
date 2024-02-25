using Confluent.Kafka;

namespace Kafka.Producer
{
    public static class ProducerService
    {
        public static DeliveryResult<Null, string> ProducerMessage(string topic, string message)
        {
            var config = KafkaProducerConfig.GetConfig();

            using var producer = new ProducerBuilder<Null, string>(config).Build();

            var delivery = producer.ProduceAsync(topic, new Message<Null, string> { Value = message }).Result;

            return delivery;
        }
    }
}
