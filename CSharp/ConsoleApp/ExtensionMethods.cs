
using System;
using System.Linq;

namespace ConsoleApp {

    public class ExtensionMethods{
        string post = "This is supposed to be a very long blog post blah blah blah ...";

        public void test(){
            var shortenedPost = post.Shorten(5);
        }
        
    }



    public static class StringExtensions{
        public static string Shorten(this String str,int numberOfWords){

            if( numberOfWords < 0){
                throw new ArgumentOutOfRangeException(" number of words should be greater than or equals to 0");
            }
            if(numberOfWords == 0) {
                 return "";
            }

            var words = str.Split(" ");

            if(words.Length <= numberOfWords){
                return str;
            }

            return string.Join(" " ,words.Take(numberOfWords));
        }
    }
}