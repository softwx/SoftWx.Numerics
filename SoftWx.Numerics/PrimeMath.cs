// Copyright ©2012-2015 SoftWx, Inc.
// Released under the MIT License the text of which appears at the end of this file.
// <authors> Steve Hatchett
namespace SoftWx.Numerics {
    /// <summary>
    /// Numeric extension methods for math operations related to prime numbers
    /// for integer numeric types. 
    /// </summary>
    /// <remarks>Methods for byte, sbyte, ushort and short are not included,
    /// as there is little or no advantage that can be gained by their smaller
    /// size, and implementations would merely be wrappers that upcast to uint
    /// and int. Callers can do that themselves, and it will even be slightly
    /// faster too. Examples:
    /// byte b1, b2, br; b1 = 100; b2 = 101;
    /// br = (byte)PrimeMath.Gcd(b1, b2); //will implicitly upcast to uint
    /// or
    /// br = (byte)((uint)b1).Gcd(b2)</remarks>
    public static class PrimeMath {
        /// <summary>Computes the greatest common divisor of two values.</summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The other value.</param>
        /// <returns>The greatest common divisor of the two values.</returns>
        public static uint Gcd(this uint value1, uint value2) {
            uint t;
            if (value1 > value2) {
                t = value1;
                value1 = value2;
                value2 = t;
            }
            while (value1 >= 2) {
                t = value2;
                value2 = value1;
                value1 = t % value1;
            }
            if (value1 == 0) return value2;
            return 1u;
        }

        /// <summary>Computes the greatest common divisor of two values.</summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The other value.</param>
        /// <returns>The greatest common divisor of the two values.</returns>
        public static int Gcd(this int value1, int value2) {
            if ((value1 | value2) < 0) return (int)Gcd(value1.AbsU(), value2.AbsU());
            return (int)Gcd((uint)value1, (uint)value2);
        }

        /// <summary>Computes the greatest common divisor of two values.</summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The other value.</param>
        /// <returns>The greatest common divisor of the two values.</returns>
        public static ulong Gcd(this ulong value1, ulong value2) {
            if (((value1 | value2) >> 32) == 0UL) return Gcd((uint)value1, (uint)value2);
            ulong t;
            if (value1 > value2) {
                t = value1;
                value1 = value2;
                value2 = t;
            }
            while (value1 >= 2) {
                t = value2;
                value2 = value1;
                value1 = t % value1;
            }
            if (value1 == 0) return value2;
            return 1u;
        }

        /// <summary>Computes the greatest common divisor of two values.</summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The other value.</param>
        /// <returns>The greatest common divisor of the two values.</returns>
        public static long Gcd(this long value1, long value2) {
            if ((value1 | value2) < 0) return (long)Gcd(value1.AbsU(), value2.AbsU());
            return (long)Gcd((ulong)value1, (ulong)value2);
        }

        /// <summary>Determines if the specified values are coprime to each other.</summary>
        /// <param name="value1">The value to be tested.</param>
        /// <param name="value2">The other value to be tested.</param>
        /// <returns>True if the values are coprime to each other, otherwise, false.</returns>
        public static bool IsCoprime(this uint value1, uint value2) {
            // 25% of possible pairings are even num to even num so handle them
            // with a bit twiddle that's much faster than GCD function. If they
            // are both even, then they can't be coprime (2 is common divisor).
            // This works for 0 as well since only 1 and -1 are coprime to 0.
            return ((((value1 | value2) & 1) != 0)
                    && (Gcd(value1, value2) == 1));
        }

        /// <summary>Determines if the specified values are coprime to each other.</summary>
        /// <param name="value1">The value to be tested.</param>
        /// <param name="value2">The other value to be tested.</param>
        /// <returns>True if the values are coprime to each other, otherwise, false.</returns>
        public static bool IsCoprime(this int value1, int value2) {
            // 25% of possible pairings are even num to even num so handle them
            // with a bit twiddle that's much faster than GCD function. If they
            // are both even, then they can't be coprime (2 is common divisor).
            // This works for 0 as well since only 1 and -1 are coprime to 0.
            return ((((value1 | value2) & 1) != 0)
                    && (Gcd(value1, value2) == 1));
        }

        /// <summary>Determines if the specified values are coprime to each other.</summary>
        /// <param name="value1">The value to be tested.</param>
        /// <param name="value2">The other value to be tested.</param>
        /// <returns>True if the values are coprime to each other, otherwise, false.</returns>
        public static bool IsCoprime(this ulong value1, ulong value2) {
            // 25% of possible pairings are even num to even num so handle them
            // with a bit twiddle that's much faster than GCD function. If they
            // are both even, then they can't be coprime (2 is common divisor).
            // This works for 0 as well since only 1 and -1 are coprime to 0.
            return ((((value1 | value2) & 1) != 0)
                    && (Gcd(value1, value2) == 1));
        }

        /// <summary>Determines if the specified values are coprime to each other.</summary>
        /// <param name="value1">The value to be tested.</param>
        /// <param name="value2">The other value to be tested.</param>
        /// <returns>True if the values are coprime to each other, otherwise, false.</returns>
        public static bool IsCoprime(this long value1, long value2) {
            // 25% of possible pairings are even num to even num so handle them
            // with a bit twiddle that's much faster than GCD function. If they
            // are both even, then they can't be coprime (2 is common divisor).
            // This works for 0 as well since only 1 and -1 are coprime to 0.
            return ((((value1 | value2) & 1) != 0)
                    && (Gcd(value1, value2) == 1));
        }

        /// <summary>Computes the nearest number less than or equal to the
        /// specified start value that is coprime to another specified value.
        /// Returns 0 if no coprime was found in the range MinValue to start.</summary>
        /// <param name="start">The start value.</param>
        /// <param name="value2">The value to test against.</param>
        /// <returns>The largest value that is less than or equal to the start value
        /// and also coprime to the other specified value.</returns>
        public static uint NearestCoprimeFloor(this uint start, uint value2) {
            if (start == 0) return 0;
            if (value2 == 0) return 1;
            while (!IsCoprime(start, value2)) start--;
            return start;
        }

        /// <summary>Computes the nearest number less than or equal to the
        /// specified start value that is coprime to another specified value.
        /// Returns 0 if no coprime was found in the range MinValue to start.</summary>
        /// <param name="start">The start value.</param>
        /// <param name="value2">The value to test against.</param>
        /// <returns>The largest value that is less than or equal to the start value
        /// and also coprime to the other specified value.</returns>
        public static int NearestCoprimeFloor(this int start, int value2) {
            uint v1, v2;
            v2 = (value2 >= 0) ? (uint)value2 : value2.AbsU();
            if (start > 0) return (int)NearestCoprimeFloor((uint)start, v2);
            if ((value2 == 0) && (start < -1)) return 0;
            for (v1 = start.AbsU(); v1 <= (uint)(-(int.MinValue + 1)) + 1; v1++) {
                if (v1.IsCoprime(v2)) return -(int)v1;
            }
            return 0;                
        }

        /// <summary>Computes the nearest number less than or equal to the
        /// specified start value that is coprime to another specified value.
        /// Returns 0 if no coprime was found in the range MinValue to start.</summary>
        /// <param name="start">The start value.</param>
        /// <param name="value2">The value to test against.</param>
        /// <returns>The largest value that is less than or equal to the start value
        /// and also coprime to the other specified value.</returns>
        public static ulong NearestCoprimeFloor(this ulong start, ulong value2) {
            if (start == 0) return 0;
            if (value2 == 0) return 1;
            while (!IsCoprime(start, value2)) start--;
            return start;
        }

        /// <summary>Computes the nearest number less than or equal to the
        /// specified start value that is coprime to another specified value.
        /// Returns 0 if no coprime was found in the range MinValue to start.</summary>
        /// <param name="start">The start value.</param>
        /// <param name="value2">The value to test against.</param>
        /// <returns>The largest value that is less than or equal to the start value
        /// and also coprime to the other specified value.</returns>
        public static long NearestCoprimeFloor(this long start, long value2) {
            ulong v1, v2;
            v2 = (value2 >= 0) ? (ulong)value2 : value2.AbsU();
            if (start > 0) return (long)NearestCoprimeFloor((ulong)start, v2);
            if ((v2 == 0) && (start < -1)) return 0;
            for (v1 = start.AbsU(); v1 <= (ulong)(-(long.MinValue + 1)) + 1; v1++) {
                if (v1.IsCoprime(v2)) return -(long)v1;
            }
            return 0;
        }

        /// <summary>Computes the nearest number greater than or equal to the
        /// specified start value that is coprime to another specified value.
        /// Returns 0 if no coprime was found in the range start to MaxValue.</summary>
        /// <param name="start">The start value.</param>
        /// <param name="value2">The value to test against.</param>
        /// <returns>The largest value that is less than or equal to the start value
        /// and also coprime to the other specified value.</returns>
        public static uint NearestCoprimeCeiling(this uint start, uint value2) {
            if ((value2 == 0) && (start > 1)) return 0;
            while (!IsCoprime(start, value2)) {
                if (start == uint.MaxValue) return 0;
                start++;
            }
            return start;
        }

        /// <summary>Computes the nearest number greater than or equal to the
        /// specified start value that is coprime to another specified value.
        /// Returns 0 if no coprime was found in the range start to MaxValue.</summary>
        /// <param name="start">The start value.</param>
        /// <param name="value2">The value to test against.</param>
        /// <returns>The largest value that is less than or equal to the start value
        /// and also coprime to the other specified value.</returns>
        public static int NearestCoprimeCeiling(this int start, int value2) {
            uint v1, v2;
            v2 = (value2 >= 0) ? (uint)value2 : value2.AbsU();
            if ((value2 == 0) && (start <= -1)) return -1;
            if ((start == int.MaxValue) || ((value2 == 0) && (start > 1))) return 0;
            v1 = start.AbsU();
            if (start >= 0) {
                while(!IsCoprime(v1, v2)) {
                    if (v1 == int.MaxValue) return 0;
                    v1++;
                }
                return (int)v1;
            } else {
                while (!IsCoprime(v1, v2)) v1--;
                return -(int)v1;
            }
        }

        /// <summary>Computes the nearest number greater than or equal to the
        /// specified start value that is coprime to another specified value.
        /// Returns 0 if no coprime was found in the range start to MaxValue.</summary>
        /// <param name="start">The start value.</param>
        /// <param name="value2">The value to test against.</param>
        /// <returns>The largest value that is less than or equal to the start value
        /// and also coprime to the other specified value.</returns>
        public static ulong NearestCoprimeCeiling(this ulong start, ulong value2) {
            if ((value2 == 0) && (start > 1)) return 0;
            while (!IsCoprime(start, value2)) {
                if (start == ulong.MaxValue) return 0;
                start++;
            }
            return start;
        }

        /// <summary>Computes the nearest number greater than or equal to the
        /// specified start value that is coprime to another specified value.
        /// Returns 0 if no coprime was found in the range start to MaxValue.</summary>
        /// <param name="start">The start value.</param>
        /// <param name="value2">The value to test against.</param>
        /// <returns>The largest value that is less than or equal to the start value
        /// and also coprime to the other specified value.</returns>
        public static long NearestCoprimeCeiling(this long start, long value2) {
            ulong v1, v2;
            v2 = (value2 >= 0) ? (ulong)value2 : value2.AbsU();
            if ((value2 == 0) && (start <= -1)) return -1;
            if ((start == int.MaxValue) || ((value2 == 0) && (start > 1))) return 0;
            v1 = start.AbsU();
            if (start >= 0) {
                while (!IsCoprime(v1, v2)) {
                    if (v1 == long.MaxValue) return 0;
                    v1++;
                }
                return (long)v1;
            } else {
                while (!IsCoprime(v1, v2)) v1--;
                return -(long)v1;
            }
        }

    }
}
/*
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/
