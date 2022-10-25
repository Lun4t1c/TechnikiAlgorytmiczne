using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigInt
{
    internal class BigInt
    {
        #region Node subclass
        private class Node
        {
            #region Properties
            public int Value { get; set; }
            public Node Previous { get; set; } = null;
            public Node Next { get; set; } = null;
            #endregion


            #region Constructor
            public Node(int value)
            {
                Value = value;
            }
            #endregion
        }
        #endregion


        #region Properties
        private Node Head { get; set; } = null;
        private Node Tail { get; set; } = null;
        #endregion


        #region Constructor
        public BigInt(string value)
        {
            char[] tempArray = value.ToCharArray();
            Array.Reverse(tempArray);

            foreach (char c in tempArray)
                AddDigitInBack(int.Parse(c.ToString()));
        }

        public BigInt()
        {
            AddDigitInFront(0);
        }
        #endregion


        #region Methods
        private void AddDigitInFront(int digit)
        {
            Node NewHead = new Node(digit);
            NewHead.Next = this.Head;
            this.Head = NewHead;
        }

        private void AddDigitInBack(int digit)
        {
            Node NewTail = new Node(digit);

            if (this.Head == null)
            {
                this.Head = NewTail;
                this.Tail = NewTail;
            }
            else
            {
                this.Tail.Next = NewTail;
                NewTail.Previous = this.Tail;
                this.Tail = NewTail;
            }
        }

        override public string ToString()
        {
            string result = "";
            Node walker = this.Tail;

            while (walker != null)
            {
                result += walker.Value.ToString();
                walker = walker.Previous;
            }

            return result;
        }

        public void AddBigInt(BigInt value)
        {
            int memory = 0;
            Node walker_a = this.Head;
            Node walker_b = value.Head;

            while (walker_a != null && walker_b != null)
            {
                walker_a.Value += walker_b.Value + memory;
                memory = 0;
                while (walker_a.Value >= 10)
                {
                    walker_a.Value -= 10;
                    memory++;
                }

                walker_a = walker_a.Next;
                walker_b = walker_b.Next;
            }

            if (memory > 0)
                this.AddDigitInBack(memory);
        }

        public void SubtractBigInt(BigInt value)
        {
            throw new NotImplementedException();
        }

        public void MultiplyBigInt(BigInt value)
        {
            throw new NotImplementedException();
        }

        public void DivideBigInt(BigInt value)
        {
            throw new NotImplementedException();
        }

        public void AddInt(int value)
        {
            throw new NotImplementedException();
        }

        public void SubtractInt(int value)
        {
            throw new NotImplementedException();
        }

        public void MultiplyInt(int value)
        {
            throw new NotImplementedException();
        }

        public void DivideInt(int value)
        {
            throw new NotImplementedException();
        }
        #endregion


        #region Operators
        public static BigInt operator+ (BigInt a, BigInt b)
        {
            a.AddBigInt(b);
            return a;
        }

        public static BigInt operator -(BigInt a, BigInt b)
        {
            a.SubtractBigInt(b);
            return a;
        }

        public static BigInt operator *(BigInt a, BigInt b)
        {
            a.MultiplyBigInt(b);
            return a;
        }

        public static BigInt operator /(BigInt a, BigInt b)
        {
            a.DivideBigInt(b);
            return a;
        }

        public static BigInt operator +(BigInt a, string b)
        {
            a.AddBigInt(new BigInt(b));
            return a;
        }

        public static BigInt operator -(BigInt a, string b)
        {
            a.SubtractBigInt(new BigInt(b));
            return a;
        }

        public static BigInt operator *(BigInt a, string b)
        {
            a.MultiplyBigInt(new BigInt(b));
            return a;
        }

        public static BigInt operator /(BigInt a, string b)
        {
            a.DivideBigInt(new BigInt(b));
            return a;
        }
        #endregion
    }
}
