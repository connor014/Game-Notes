using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Game_Notes
{
    class NoteInfo
    {
        public string Filename { get; set; }//to save the data
        public string ID { get; set; }//save student ID
        public string marksIn313 { get; set; }//marks in each course
        public string marksIn314 { get; set; }
        public string marksIn446 { get; set; }
        public string allmarks { get; set; }//to generate a string to be shown in TableView
        public NoteInfo()
        {
            //empty constructor
        }
        //returns a description of the student object.
        //we will use it to split the string and obtain the 4 different elements in StudentInfo
        public override string ToString()
        {
            return ID + " " + marksIn313 + " " + marksIn314 + " " + marksIn446;
        }
    }
}