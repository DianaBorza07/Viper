using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Models
{
    public class Singleton
    {
       
            private static int creationCount = 0;

            private static readonly Singleton _mySingletonServiceInstance = new Singleton();

            private Singleton()
            {
                creationCount++;
            }

            public static Singleton GetInstance() => _mySingletonServiceInstance;

            public int GetCreationCount() => creationCount;

    }
}
