using System;
using System.Collections.Generic;
using System.Text;

namespace EventsProject
{
    public class MessageService
    {
        public void OnVideoEncoded(object source, VideoEventArgs e) //Earlier Eventargs
        {
            Console.WriteLine("MessageService: sending a text message.." + e.Video.Title); 
        }
    }
}
