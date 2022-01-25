using System;

// Delegates :
// An object that knows how to call a method (or a group of methods)
// a refrence to a function 

// Why  do we need delegates?
// This technics allows us for designing extensible and flexible applications (eg frameworks)
//Alternative is Interface


//When use Interfaces or Delegates?
// Use a delegate when :
//      An eventing design pattern isused
//      The aller doesn't need to access other properties or methods on the object implementing the method

namespace ConsoleApp
{

    public class Photo
    {
        public static Photo Load(string path)
        {
            return new Photo();
        }

        public void Save()
        {

        }
    }

    public class PhotoFilters
    {
        public void ApplyBrightness(Photo photo)
        {
            System.Console.WriteLine("Apply brightness");
        }

        public void ApplyConstract(Photo photo)
        {
            System.Console.WriteLine("Apply constract");
        }
    }

    public class PhotoProcessor
    {
        // public delegate void PhotoFilterHandler(Photo photo);
        // public void Process(string path, PhotoFilterHandler filterHandler)
        // {
        //     var photo = Photo.Load(path);

        //     // var filters = new PhotoFilters();
        //     // filters.ApplyBrightness(photo);
        //     // filters.ApplyConstract(photo);

        //     filterHandler(photo);

        //     photo.Save();
        // }

        public void Process(string path, Action<Photo> filterHandler)
        {
            var photo = Photo.Load(path);

            // var filters = new PhotoFilters();
            // filters.ApplyBrightness(photo);
            // filters.ApplyConstract(photo);

            filterHandler(photo);

            photo.Save();
        }
    }
}