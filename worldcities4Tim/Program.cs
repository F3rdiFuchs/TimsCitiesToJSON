﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace worldcities4Tim
{
    class Program
    {
        
        static void Main(string[] args)
        {
            ReadThread readThread = new ReadThread();
            readThread.openFile();
            //Thread thread1;
            //thread1 = new Thread(new ThreadStart(readThread.openFile));
            //thread1.Start();
        }
    }
}
