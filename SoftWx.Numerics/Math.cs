// Copyright ©2012-2015 SoftWx, Inc.
// Released under the MIT License the text of which appears at the end of this file.
// <authors> Steve Hatchett
namespace SoftWx.Numerics {
    public static class Math {
        /// <summary>Returns the absolute value of the specified signed value
        /// as a corresponding unsigned type. Absolute value of MinValue is 
        /// properly handled, without overflow.</summary>
        /// <param name="value">The value whose absolute value is desired.</param>
        /// <returns>The absolute value in the corresponding unsigned type.</returns>
        public static byte AbsU(this sbyte value) {
            unchecked {
                if (value > 0) return (byte)value;
                byte uVal = (byte)(value >> 7);
                return (byte)((((byte)value) + uVal) ^ uVal);
            }
        }

        /// <summary>Returns the absolute value of the specified signed value
        /// as a corresponding unsigned type. Absolute value of MinValue is 
        /// properly handled, without overflow.</summary>
        /// <param name="value">The value whose absolute value is desired.</param>
        /// <returns>The absolute value in the corresponding unsigned type.</returns>
        public static ushort AbsU(this short value) {
            unchecked {
                uint uVal = (uint)(value >> 15);
                return (ushort)((((uint)value) + uVal) ^ uVal);
            }
        }

        /// <summary>Returns the absolute value of the specified signed value
        /// as a corresponding unsigned type. Absolute value of MinValue is 
        /// properly handled, without overflow.</summary>
        /// <param name="value">The value whose absolute value is desired.</param>
        /// <returns>The absolute value in the corresponding unsigned type.</returns>
        public static uint AbsU(this int value) {
            unchecked {
                uint uVal = (uint)(value >> 31);
                return (((uint)value) + uVal) ^ uVal;
            }
        }

        /// <summary>Returns the absolute value of the specified signed value
        /// as a corresponding unsigned type. Absolute value of MinValue is 
        /// properly handled, without overflow.</summary>
        /// <param name="value">The value whose absolute value is desired.</param>
        /// <returns>The absolute value in the corresponding unsigned type.</returns>
        public static ulong AbsU(this long value) {
            unchecked {
                ulong uVal = (ulong)(value >> 63);
                return (((ulong)value) + uVal) ^ uVal;
            }
        }

        /// <summary>Compute the modulo (division remainder) of a number multiplied by another number.</summary>
        /// <remarks>Overflow safe for all input values. </remarks>
        /// <param name="value1">The number to be multiplied by value2.</param>
        /// <param name="value2">The number to be multiplied by value1.</param>
        /// <param name="modulus">The number by which to divide value raised to the exponent power.</param>
        /// <returns>The remainder after dividing the product of multiplying value1 and value2.</returns>
        public static byte MulMod(this byte value1, byte value2, byte modulus) {
            return (byte)((value1 * value2) % modulus);
        }

        /// <summary>Compute the modulo (division remainder) of a number multiplied by another number.</summary>
        /// <remarks>Overflow safe for all input values. </remarks>
        /// <param name="value1">The number to be multiplied by value2.</param>
        /// <param name="value2">The number to be multiplied by value1.</param>
        /// <param name="modulus">The number by which to divide value raised to the exponent power.</param>
        /// <returns>The remainder after dividing the product of multiplying value1 and value2.</returns>
        public static sbyte MulMod(this sbyte value1, sbyte value2, sbyte modulus) {
            if (modulus <= 0) return 0;
            return (sbyte)((value1 * value2) % modulus);
        }

        public static ushort MulMod(this ushort value1, ushort value2, ushort modulus) {
            return (ushort)((value1 * value2) % modulus);
        }

        /// <summary>Compute the modulo (division remainder) of a number multiplied by another number.</summary>
        /// <remarks>Overflow safe for all input values. </remarks>
        /// <param name="value1">The number to be multiplied by value2.</param>
        /// <param name="value2">The number to be multiplied by value1.</param>
        /// <param name="modulus">The number by which to divide value raised to the exponent power.</param>
        /// <returns>The remainder after dividing the product of multiplying value1 and value2.</returns>
        public static short MulMod(this short value1, short value2, short modulus) {
            if (modulus <= 0) return 0;
            return (short)((value1 * value2) % modulus);
        }

        /// <summary>Compute the modulo (division remainder) of a number multiplied by another number.</summary>
        /// <remarks>Overflow safe for all input values. </remarks>
        /// <param name="value1">The number to be multiplied by value2.</param>
        /// <param name="value2">The number to be multiplied by value1.</param>
        /// <param name="modulus">The number by which to divide value raised to the exponent power.</param>
        /// <returns>The remainder after dividing the product of multiplying value1 and value2.</returns>
        public static uint MulMod(this uint value1, uint value2, uint modulus) {
            return (uint)(((ulong)value1 * value2) % modulus);
        }

        /// <summary>Compute the modulo (division remainder) of a number multiplied by another number.</summary>
        /// <remarks>Overflow safe for all input values. </remarks>
        /// <param name="value1">The number to be multiplied by value2.</param>
        /// <param name="value2">The number to be multiplied by value1.</param>
        /// <param name="modulus">The number by which to divide value raised to the exponent power.</param>
        /// <returns>The remainder after dividing the product of multiplying value1 and value2.</returns>
        public static int MulMod(this int value1, int value2, int modulus) {
            if (modulus <= 0) return 0;
            return (int)(((long)value1 * value2) % modulus);
        }

        /// <summary>Compute the modulo (division remainder) of a number multiplied by another number.</summary>
        /// <remarks>Overflow safe for all input values. </remarks>
        /// <param name="value1">The number to be multiplied by value2.</param>
        /// <param name="value2">The number to be multiplied by value1.</param>
        /// <param name="modulus">The number by which to divide value raised to the exponent power.</param>
        /// <returns>The remainder after dividing the product of multiplying value1 and value2.</returns>
        public static ulong MulMod(this ulong value1, ulong value2, ulong modulus) {
            return UInt128.Multiply(value1, value2) % modulus;
        }

        /// <summary>Compute the modulo (division remainder) of a number multiplied by another number.</summary>
        /// <remarks>Overflow safe for all input values. </remarks>
        /// <param name="value1">The number to be multiplied by value2.</param>
        /// <param name="value2">The number to be multiplied by value1.</param>
        /// <param name="modulus">The number by which to divide value raised to the exponent power.</param>
        /// <returns>The remainder after dividing the product of multiplying value1 and value2.</returns>
        public static long MulMod(this long value1, long value2, long modulus) {
            if (modulus <= 0) return 0;
            unchecked {
                if ((value1 | value2) >= 0) return (long)MulMod((ulong)value1, (ulong)value2, (ulong)modulus);
                return ((1 | (value1 ^ value2)>>63)) * (long)MulMod(value1.AbsU(), value2.AbsU(), (ulong)modulus);
            }
        }

        /// <summary>Compute the modulo (division remainder) of a number raised to the power
        /// of another number.</summary>
        /// <remarks>Overflow safe for all input values. </remarks>
        /// <param name="value">The number to raise to the exponent power.</param>
        /// <param name="exponent">The exponent to raise value by.</param>
        /// <param name="modulus">The number by which to divide value raised to the exponent power.</param>
        /// <returns>The remainder after dividing value raised to the exponent power.</returns>
        public static uint ModPow(this uint value, uint exponent, uint modulus) {
            value %= modulus;
            if ((value | modulus) == 0) return 0;
            switch (exponent) {
                case 0: return 1;
                case 1: return value % modulus;
                case 2: return (value == (ushort)value) ? (value * value) % modulus : (uint)((value * (ulong)value) % modulus);
                default:
                    uint result = 1;
                    if (modulus == (ushort)modulus) return ModPow(value, exponent, (ushort)modulus);
                    while (true) {
                        if ((exponent & 1) != 0) {
                            result = (uint)((result * (ulong)value) % modulus);
                            if (exponent == 1) return result;
                        }
                        exponent /= 2;
                        value = (uint)((value * (ulong)value) % modulus);
                    }
            }
        }

        private static uint ModPow(this uint v, uint e, ushort m) {
            uint result = 1;
            while (true) {
                if ((e & 1) != 0) {
                    result = (result * v) % m;
                    if (e == 1) return result;
                }
                e /= 2;
                v = (v * v) % m;
            }
        }

        /// <summary>Compute the modulo (division remainder) of a number raised to the power
        /// of another number.</summary>
        /// <remarks>Overflow safe for all input values. </remarks>
        /// <param name="value">The number to raise to the exponent power.</param>
        /// <param name="exponent">The exponent to raise value by.</param>
        /// <param name="modulus">The number by which to divide value raised to the exponent power.</param>
        /// <returns>The remainder after dividing value raised to the exponent power.</returns>
        public static ulong ModPow(this ulong value, ulong exponent, ulong modulus) {
            value %= modulus;
            //if ((m == 0) || (b == 0)) return 0;
            if ((modulus | value) == 0) return 0;
            if (exponent < 3) {
                if (exponent == 0) return 1;
                if (exponent == 1) return value;
                if (exponent == 2) return UInt128.Square(value).Mod(modulus);
            }
            if (modulus == (uint)modulus) return ModPow((uint)value, exponent, (uint)modulus);
            ulong result = 1;
            while (true) {
                if ((exponent & 1) != 0) {
                    result = UInt128.Multiply(result, value).Mod(modulus);
                    if (exponent == 1) return result;
                }
                exponent /= 2;
                value = UInt128.Square(value).Mod(modulus);
            }
        }

        private static uint ModPow(this uint v, ulong e, uint m) {
            uint result = 1;
            while (true) {
                if ((e & 1) != 0) {
                    result = (uint)((result * (ulong)v) % m);
                    if (e == 1) return result;
                }
                e /= 2;
                v = (uint)((v * (ulong)v) % m);
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
