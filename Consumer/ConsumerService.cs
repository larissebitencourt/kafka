using Confluent.Kafka;

namespace Kafka.Consumer
{
    public static class ConsumerService
    {
        public static void ConsumerMessage(string topic)
        {
            var config = KafkaConsumerConfig.GetConfig();

            using var consumer = new ConsumerBuilder<Null, string>(config).Build();

            consumer.Subscribe(topic);

            while (true)
            {
                try
                {
                    var consumeResult = consumer.Consume();
                    Console.WriteLine($"Received message: {consumeResult.Message.Value}");

                    consumer.Commit();
                }
                catch (ConsumeException e)
                {
                    Console.WriteLine($"Error consuming message: {e.Error.Reason}");
                }
            }
        }
    }
}
