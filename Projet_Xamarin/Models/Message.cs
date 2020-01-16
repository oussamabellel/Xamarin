﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Projet_Xamarin.Models
{
    public class Message : INotifyPropertyChanged
    {
        public int id { get; set; }
        public int student_id { get; set; }
        public double gps_lat { get; set; }
        public double gps_long { get; set; }
        public string student_message { get; set; }
        public string color { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}