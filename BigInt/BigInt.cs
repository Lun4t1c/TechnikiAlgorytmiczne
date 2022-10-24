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
        #endregion


        #region Constructor
        public BigInt(string value)
        {
            char[] tempArray = value.ToCharArray();
            Array.Reverse(tempArray);

            foreach (char c in tempArray)
                AddDigitInFront(int.Parse(c.ToString()));
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

        override public string ToString()
        {
            string result = "";
            Node walker = this.Head;

            while (walker != null)
            {
                result += walker.Value.ToString();
                walker = walker.Next;
            }

            return result;
        }

        public void AddBigInt(BigInt value)
        {
            throw new NotImplementedException();
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
