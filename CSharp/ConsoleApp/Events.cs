using System;
using System.Threading;

/*

Events is a :

    A mechanism for communication between objects
    
    Used in building Loosely Coupled Applications

    Help extending applications


Delegates :

    Agreement / Contract between Publisher and Subscriber

    Determines the signature of the event handler method in Subscriber



*/
namespace ConsoleApp
{

    public class Video
    {
        public string Title { get; set; }
    }


    public class VideoEventArgs : EventArgs {
        public Video Video { get; set; }
    }
    public class MailService
    {
        public void OnVideoEncoded(object source,VideoEventArgs args){
            System.Console.WriteLine("Mail Service sending an email ..." + args.Video.Title);
        }
    }


    public class MessageService{
        public void OnVideoEncoded(object source,EventArgs args){
            System.Console.WriteLine(args.ToString());
        }
    }

    public class VideoEncoder
    {
        //1. define a delegates
        // public delegate void VideoEncodedrEventHandler(object source, EventArgs args);
        //public delegate void VideoEncodedrEventHandler(object source, VideoEventArgs args);

        //2. Define an event based on that delegates
        //public event VideoEncodedrEventHandler VideoEncoded;
        public event EventHandler<VideoEventArgs> VideoEncoded;
        public event EventHandler VideoEncoding;

        //3. Raise the event
        protected virtual void OnVideoEncoded(Video video)
        {
            if (VideoEncoded != null)
            {
                // VideoEncoded(this, EventArgs.Empty);
                VideoEncoded(this, new VideoEventArgs(){ Video = video });
            }
        }


        public void Encode(Video video)
        {
            System.Console.WriteLine("encoding video ...");
            Thread.Sleep(3000);

            OnVideoEncoded(video);
        }
    }


}