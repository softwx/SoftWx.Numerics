// Copyright ©2012-2015 SoftWx, Inc.
// Released under the MIT License the text of which appears at the end of this file.
// <authors> Steve Hatchett
namespace SoftWx.Numerics {
    /// <summary>
    /// Numeric extension methods for base 2 math operations on integer numeric types.
    /// </summary>
    public static class Base2Math {
        /// <summary>Returns the integer logarithm base 2 (Floor(Log2(value))) of the specified value
        /// , or MaxValue if value is less than 1, to denote Log2 is undefined for such values.</summary>
        /// <remarks>Example: Log2(10) returns 3.</remarks>
        /// <param name="value">The value whose base 2 log is desired.</param>
        /// <returns>The base 2 log of a positive integer, or MaxValue when the value is less than 1.</returns>
        public static byte Log2(this byte value) {
            return (byte)BitMath.HighBitPosition(value);
        }

        /// <summary>Returns the integer logarithm base 2 (Floor(Log2(value))) of the specified value
        /// , or -1 if value is less than 1, to denote Log2 is undefined for such values.</summary>
        /// <remarks>Example: Log2(10) returns 3.</remarks>
        /// <param name="value">The value whose base 2 log is desired.</param>
        /// <returns>The base 2 log of a positive integer, or -1 when the value is less than 1.</returns>
        public static sbyte Log2(this sbyte value) {
            return (value > 0) ? (sbyte)BitMath.HighBitPosition(value) : (sbyte)-1;
        }

        /// <summary>Returns the integer logarithm base 2 (Floor(Log2(value))) of the specified value
        /// , or MaxValue if value is less than 1, to denote Log2 is undefined for such values.</summary>
        /// <remarks>Example: Log2(10) returns 3.</remarks>
        /// <param name="value">The value whose base 2 log is desired.</param>
        /// <returns>The base 2 log of a positive integer, or MaxValue when the value is less than 1.</returns>
        public static ushort Log2(this ushort value) {
            return (ushort)BitMath.HighBitPosition(value);
        }

        /// <summary>Returns the integer logarithm base 2 (Floor(Log2(value))) of the specified value
        /// , or -1 if value is less than 1, to denote Log2 is undefined for such values.</summary>
        /// <remarks>Example: Log2(10) returns 3.</remarks>
        /// <param name="value">The value whose base 2 log is desired.</param>
        /// <returns>The base 2 log of a positive integer, or -1 when the value is less than 1.</returns>
        public static short Log2(this short value) {
            return (value > 0) ? (short)BitMath.HighBitPosition(value) : (short)-1;
        }

        /// <summary>Returns the integer logarithm base 2 (Floor(Log2(value))) of the specified value
        /// , or MaxValue if value is less than 1, to denote Log2 is undefined for such values.</summary>
        /// <remarks>Example: Log2(10) returns 3.</remarks>
        /// <param name="value">The value whose base 2 log is desired.</param>
        /// <returns>The base 2 log of a positive integer, or MaxValue when the value is less than 1.</returns>
        public static uint Log2(this uint value) {
            return (uint)BitMath.HighBitPosition(value);
        }

        /// <summary>Returns the integer logarithm base 2 (Floor(Log2(value))) of the specified value
        /// , or -1 if value is less than 1, to denote Log2 is undefined for such values.</summary>
        /// <remarks>Example: Log2(10) returns 3.</remarks>
        /// <param name="value">The value whose base 2 log is desired.</param>
        /// <returns>The base 2 log of a positive integer, or -1 when the value is less than 1.</returns>
        public static int Log2(this int value) {
            return (value > 0) ? BitMath.HighBitPosition(value) : -1;
        }

        /// <summary>Returns the integer logarithm base 2 (Floor(Log2(value))) of the specified value
        /// , or MaxValue if value is less than 1, to denote Log2 is undefined for such values.</summary>
        /// <remarks>Example: Log2(10) returns 3.</remarks>
        /// <param name="value">The value whose base 2 log is desired.</param>
        /// <returns>The base 2 log of a positive integer, or MaxValue when the value is less than 1.</returns>
        public static ulong Log2(this ulong value) {
            return (ulong)BitMath.HighBitPosition(value);
        }

        /// <summary>Returns the integer logarithm base 2 (Floor(Log2(value))) of the specified value
        /// , or -1 if value is less than 1, to denote Log2 is undefined for such values.</summary>
        /// <remarks>Example: Log2(10) returns 3.</remarks>
        /// <param name="value">The value whose base 2 log is desired.</param>
        /// <returns>The base 2 log of a positive integer, or -1 when the value is less than 1.</returns>
        public static long Log2(this long value) {
            return (value > 0) ? BitMath.HighBitPosition(value) : -1L;
        }
        /// <summary>Determines if the specified value is a power of 2.</summary>
        /// <param name="value">The value to be tested as a power of 2.</param>
        /// <returns>True if the value is a power of 2, otherwise false.</returns>
        public static bool IsPowerOf2(this byte value) {
            return ((value & unchecked(value - 1)) == 0) && (value != 0);
        }

        /// <summary>Determines if the specified value is a power of 2.</summary>
        /// <param name="value">The value to be tested as a power of 2.</param>
        /// <returns>True if the value is a power of 2, otherwise false.</returns>
        public static bool IsPowerOf2(this sbyte value) {
            return ((value & unchecked(value - 1)) == 0) && (value > 0);
        }

        /// <summary>Determines if the specified value is a power of 2.</summary>
        /// <param name="value">The value to be tested as a power of 2.</param>
        /// <returns>True if the value is a power of 2, otherwise false.</returns>
        public static bool IsPowerOf2(this ushort value) {
            return ((value & unchecked(value - 1)) == 0) && (value != 0);
        }

        /// <summary>Determines if the specified value is a power of 2.</summary>
        /// <param name="value">The value to be tested as a power of 2.</param>
        /// <returns>True if the value is a power of 2, otherwise false.</returns>
        public static bool IsPowerOf2(this short value) {
            return ((value & unchecked(value - 1)) == 0) && (value > 0);
        }

        /// <summary>Determines if the specified value is a power of 2.</summary>
        /// <param name="value">The value to be tested as a power of 2.</param>
        /// <returns>True if the value is a power of 2, otherwise false.</returns>
        public static bool IsPowerOf2(this uint value) {
            return ((value & unchecked(value - 1)) == 0) && (value != 0);
        }

        /// <summary>Determines if the specified value is a power of 2.</summary>
        /// <param name="value">The value to be tested as a power of 2.</param>
        /// <returns>True if the value is a power of 2, otherwise false.</returns>
        public static bool IsPowerOf2(this int value) {
            return ((value & unchecked(value - 1)) == 0) && (value > 0);
        }

        /// <summary>Determines if the specified value is a power of 2.</summary>
        /// <param name="value">The value to be tested as a power of 2.</param>
        /// <returns>True if the value is a power of 2, otherwise false.</returns>
        public static bool IsPowerOf2(this ulong value) {
            return ((value & unchecked(value - 1UL)) == 0) && (value != 0);
        }

        /// <summary>Determines if the specified value is a power of 2.</summary>
        /// <param name="value">The value to be tested as a power of 2.</param>
        /// <returns>True if the value is a power of 2, otherwise false.</returns>
        public static bool IsPowerOf2(this long value) {
            return ((value & unchecked(value - 1L)) == 0) && (value > 0);
        }

        /// <summary>Returns the nearest power of 2 that's equal or less than the specified value.</summary>
        /// <remarks>Example: PowerOf2Floor(10) returns 8.</remarks>
        /// <param name="value">The value whose nearest power of 2 is desired.</param>
        /// <returns>The nearest power of 2 that's equal or less than the value parameter,
        /// or 0 if the value is less than 1.</returns>
        public static byte PowerOf2Floor(this byte value) {
            return BitMath.HighBit(value);
        }

        /// <summary>Returns the nearest power of 2 that's equal or less than the specified value.</summary>
        /// <remarks>Example: PowerOf2Floor(10) returns 8.</remarks>
        /// <param name="value">The value whose nearest power of 2 is desired.</param>
        /// <returns>The nearest power of 2 that's equal or less than the value parameter,
        /// or 0 if the value is less than 1.</returns>
        public static sbyte PowerOf2Floor(this sbyte value) {
            //return (value > 0) ? BitMath.HighBit(value): (sbyte)0;
            return (sbyte)(BitMath.HighBit(value) & ~(value >> 7));
        }

        /// <summary>Returns the nearest power of 2 that's equal or less than the specified value.</summary>
        /// <remarks>Example: PowerOf2Floor(10) returns 8.</remarks>
        /// <param name="value">The value whose nearest power of 2 is desired.</param>
        /// <returns>The nearest power of 2 that's equal or less than the value parameter,
        /// or 0 if the value is less than 1.</returns>
        public static ushort PowerOf2Floor(this ushort value) {
            return BitMath.HighBit(value);
        }

        /// <summary>Returns the nearest power of 2 that's equal or less than the specified value.</summary>
        /// <remarks>Example: PowerOf2Floor(10) returns 8.</remarks>
        /// <param name="value">The value whose nearest power of 2 is desired.</param>
        /// <returns>The nearest power of 2 that's equal or less than the value parameter,
        /// or 0 if the value is less than 1.</returns>
        public static short PowerOf2Floor(this short value) {
            return (short)PowerOf2Floor((int)value);
        }

        /// <summary>Returns the nearest power of 2 that's equal or less than the specified value.</summary>
        /// <remarks>Example: PowerOf2Floor(10) returns 8.</remarks>
        /// <param name="value">The value whose nearest power of 2 is desired.</param>
        /// <returns>The nearest power of 2 that's equal or less than the value parameter,
        /// or 0 if the value is less than 1.</returns>
        public static uint PowerOf2Floor(this uint value) {
            return BitMath.HighBit(value);
        }

        /// <summary>Returns the nearest power of 2 that's equal or less than the specified value.</summary>
        /// <remarks>Example: PowerOf2Floor(10) returns 8.</remarks>
        /// <param name="value">The value whose nearest power of 2 is desired.</param>
        /// <returns>The nearest power of 2 that's equal or less than the value parameter,
        /// or 0 if the value is less than 1.</returns>
        public static int PowerOf2Floor(this int value) {
            return (value > 0) ? BitMath.HighBit(value): 0;
        }

        /// <summary>Returns the nearest power of 2 that's equal or less than the specified value.</summary>
        /// <remarks>Example: PowerOf2Floor(10) returns 8.</remarks>
        /// <param name="value">The value whose nearest power of 2 is desired.</param>
        /// <returns>The nearest power of 2 that's equal or less than the value parameter,
        /// or 0 if the value is less than 1.</returns>
        public static ulong PowerOf2Floor(this ulong value) {
            return BitMath.HighBit(value);
        }

        /// <summary>Returns the nearest power of 2 that's equal or less than the specified value.</summary>
        /// <remarks>Example: PowerOf2Floor(10) returns 8.</remarks>
        /// <param name="value">The value whose nearest power of 2 is desired.</param>
        /// <returns>The nearest power of 2 that's equal or less than the value parameter,
        /// or 0 if the value is less than 1.</returns>
        public static long PowerOf2Floor(this long value) {
            return (value > 0) ? BitMath.HighBit(value) : 0;
        }

        /// <summary>Returns the nearest power of 2 that's equal or greater than the specified value.</summary>
        /// <remarks>Example: PowerOf2Ceiling(10) returns 16.</remarks>
        /// <param name="value">The value whose nearest power of 2 is desired.</param>
        /// <returns>The nearest power of 2 that's equal or greater than the value parameter,
        /// or 0 if the result would be greater than the type's maximum value.</returns>
        public static byte PowerOf2Ceiling(this byte value) {
            if (value == 0) return 1;
            uint v = value;
            v--;
            v |= v >> 1;
            v |= v >> 2;
            return (byte)unchecked((v | (v >> 4)) + 1);
        }

        /// <summary>Returns the nearest power of 2 that's equal or greater than the specified value.</summary>
        /// <remarks>Example: PowerOf2Ceiling(10) returns 16.</remarks>
        /// <param name="value">The value whose nearest power of 2 is desired.</param>
        /// <returns>The nearest power of 2 that's equal or greater than the value parameter,
        /// or 0 if the result would be greater than the type's maximum value.</returns>
        public static sbyte PowerOf2Ceiling(this sbyte value) {
            if (value <= 1) return 1;
            uint v = (uint)value;
            v--;
            v |= v >> 1;
            v |= v >> 2;
            return (sbyte)(sbyte.MaxValue & unchecked((v | (v >> 4)) + 1));
        }

        /// <summary>Returns the nearest power of 2 that's equal or greater than the specified value.</summary>
        /// <remarks>Example: PowerOf2Ceiling(10) returns 16.</remarks>
        /// <param name="value">The value whose nearest power of 2 is desired.</param>
        /// <returns>The nearest power of 2 that's equal or greater than the value parameter,
        /// or 0 if the result would be greater than the type's maximum value.</returns>
        public static ushort PowerOf2Ceiling(this ushort value) {
            if (value == 0) return 1;
            uint v = value;
            v--;
            v |= v >> 1;
            v |= v >> 2;
            v |= v >> 4;
            return (ushort)unchecked((v | (v >> 8)) + 1);
        }

        /// <summary>Returns the nearest power of 2 that's equal or greater than the specified value.</summary>
        /// <remarks>Example: PowerOf2Ceiling(10) returns 16.</remarks>
        /// <param name="value">The value whose nearest power of 2 is desired.</param>
        /// <returns>The nearest power of 2 that's equal or greater than the value parameter,
        /// or 0 if the result would be greater than the type's maximum value.</returns>
        public static short PowerOf2Ceiling(this short value) {
            if (value <= 1) return 1;
            uint v = (uint)value;
            v--;
            v |= v >> 1;
            v |= v >> 2;
            v |= v >> 4;
            return (short)(short.MaxValue & unchecked((v | (v >> 8)) + 1));
        }

        /// <summary>Returns the nearest power of 2 that's equal or greater than the specified value.</summary>
        /// <remarks>Example: PowerOf2Ceiling(10) returns 16.</remarks>
        /// <param name="value">The value whose nearest power of 2 is desired.</param>
        /// <returns>The nearest power of 2 that's equal or greater than the value parameter,
        /// or 0 if the result would be greater than the type's maximum value.</returns>
        public static uint PowerOf2Ceiling(this uint value) {
            if (value == 0) return 1;
            value--;
            value |= value >> 1;
            value |= value >> 2;
            value |= value >> 4;
            value |= value >> 8;
            return unchecked((value | (value >> 16)) + 1);
        }

        /// <summary>Returns the nearest power of 2 that's equal or greater than the specified value.</summary>
        /// <remarks>Example: PowerOf2Ceiling(10) returns 16.</remarks>
        /// <param name="value">The value whose nearest power of 2 is desired.</param>
        /// <returns>The nearest power of 2 that's equal or greater than the value parameter,
        /// or 0 if the result would be greater than the type's maximum value.</returns>
        public static int PowerOf2Ceiling(this int value) {
            if (value <= 1) return 1;
            value--;
            value |= value >> 1;
            value |= value >> 2;
            value |= value >> 4;
            value |= value >> 8;
            return int.MaxValue & unchecked((value | (value >> 16)) + 1);
        }

        /// <summary>Returns the nearest power of 2 that's equal or greater than the specified value.</summary>
        /// <remarks>Example: PowerOf2Ceiling(10) returns 16.</remarks>
        /// <param name="value">The value whose nearest power of 2 is desired.</param>
        /// <returns>The nearest power of 2 that's equal or greater than the value parameter,
        /// or 0 if the result would be greater than the type's maximum value.</returns>
        public static ulong PowerOf2Ceiling(this ulong value) {
            if (value == 0) return 1;
            value--;
            value |= value >> 1;
            value |= value >> 2;
            value |= value >> 4;
            value |= value >> 8;
            value |= value >> 16;
            return unchecked((value | (value >> 32)) + 1);
        }

        /// <summary>Returns the nearest power of 2 that's equal or greater than the specified value.</summary>
        /// <remarks>Example: PowerOf2Ceiling(10) returns 16.</remarks>
        /// <param name="value">The value whose nearest power of 2 is desired.</param>
        /// <returns>The nearest power of 2 that's equal or greater than the value parameter,
        /// or 0 if the result would be greater than the type's maximum value.</returns>
        public static long PowerOf2Ceiling(this long value) {
            if (value <= 1) return 1;
            value--;
            value |= value >> 1;
            value |= value >> 2;
            value |= value >> 4;
            value |= value >> 8;
            value |= value >> 16;
            return long.MaxValue & unchecked((value | (value >> 32)) + 1);
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
