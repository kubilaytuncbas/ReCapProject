﻿using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
        }
    }
}
