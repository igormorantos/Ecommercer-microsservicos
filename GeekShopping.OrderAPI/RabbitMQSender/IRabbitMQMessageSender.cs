using GeekShopping.MessageBus;
using System.Buffers.Text;

namespace GeekShopping.OrderAPI.RabbitMQSender
{
    public interface IRabbitMQMessageSender
    {
        void SendMessage(BaseMessage baseMessage, string queueName);
    }
}
