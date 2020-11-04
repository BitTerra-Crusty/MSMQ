using Experimental.System.Messaging;
using System;
using System.Threading;

namespace Send_Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            var message = "";
            var iterator = 1;

            while(true)
            {
       
                message = "simple message " + iterator.ToString();

                MessageQueue myMessageQueue = new MessageQueue();

                myMessageQueue.Path = @".\private$\messages";

                if (!MessageQueue.Exists(myMessageQueue.Path))
                {
                    MessageQueue.Create(myMessageQueue.Path);
                }

                Experimental.System.Messaging.Message actualMessage = new Message();
                actualMessage.Body = message;

                myMessageQueue.Send(message);

                Console.WriteLine(iterator.ToString() + " message sent");

                iterator++;
                Thread.Sleep(1000);
            }
        }
    }
}
