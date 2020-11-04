using Experimental.System.Messaging;
using System;
using System.Threading;

namespace Receive_Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            var IsMessageAvailable = true;

            while(true)
            {
                try
                {


                    MessageQueue messageQueue = new MessageQueue();

                    messageQueue.Path = @".\private$\messages";

                    if (!MessageQueue.Exists(messageQueue.Path))
                    {
                        Console.WriteLine("Specified Queue doesn't exist.");
                        IsMessageAvailable = false;
                        continue;
                    }

                    Experimental.System.Messaging.Message[] allMessages = new Message[messageQueue.GetAllMessages().Length];
                    
                    if(allMessages.Length == 0)
                    {
                        Console.WriteLine("There's No messages in the Queue.");
                        IsMessageAvailable = false;
                        continue;
                    }

                    //allMessages = messageQueue.GetAllMessages();

                    //for (int messageIndex = 0; messageIndex < allMessages.Length; messageIndex++)
                    //{
                    //    allMessages[messageIndex].Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });

                    //    string actualMessage = (string)allMessages[messageIndex].Body;

                    //    Console.WriteLine("Message: "+actualMessage);
                    //    Thread.Sleep(200);
                    //}


                    //var queueName = messageQueue.QueueName;
                    //Console.WriteLine(queueName);

                    Experimental.System.Messaging.Message message = new Message();

                    //message = messageQueue.Peek();

                    message = messageQueue.Receive();

                    message.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });

                    string actualMessage = (string)message.Body;

                    Console.WriteLine("Message: " + actualMessage);
                    Thread.Sleep(1000);
                }
                catch
                {
                    Console.WriteLine("There's Nothing in the Queue.");
                    IsMessageAvailable = false;
                }

            }

            Console.WriteLine("End of program");
        }
    }
}
