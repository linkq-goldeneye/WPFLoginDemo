﻿using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LoginDemo.Share.Events
{
    public class LoadingEvent : PubSubEvent<Visibility>
    {
    }
}
