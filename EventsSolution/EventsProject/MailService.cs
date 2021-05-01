using System;
using System.Collections.Generic;
using System.Text;

namespace EventsProject
{
    public class MailService
        {
            public void OnVideoEncoded(object source, VideoEventArgs e)//earlier EventArgs
        {
                Console.WriteLine("Mail Serice: sending an email.." + e.Video.Title);
            }
        }
}
