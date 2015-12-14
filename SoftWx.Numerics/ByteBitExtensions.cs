// Copyright ©2012-2015 SoftWx, Inc.
// Released under the MIT License the text of which appears at the end of this file.
// <authors> Steve Hatchett

using System;

namespace SoftWx.Numerics
{
    /// <summary>
    /// Extension methods that operate on byte (8 bit unsigned integer) values.
    /// </summary>
    /// <remarks>Many of the bit fiddling methods are the result of benchmarking
    /// various alternate algorithms presented on Sean Eron Anderson's page
    /// http://graphics.stanford.edu/~seander/bithacks.html
    /// sometimes with minor improvements for C#, and choosing compact
    /// alternatives that perform well in C# for the byte (unsigned 8 bit integer) 
    /// data type.</remarks>
    public static class ByteBitExtensions
    {
        /// <summary>Lookup table for bit position of most significant bit.</summary>
        internal static readonly byte[] msbPos256 = new byte[256];
        static ByteBitExtensions()
        {
            msbPos256[0] = 8; // special value for when there are no set bits
            msbPos256[1] = 0;
            for (int i = 2; i < 256; i++) msbPos256[i] = (byte)(1 + msbPos256[i / 2]);
        }

        /// <summary>
        /// Returns the integer logarithm base 2 (Floor(Log2(number))) of the specified number.
        /// </summary>
        /// <remarks>Example: Log2(10) returns 3.</remarks>
        /// <param name="number">The number whose base 2 log is desired.</param>
        /// <returns>The base 2 log of the number greater than 0, or 0 when the number
        /// equals 0.</returns>
        public static byte Log2(this byte value)
        {
            return msbPos256[value | 1];
        }

        /// <summary>
        /// Determines if the specified value is a power of 2.
        /// </summary>
        /// <param name="value">The value to be tested as a power of 2.</param>
        /// <returns>True if the value is a power of 2, otherwise false.</returns>
        public static bool IsPowerOf2(this byte value)
        {
            return (value != 0) && (value == LowBit(value));
        }

        /// <summary>
        /// Returns the nearest power of 2 that's equal or less than the specified number.
        /// </summary>
        /// <remarks>Example: PowerOf2Floor(10) returns 8.</remarks>
        /// <param name="number">The number whose nearest power of 2 is desired.</param>
        /// <returns>The nearest power of 2 that's equal or less than the value parameter,
        /// or 0 if the value is 0.</returns>
        public static byte PowerOf2Floor(this byte value)
        {
            return HighBit(value);
        }

        /// <summary>
        /// Returns the nearest power of 2 that's equal or greater than the specified number.
        /// </summary>
        /// <remarks>Example: PowerOf2Ceiling(10) returns 16.</remarks>
        /// <param name="number">The number whose nearest power of 2 is desired.</param>
        /// <returns>The nearest power of 2 that's equal or greater than the value parameter,
        /// or 0 if the result would be greater than the type's maximum value.</returns>
        public static byte PowerOf2Ceiling(this byte value)
        {
            return unchecked((byte)((value > 1) ? 2 << msbPos256[value - 1] : 1));
        }

        // bit fidding methods

        /// <summary>Returns the most significant set bit of the specified number.</summary>
        /// <remarks>Example: HighBit(10) returns 8, i.e. high bit of 00001010 is 00001000.</remarks>
        /// <param name="value">The value whose most significant bit is desired.</param>
        /// <returns>The value parameter's the most significant bit.</returns>
        public static byte HighBit(this byte value)
        {
            return unchecked((byte)(1 << msbPos256[value]));
        }

        /// <summary>Returns the least significant set bit of the specified number.</summary>
        /// <remarks>Example: LowBit(10) returns 2, i.e. low bit of 00001010 is 00000010.</remarks>
        /// <param name="value">The value whose least significant bit is desired.</param>
        /// <returns>The value parameter's the least significant bit.</returns>
        public static byte LowBit(this byte value)
        {
            return (byte)(value & -value);
        }

        /// <summary>Returns the most significant set bit position of the specified number,
        /// or 8 (byte.MaxValue.HighBitPosition()+1) if no bits were set. The least 
        /// significant bit position is 0.</summary>
        /// <remarks>Example: HighBitPosition(10) returns 3, i.e. high bit of 00001010 is position 3.</remarks>
        /// <param name="value">The value whose most significant bit position is desired.</param>
        /// <returns>The value parameter's most significant bit position.</returns>
        public static byte HighBitPosition(this byte value)
        {
            return msbPos256[value];
        }

        /// <summary>Returns the least significant set bit position of the specified number,
        /// or 8 (byte.MaxValue.HighBitPosition()+1) if no bits were set. The least
        /// significant bit position is 0.</summary>
        /// <remarks>Example: LowBitPosition(10) returns 1, i.e. low bit of 00001010 is position 1.</remarks>
        /// <param name="value">The value whose least significant bit position is desired.</param>
        /// <returns>The value parameter's least significant bit position.</returns>
        public static byte LowBitPosition(this byte value)
        {
            return msbPos256[value & -value];
        }

        /// <summary>Returns the count of leading zero bits in the specified number.</summary>
        /// <remarks>Example: LeadingZeroBits(10) returns 4, i.e. 00001010 has 4 leading 0 bits.</remarks>
        /// <param name="value">The value whose leading zero bit count is desired.</param>
        /// <returns>The count of the value parameter's leading zero bits.</returns>
        public static byte LeadingZeroBits(this byte value)
        {
            return msbPos256[0x80 >> msbPos256[value]];
        }

        /// <summary>Returns the count of trailing zero bits in the specified number.</summary>
        /// <remarks>Example: TrailingZeroBits(10) returns 1, i.e. 00001010 has 1 trailing 0 bit.</remarks>
        /// <param name="value">The value whose trailing zero bit count is desired.</param>
        /// <returns>The count of the value parameter's trailing zero bits.</returns>
        public static byte TrailingZeroBits(this byte value)
        {
            return LowBitPosition(value);
        }
        public static sbyte TrailingZeroBits(this sbyte value) {
            return (sbyte)LowBitPosition((byte)value);
        }
        /// <summary>Returns the count of set bits in the specified number.</summary>
        /// <param name="value">The value whose bit count is desired.</param>
        /// <returns>The count of set bits in the specified number.</returns>
        public static byte BitCount(this byte value) {
            int v = value - ((value >> 1) & 0x55);
            v = (v & 0x33) + ((v >> 2) & 0x33);
            return unchecked((byte)((v + (v >> 4) & 0x0F)));
        }

        /// <summary>
        /// Returns the specified number with all bits reversed 
        /// (i.e. 01001101 is returned as 10110010).
        /// </summary>
        /// <param name="value">The value to be reversed.</param>
        /// <returns>The reversed bits of the specified number.</returns>
        public static byte ReverseBits(this byte value)
        {
            uint v = (uint)value;
            return unchecked((byte)(((v * 0x0802u & 0x22110u) | (v * 0x8020u & 0x88440u)) * 0x10101u >> 16));
        }
        public static sbyte ReverseBits2(this sbyte value) {
            uint v = (uint)(byte)value;
            return unchecked((sbyte)(((v * 0x0802u & 0x22110u) | (v * 0x8020u & 0x88440u)) * 0x10101u >> 16));
        }
        public static sbyte ReverseBits(this sbyte value) { return (sbyte)ReverseBits((byte)value); }
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
