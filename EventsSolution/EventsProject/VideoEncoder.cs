using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EventsProject
{
    //reference to video so user know which video info is sent
    public class VideoEventArgs : EventArgs
    {
        public Video Video { get; set; }
    }
    public class VideoEncoder
    {
        //1-Define a delegate
        //2-Define an evenet based on that delegate
        //3.Raise the event

        //1 old version :
        public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);//VideoEventArgs was earlier EventArgs as new function is created

        //EventHandler 
        //EventHandler<TEventArgs>
        //2
        // public event VideoEncodedEventHandler VideoEncoded;//past form of the name use the form defining the state
        //new version for step 1,2
        public event EventHandler<VideoEventArgs> VideoEncoded;
        //non genric : public event EventHandler VideoEncoded;
        //3

        public void Encode(Video video)
        {
            Console.WriteLine("Encoding video...");
            Thread.Sleep(3000);

            OnVideoEncoded(video); //notify the subs
        }

        //will make event happen/raise the event
        protected virtual void OnVideoEncoded(Video video)
        {
            if (VideoEncoded != null)
                //VideoEncoded(this, EventArgs.Empty);//empty args
                VideoEncoded(this,new VideoEventArgs() { Video = video });
        }
    }
}
