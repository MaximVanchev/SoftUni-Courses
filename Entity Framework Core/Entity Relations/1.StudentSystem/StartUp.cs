﻿using P01_StudentSystem.Data;
using System;

namespace P01_StudentSystem 
{
    class StartUp
    {
        static void Main(string[] args)
        {
            StudentSystemContext db = new StudentSystemContext();

            db.Database.EnsureCreated();

            Console.WriteLine("db created");
        }
    }
}
