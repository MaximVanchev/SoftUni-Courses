using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Food
    {
        private int quantity;
        public Food(int quantity)
        {
            Quantity = quantity;
        }
        public int Quantity { get => quantity; private set => quantity = value; }
    }
}
