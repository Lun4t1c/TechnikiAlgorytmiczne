using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigNumber
{
    /// <summary>
    /// Class for storing and performing operations on very large numbers.
    /// </summary>
    internal class BigNumber
    {
        #region Node subclass
        /// <summary>
        /// Sub-class for storing actual digits
        /// </summary>
        private class Node
        {
            #region Properties
            /// Stored digit
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


            #region Methods
            /// <summary>
            /// Add value passed as parameter and return extra digit resulting from addition.
            /// </summary>
            /// <param name="value"></param>
            /// <returns></returns>
            public int AddValue(int value)
            {
                this.Value += value;
                int memory = 0;

                while (this.Value >= 10)
                {
                    memory++;
                    this.Value -= 10;
                }

                return memory;
            }
            #endregion
        }
        #endregion


        #region Properties
        public static bool isInDebugMode { get; set; } = false;

        private Node Head { get; set; } = null;
        private Node Tail { get; set; } = null;
        
        public bool isNegative { get { return this.Head.Value < 0; } }
        public bool isPositive { get { return this.Head.Value > 0; } }

        public int NumberOfDigits 
        {
            get 
            {
                int result = 0;
                if (this.Head == null || this.Head.Next == null)
                    return result;
                else
                {
                    Node walker = this.Head.Next;
                    while (walker != null)
                    {
                        result++;
                        walker = walker.Next;
                    }
                }

                return result;
            } 
        }
        #endregion


        #region Constructors
        public BigNumber()
        {
            AddDigitInFront(1);
            AddDigitInBack(0);
        }

        public BigNumber(string value)
        {
            char[] tempArray = value.ToCharArray();
            bool isNegative;

            int i = 0;
            if (tempArray[0] == '-')
            {
                isNegative = true;
                i++;
            }
            else
                isNegative = false;

            // Array.Reverse(tempArray);
            for (; i < tempArray.Length; i++)
                AddDigitInFront(int.Parse(tempArray[i].ToString()));

            if (isNegative)
                AddDigitInFront(-1);
            else
                AddDigitInFront(1);
        }

        public BigNumber(BigNumber bigNumber)
        {
            char[] tempArray = bigNumber.ToString().ToCharArray();
            bool isNegative;

            int i = 0;
            if (tempArray[0] == '-')
            {
                isNegative = true;
                i++;
            }
            else
                isNegative = false;

            // Array.Reverse(tempArray);
            for (; i < tempArray.Length; i++)
                AddDigitInFront(int.Parse(tempArray[i].ToString()));

            if (isNegative)
                AddDigitInFront(-1);
            else
                AddDigitInFront(1);
        }
        #endregion


        #region Methods
        /// <summary>
        /// Adds digit in front, replacing current Head.
        /// </summary>
        /// <param name="digit"></param>
        private void AddDigitInFront(int digit)
        {
            if (isInDebugMode) 
                Console.WriteLine($"{System.Reflection.MethodBase.GetCurrentMethod().Name}({digit})");

            Node NewHead = new Node(digit);

            if (this.Head == null)
            {
                this.Head = NewHead;
                this.Tail = NewHead;
            }
            else
            {
                this.Head.Previous = NewHead;
                NewHead.Next = this.Head;
                this.Head = NewHead;
            }
        }

        /// <summary>
        /// Adds digit in back, replacing current Tail.
        /// </summary>
        /// <param name="digit"></param>
        private void AddDigitInBack(int digit)
        {
            if (isInDebugMode) 
                Console.WriteLine($"{System.Reflection.MethodBase.GetCurrentMethod().Name}({digit})");

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

        /// <summary>
        /// Remove all insignificant leading zeros if there are any.
        /// </summary>
        private void RemoveLeadingZeros()
        {
            Node walker = this.Tail;
            while (walker.Value == 0)
            {
                walker = walker.Previous;
                walker.Next = null;
                this.Tail = walker;
            }
        }

        /// <summary>
        /// Overriden function returning <class cref="BigNumber"></class>'s digits as <class cref="string"></class>.
        /// </summary>
        /// <returns><class cref="string"></class> representation of <class cref="BigNumber"></class></returns>
        /// <exception cref="Exception"></exception>
        override public string ToString()
        {
            if (this.Head == null)
                throw new Exception($"{typeof(BigNumber)}'s Head is NULL.");
            if (this.Head == null)
                throw new Exception($"{typeof(BigNumber)}'s Head.Next is NULL.");


            string result = "";
            Node walker = this.Tail;
            if (this.Head.Value < 0) result += '-';

            while (walker != this.Head)
            {
                result += walker.Value.ToString();
                walker = walker.Previous;
            }

            return result;
        }

        /// <summary>
        /// Print in console visualization of current links.
        /// </summary>
        public void DisplayLinks()
        {
            Node walker = this.Head;
            while (walker != null)
            {
                Console.Write($"{walker.Value} <--> ");
                walker = walker.Next;
            }
            Console.WriteLine("NULL");
        }

        /// <summary>
        /// Invert sign of <class cref="BigNumber"></class>.
        /// </summary>
        private void InvertSign()
        {
            this.Head.Value *= -1;
        }

        /// <summary>
        /// Remove all <class cref="Node"></class> references and set <property cref="Head"></property>
        /// and <property cref="Tail"></property> to null.
        /// </summary>
        private void ClearList()
        {
            Node walker = this.Head;

            while (walker != null)
            {
                walker.Previous = null;
                walker = walker.Next;
            }

            this.Head = null;
            this.Tail = null;
        }

        /// <summary>
        /// Delete all current digits using <method cref="ClearList"></method> and replace them with
        /// <param name="bigNumber">'s digits.
        /// </summary>
        /// <param name="bigNumber"></param>
        private void Overwrite(BigNumber bigNumber)
        {
            this.ClearList();

            char[] tempArray = bigNumber.ToString().ToCharArray();
            bool isNegative;

            int i = 0;
            if (tempArray[0] == '-')
            {
                isNegative = true;
                i++;
            }
            else
                isNegative = false;

            // Array.Reverse(tempArray);
            for (; i < tempArray.Length; i++)
                AddDigitInFront(int.Parse(tempArray[i].ToString()));

            if (isNegative)
                AddDigitInFront(-1);
            else
                AddDigitInFront(1);
        }

        /// <summary>
        /// Add another <class cref="BigNumber"> to this.
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="Exception"></exception>
        public void AddBigInt(BigNumber value)
        {            
            short negatives = 0;
            if (this.isNegative) negatives++;
            if (value.isNegative) negatives++;

            switch (negatives)
            {
                case 0: // both are positive numbers
                    int memory = 0;
                    Node walker_a = this.Head.Next;
                    Node walker_b = value.Head.Next;

                    while (walker_a != null && walker_b != null)
                    {
                        memory = walker_a.AddValue(walker_b.Value + memory);

                        walker_a = walker_a.Next;
                        walker_b = walker_b.Next;
                    }

                    while (walker_b != null)
                    {
                        this.AddDigitInBack(walker_b.Value);
                        memory = this.Tail.AddValue(memory);
                        walker_b = walker_b.Next;
                    }

                    while (memory != 0)
                    {
                        if (walker_a != null)
                        {
                            memory = walker_a.AddValue(memory);
                            walker_a = walker_a.Next;
                        }
                        else
                        {
                            this.AddDigitInBack(0);
                            memory = this.Tail.AddValue(memory);
                        }
                    }

                    break;

                case 1: // one is negative number
                    break;

                case 2: // both are negative numbers
                    break;

                default:
                    throw new Exception("ERROR");
            }
        }

        /// <summary>
        /// Subtract another <class cref="BigNumber"> from this.
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="Exception"></exception>
        public void SubtractBigInt(BigNumber value)
        {
            short negatives = 0;
            if (this.isNegative) negatives++;
            if (value.isNegative) negatives++;

            switch (negatives)
            {
                case 0: // both are positive numbers
                    int memory = 0;
                    Node walker_a = this.Head.Next;
                    Node walker_b = value.Head.Next;

                    if (this < value)
                    {
                        
                    }
                    else
                    {
                        while (walker_a != null && walker_b != null)
                        {
                            if (walker_a.Value < walker_b.Value)
                            {
                                walker_a.Next.Value -= 10;
                                walker_a.Value += 10;
                            }

                            walker_a.Value -= walker_b.Value;

                            walker_a = walker_a.Next;
                            walker_b = walker_b.Next;
                        }
                    }
                    this.RemoveLeadingZeros();

                    break;

                case 1: // one is negative number
                    break;

                case 2: // both are negative numbers
                    break;

                default:
                    throw new Exception("ERROR");
            }
        }

        /// <summary>
        /// Multiply another <class cref="BigNumber"> with this.
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="Exception"></exception>
        public void MultiplyBigInt(BigNumber value)
        {
            BigNumber finalBigNumber = new BigNumber();
            short negatives = 0;
            if (this.isNegative) negatives++;
            if (value.isNegative) negatives++;

            Node walker_a;
            Node walker_b = value.Head.Next;
            int multiplier_a = 0;
            int multiplier_b = 0;

            while (walker_b != null)
            {
                BigNumber tempBigNumber = new BigNumber();

                walker_a = this.Head.Next;
                multiplier_a = 0;
                while (walker_a != null)
                {
                    string tempString = (walker_b.Value * walker_a.Value).ToString();
                    for (int i = 0; i < multiplier_b + multiplier_a; i++)
                        tempString += "0";

                    finalBigNumber += new BigNumber(tempString);
                    multiplier_a++;
                    walker_a = walker_a.Next;
                }

                walker_b = walker_b.Next;
                multiplier_b++;
            }

            this.Overwrite(finalBigNumber);

            switch (negatives)
            {
                case 0: // both are positive numbers
                    

                    break;

                case 1: // one is negative number
                    break;

                case 2: // both are negative numbers
                    break;

                default:
                    throw new Exception("ERROR");
            }
        }

        /// <summary>
        /// Divide this by another <class cref="BigNumber">.
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void DivideBigInt(BigNumber value)
        {
            short negatives = 0;
            if (this.isNegative) negatives++;
            if (value.isNegative) negatives++;



            switch (negatives)
            {
                case 0: // both are positive numbers
                    BigNumber finalBigNumber = new BigNumber();

                    while (this > value)
                    {
                        this.SubtractBigInt(value);
                        finalBigNumber += 1;
                    }

                    this.Overwrite(finalBigNumber);
                    break;

                case 1: // one is negative number
                    break;

                case 2: // both are negative numbers
                    break;

                default:
                    throw new Exception("ERROR");
            }
        }

        /// <summary>
        /// Add regular <class cref="int"></class> to this using <method cref="AddBigInt(BigNumber)"></method>
        /// by casting <paramref name="value"/> to <class cref="BigNumber"></class>.
        /// </summary>
        /// <param name="value"></param>
        public void AddInt(int value)
        {
            this.AddBigInt(new BigNumber(value.ToString()));
        }

        /// <summary>
        /// Subtract regular <class cref="int"></class> from this using <method cref="SubtractBigInt(BigNumber)"></method>
        /// by casting <paramref name="value"/> to <class cref="BigNumber"></class>.
        /// </summary>
        /// <param name="value"></param>
        public void SubtractInt(int value)
        {
            this.SubtractBigInt(new BigNumber(value.ToString()));
        }

        /// <summary>
        /// Multiply regular <class cref="int"></class> with this using <method cref="MultiplyBigInt(BigNumber)"></method>
        /// by casting <paramref name="value"/> to <class cref="BigNumber"></class>.
        /// </summary>
        /// <param name="value"></param>
        public void MultiplyInt(int value)
        {
            this.MultiplyBigInt(new BigNumber(value.ToString()));
        }

        /// <summary>
        /// Divide this by regular <class cref="int"></class> using <method cref="DivideBigInt(BigNumber)"></method>
        /// by casting <paramref name="value"/> to <class cref="BigNumber"></class>.
        /// </summary>
        /// <param name="value"></param>
        public void DivideInt(int value)
        {
            this.DivideBigInt(new BigNumber(value.ToString()));
        }
        #endregion


        #region Operators

        #region Arithmetical
        public static BigNumber operator +(BigNumber a, BigNumber b)
        {
            a.AddBigInt(b);
            return a;
        }

        public static BigNumber operator -(BigNumber a, BigNumber b)
        {
            a.SubtractBigInt(b);
            return a;
        }

        public static BigNumber operator *(BigNumber a, BigNumber b)
        {
            a.MultiplyBigInt(b);
            return a;
        }

        public static BigNumber operator /(BigNumber a, BigNumber b)
        {
            a.DivideBigInt(b);
            return a;
        }

        public static BigNumber operator +(BigNumber a, string b)
        {
            a.AddBigInt(new BigNumber(b));
            return a;
        }

        public static BigNumber operator -(BigNumber a, string b)
        {
            a.SubtractBigInt(new BigNumber(b));
            return a;
        }

        public static BigNumber operator *(BigNumber a, string b)
        {
            a.MultiplyBigInt(new BigNumber(b));
            return a;
        }

        public static BigNumber operator /(BigNumber a, string b)
        {
            a.DivideBigInt(new BigNumber(b));
            return a;
        }

        public static BigNumber operator +(BigNumber a, int b)
        {
            a.AddBigInt(new BigNumber(b.ToString()));
            return a;
        }

        public static BigNumber operator -(BigNumber a, int b)
        {
            a.SubtractBigInt(new BigNumber(b.ToString()));
            return a;
        }

        public static BigNumber operator *(BigNumber a, int b)
        {
            a.MultiplyBigInt(new BigNumber(b.ToString()));
            return a;
        }

        public static BigNumber operator /(BigNumber a, int b)
        {
            a.DivideBigInt(new BigNumber(b.ToString()));
            return a;
        } 
        #endregion


        public static bool operator <(BigNumber a, BigNumber b)
        {
            if (a.isNegative != b.isNegative)
                return a.Head.Value < b.Head.Value;

            if (a.NumberOfDigits != b.NumberOfDigits)
                return a.NumberOfDigits < b.NumberOfDigits;

            Node walker_a = a.Head.Next;
            Node walker_b = b.Head.Next;

            while (walker_a != null && walker_b != null)
            {
                if (walker_a.Value != walker_b.Value)
                    return walker_a.Value < walker_b.Value;

                walker_a = walker_a.Next;
                walker_b = walker_b.Next;
            }

            if (walker_a == null && walker_b == null) return false;

            if (walker_a == null) return true;
            else return false;
        }

        public static bool operator >(BigNumber a, BigNumber b)
        {
            if (a.isNegative != b.isNegative)
                return a.Head.Value > b.Head.Value;

            if (a.NumberOfDigits != b.NumberOfDigits)
                return a.NumberOfDigits > b.NumberOfDigits;

            Node walker_a = a.Head.Next;
            Node walker_b = b.Head.Next;

            while (walker_a != null && walker_b != null)
            {
                if (walker_a.Value != walker_b.Value)
                    return walker_a.Value > walker_b.Value;

                walker_a = walker_a.Next;
                walker_b = walker_b.Next;
            }

            if (walker_a == null && walker_b == null) return false;

            if (walker_a == null) return false;
            else return true;
        }
        #endregion
    }
}
