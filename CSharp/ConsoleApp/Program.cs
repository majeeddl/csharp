using System;
using Generics;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            byte number = 2;

            int count = 10;

            float totalPrice = 20.25f;

            char character = 'H';

            string firstName = "Majeed";

            bool isWorking = true;


            Console.WriteLine(number);

            Console.WriteLine(firstName);

            Console.WriteLine(isWorking);

            Console.WriteLine("{0} , {1}", byte.MinValue, byte.MaxValue);

            Console.WriteLine("{0} {1}", float.MinValue, float.MaxValue);


            // use of generics list
            var numbers = new GenericsList<int>();
            numbers.Add(1);

            var books = new GenericsList<Book>();
            books.Add(new Book());


            //use of generic dictionary
            var dictionary = new GenericDictionary<string,Book>();
            dictionary.Add("12",new Book());


            var numberNullable = new Nullable<int>(5);
            System.Console.WriteLine("Has Value ?" + numberNullable.HasValue);
            System.Console.WriteLine("Value : "+ numberNullable.GetValueOrDefault());


            //Delegates

            var processor = new PhotoProcessor();
            var filters = new PhotoFilters();
            // PhotoProcessor.PhotoFilterHandler filterHandler = filters.ApplyBrightness;
            Action<Photo> filterHandler = filters.ApplyBrightness;
            filterHandler+= filters.ApplyConstract;

            processor.Process("photo.jpg",filterHandler);



            //Events
            var video = new Video(){ Title = "Video"};
            var videoEncoder = new VideoEncoder();// publisher
            var mailService = new MailService(); // Subscriber
            var messageService = new MessageService(); //Subscriber

            videoEncoder.VideoEncoded+= mailService.OnVideoEncoded;
            videoEncoder.VideoEncoded+= messageService.OnVideoEncoded;
            videoEncoder.Encode(video); 
            

        }
    }
}
