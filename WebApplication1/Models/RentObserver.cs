using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Models
{
    public interface Observer
    {
        void Update(Rental rental);
    }
    public interface Notifier
    {
        void updateRent(Rental rental);
    }
    public class RentObserver :Observer
    {
        public void Update(Rental rental)
        {
            Console.WriteLine("New rental placed");
        }

        internal void Update(RentObserver rental)
        {
            throw new NotImplementedException();
        }
    }

    public class OrderService : Notifier
    {
        public List<RentObserver> Observers = new List<RentObserver>();

        public void UpdateOrder(RentObserver order)
        {
            Notify(order);
        }

        public void updateRent(Rental rental)
        {
            throw new NotImplementedException();
        }

        public void Notify(RentObserver rental)
        {
            rental.Update(rental);
        }
    }

}
