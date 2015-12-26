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

        public static byte MulMod(this byte value1, byte value2, byte modulus) {
            return (byte)((value1 * value2) % modulus);
        }

        public static sbyte MulMod(this sbyte value1, sbyte value2, sbyte modulus) {
            if (modulus <= 0) return 0;
            return (sbyte)((value1 * value2) % modulus);
        }

        public static ushort MulMod(this ushort value1, ushort value2, ushort modulus) {
            return (ushort)((value1 * value2) % modulus);
        }

        public static short MulMod(this short value1, short value2, short modulus) {
            if (modulus <= 0) return 0;
            return (short)((value1 * value2) % modulus);
        }

        public static uint MulMod(this uint value1, uint value2, uint modulus) {
            return (uint)(((ulong)value1 * value2) % modulus);
        }

        public static int MulMod(this int value1, int value2, int modulus) {
            if (modulus <= 0) return 0;
            return (int)(((long)value1 * value2) % modulus);
        }

        // from Craig McQueen's answer at http://stackoverflow.com/questions/12168348/ways-to-do-modulo-multiplication-with-primitive-types
        public static ulong MulMod(this ulong value1, ulong value2, ulong modulus) {
            // ensuring a is the smaller value increases chances that the
            // while loop below will be able to exit early
            if (value2 < value1) return InternalMulMod(value2, value1, modulus);
            return InternalMulMod(value1, value2, modulus);
        }
        private static ulong InternalMulMod(this ulong value1, ulong value2, ulong modulus) {
            ulong res = 0;
            ulong temp;
            ulong halfMod = modulus >> 1;
            unchecked {
                while (value1 != 0) {
                    temp = (value1 & 1) * value2;
                    value1 >>= 1;
                    // add value2 to res, modulo modulus, without overflow
                    if (temp >= modulus - res) res -= modulus;
                    res += temp;

                    //value2 * 2 mod modulus
                    temp = value2;
                    value2 += value2;
                    if (temp >= halfMod) value2 -= modulus;
                }
            }
            return res;
        }

        public static long MulMod(this long value1, long value2, long modulus) {
            if (modulus <= 0) return 0;
            unchecked {
                if ((value1 | value2) >= 0) return (long)MulMod((ulong)value1, (ulong)value2, (ulong)modulus);
                return ((1 | (value1 ^ value2)>>63)) * (long)MulMod(value1.AbsU(), value2.AbsU(), (ulong)modulus);
            }
        }

        /// <summary>Compute the mod of a number raised to the specified power.</summary>
        /// <remarks>Overflow safe for all input values. </remarks>
        /// <param name="b">The base number.</param>
        /// <param name="e">The exponent applied to the base number.</param>
        /// <param name="m">The modulo value.</param>
        /// <returns>The mod of the base number raised to the specified power.</returns>
        public static uint ModPow(this uint b, uint e, uint m) {
            const uint sqrtMax = 65535; // (uint)Math.Sqrt(uint.MaxValue);
            if ((b | m) == 0) return 0;
            switch (e) {
                case 0: return 1;
                case 1: return b % m;
                case 2: return (b > sqrtMax) ? (uint)((b * (ulong)b) % m) : (b * b) % m;
                default:
                    uint result = 1;
                    if (m > sqrtMax) {
                        while (true) {
                            if ((e & 1) != 0) {
                                result = (uint)((result * (ulong)b) % m);
                                if (e == 1) return result;
                            }
                            e /= 2;
                            b = (uint)((b * (ulong)b) % m);
                        }
                    } else {
                        b %= m;
                        while (true) {
                            if ((e & 1) != 0) {
                                result = (result * b) % m;
                                if (e == 1) return result;
                            }
                            e /= 2;
                            b = (b * b) % m;
                        }
                    }
            }
        }

        /// <summary>Compute the mod of a number raised to the specified power.</summary>
        /// <remarks>Overflow safe for all input values. </remarks>
        /// <param name="b">The base number.</param>
        /// <param name="e">The exponent applied to the base number.</param>
        /// <param name="m">The modulo value.</param>
        /// <returns>The mod of the base number raised to the specified power.</returns>
        public static ulong ModPow(this ulong b, ulong e, ulong m) {
            const ulong sqrtMax = uint.MaxValue; // (uint)Math.Sqrt(uint.MaxValue);
            if ((m == 0) || ((b %= m) == 0)) return 0;
            //switch (e) {
            //case 0: return 1;
            //case 1: return b % m;
            ////case 2: return (b <= sqrtMax) ? (b * b) % m : ModPow(b*b, e, m);
            //default:
            if (e < 3) {
                if (e == 0) return 1;
                if (e == 1) return b % m;
                if ((e == 2) && (b <= sqrtMax)) return (b * b) % m;
            }
            ulong result = 1;
            if (m > sqrtMax) {
                while (true) {
                    if ((e & 1) != 0) {
                        result = MulMod(result, b, m);
                        if (e == 1) return result;
                    }
                    e >>= 1;// /= 2;
                    b = MulMod(b, b, m);
                }
            } else {
                b %= m;
                while (true) {
                    if ((e & 1) != 0) {
                        result = (result * b) % m;
                        if (e == 1) return result;
                    }
                    e >>= 1;// /= 2;
                    b = (b * b) % m;
                }
            }
            //}
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
