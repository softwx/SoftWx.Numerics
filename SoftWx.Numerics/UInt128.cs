//#define StandaloneUInt128 // if StandaloneUInt128 is defined UInt128 can operate standalone, without needing other classes in SoftWx.Numerics
// comment the #define if UInt128 is used as part of the SoftWx.Numerics library
namespace SoftWx.Numerics {
    /// <summary>Represents a 128-bit unsigned integer.</summary>
    /// <remarks>The UInt128 struct is immutable.</remarks>
    public struct UInt128 {
        private readonly ulong hi;
        private readonly ulong lo;

        /// <summary>Gets a value that represents the number 0 (zero).</summary>
        public readonly static UInt128 Zero = new UInt128(0, 0);

        /// <summary>Gets a value that represents the number 1 (one).</summary>
        public readonly static UInt128 One = new UInt128(0, 1);

        /// <summary>Represents the largest possible value of UInt128.</summary>
        public readonly static UInt128 MaxValue = new UInt128(ulong.MaxValue, ulong.MaxValue);

        /// <summary>Represents the smallest possible value of UInt128.</summary>
        public readonly static UInt128 MinValue = UInt128.Zero;

        /// <summary>Computes the 128 bit product of two 64 bit unsigned integers.</summary>
        /// <param name="left">The value to be multiplied by right.</param>
        /// <param name="right">The value to be multiplied by left.</param>
        /// <returns>The UInt128 product of multiplying left and right.</returns>
        public static UInt128 Multiply(ulong left, ulong right) {
            unchecked {
                ulong lhi = left >> 32;
                ulong rhi = right >> 32;
                ulong high = (uint)right * (ulong)(uint)left;
                ulong low = (uint)high;
                high >>= 32;
                high += lhi * (uint)right;
                ulong midHi = (high >> 32);
                midHi += (lhi * rhi);
                high = (uint)high;
                high += (rhi * (uint)left);
                low += (high << 32);
                high >>= 32;
                return new UInt128(high + midHi, low);
            }
        }

        /// <summary>Computes the 128 bit product of squaring a 64 bit unsigned integer.</summary>
        /// <param name="value">The value to be squared (multiplied by itself).</param>
        /// <returns>The UInt128 product of squaring the specified value.</returns>
        public static UInt128 Square(ulong value) {
            unchecked {
                ulong hi = value >> 32;
                ulong hiLo = hi * (uint)value;
                ulong high = (uint)value * (ulong)(uint)value;
                ulong low = (uint)high;
                high >>= 32;
                high += hiLo;
                ulong midHi = (high >> 32);
                midHi += (hi * hi);
                high = (uint)high;
                high += hiLo;
                low += (high << 32);
                high >>= 32;
                return new UInt128(high + midHi, low);
            }
        }

        /// <summary>Creates an instance of UInt128.</summary>
        /// <param name="high">The most significant 64 bits.</param>
        /// <param name="low">The least significant 64 bits.</param>
        public UInt128(ulong high, ulong low) {
            this.hi = high;
            this.lo = low;
        }

        /// <summary>Determines if the UInt128 value is less than or equal to UInt64.MaxValue.</summary>
        public bool IsULong { get { return this.hi == 0; } }

        /// <summary>Returns the lower 64 bits of the UInt128 value.</summary>
        public ulong Low { get { return this.lo; } }

        /// <summary>Returns the upper 64 bits of the UInt128 value.</summary>
        public ulong High { get { return this.hi; } }

        /// <summary>Returns a value indicating whether this instance is equal to a specified object.</summary>
        /// <param name="obj">An object to compare to this instance.</param>
        /// <returns>True if obj is an instance of UInt128 and equals the value of this instance; otherwise, false.</returns>
        public override bool Equals(object obj) {
            if (!(obj is UInt128)) {
                return false;
            }
            return this == (UInt128)obj;
        }

        /// <summary>Returns the hash code for this instance.</summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode() {
            return this.hi.GetHashCode() ^ this.lo.GetHashCode();
        }

        /// <summary>Returns the string representation of this instance.</summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString() {
            string loStr = this.lo.ToString("X");
            if (this.hi == 0) return loStr;
            loStr = new string('0', 16 - loStr.Length) + loStr;
            return this.hi.ToString("X") + loStr;
        }

        /// <summary>Defines an explicit conversion of a UInt128 value to an unsigned long value.</summary>
        /// <remarks>Only the lower 64 bits is returned, which may result in loss of data.</remarks>
        /// <param name="value"></param>
        public static explicit operator ulong(UInt128 value) {
            return value.lo;
        }

        /// <summary>Defines an implicit conversion of an unsigned long value to a UInt128 value.</summary>
        public static implicit operator UInt128(ulong value) {
            return new UInt128(0, value);
        }

        /// <summary>Returns a value that indicates whether the two UInt128 are equal.</summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>True if the values are equal, otherwise, false.</returns>
        public static bool operator ==(UInt128 left, UInt128 right) {
            return ((left.hi == right.hi) && (left.lo == right.lo));
        }

        /// <summary>Returns a value that indicates whether the two UInt128 are not equal.</summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>True if the values are not equal, otherwise, false.</returns>
        public static bool operator !=(UInt128 left, UInt128 right) {
            return ((left.hi != right.hi) || (left.lo != right.lo));
        }

        /// <summary>Returns a value that indicates whether a UInt128 value is greater than another UInt128 value.</summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>True if the left is greater than right, otherwise, false.</returns>
        public static bool operator >(UInt128 left, UInt128 right) {
            if (left.hi > right.hi) return true;
            if (left.hi < right.hi) return false;
            return left.lo > right.lo;
        }

        /// <summary>Returns a value that indicates whether a UInt128 value is less than another UInt128 value.</summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>True if the left is less than right, otherwise, false.</returns>
        public static bool operator <(UInt128 left, UInt128 right) {
            if (left.hi < right.hi) return true;
            if (left.hi > right.hi) return false;
            return left.lo < right.lo;
        }

        /// <summary>Returns a value that indicates whether a UInt128 value is greater than or equal to another UInt128 value.</summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>True if the left is greater than or equal to right, otherwise, false.</returns>
        public static bool operator >=(UInt128 left, UInt128 right) {
            if (left.hi > right.hi) return true;
            if (left.hi < right.hi) return false;
            return left.lo >= right.lo;
        }

        /// <summary>Returns a value that indicates whether a UInt128 value is less than or equal to another UInt128 value.</summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns>True if the left is less than or equal to right, otherwise, false.</returns>
        public static bool operator <=(UInt128 left, UInt128 right) {
            if (left.hi < right.hi) return true;
            if (left.hi > right.hi) return false;
            return left.lo <= right.lo;
        }

        /// <summary>Performs a bitwise And operation on two values.</summary>
        /// <param name="left">The first value.</param>
        /// <param name="right">The second value.</param>
        /// <returns>The result of the bitwise And operation.</returns>
        public static UInt128 operator &(UInt128 left, UInt128 right) {
            return new UInt128(left.hi & right.hi, left.lo & right.lo);
        }

        /// <summary>Shifts a UInt128 value a specified number of bits to the left.</summary>
        /// <param name="value">The value whose bits are to be shifted.</param>
        /// <param name="shift">The number of bits to shift value to the left.</param>
        /// <returns>A value that has been shifted to the left by the specified number of bits.</returns>
        public static UInt128 operator <<(UInt128 value, int shift) {
            return (shift >= 64) ? new UInt128(value.lo << (shift - 64), 0UL)
                : new UInt128((value.hi << shift) | (value.lo >> 64 - shift), value.lo << shift);
        }

        /// <summary>Shifts a UInt128 value a specified number of bits to the right.</summary>
        /// <param name="value">The value whose bits are to be shifted.</param>
        /// <param name="shift">The number of bits to shift value to the right.</param>
        /// <returns>A value that has been shifted to the right by the specified number of bits.</returns>
        public static UInt128 operator >>(UInt128 value, int shift) {
            return (shift >= 64) ? new UInt128(0UL, value.hi >> (shift - 64))
                : new UInt128(value.hi >> shift, (value.lo >> shift) | (value.hi << 64 - shift));
        }

        /// <summary>Multiplies two specified UInt128 values.</summary>
        /// <param name="left">The first value to multiply.</param>
        /// <param name="right">The second value to multiply.</param>
        /// <returns>The product of multiplying left and right.</returns>
        public static UInt128 operator *(UInt128 left, UInt128 right) {
            var result = UInt128.Multiply(left.lo, right.lo);
            var temp = UInt128.Multiply(left.lo, right.hi);
            result += new UInt128(temp.lo, 0UL);
            temp = UInt128.Multiply(left.hi, right.lo);
            return result + new UInt128(temp.lo, 0UL);
        }

        /// <summary>Adds two specified UInt128 values.</summary>
        /// <param name="left">The first value to add.</param>
        /// <param name="right">The second value to add.</param>
        /// <returns>The sum of left and right.</returns>
        public static UInt128 operator +(UInt128 left, UInt128 right) {
            ulong newLo = unchecked(left.lo + right.lo);
            ulong newHi = left.hi + right.hi;
            if (newLo < left.lo) newHi++;
            return new UInt128(newHi, newLo);
        }

        /// <summary>Subtracts a UInt128 value from another UInt128 value.</summary>
        /// <param name="left">The value to subtract from.</param>
        /// <param name="right">The value to subtract.</param>
        /// <returns>The value resulting from subtracting right from left.</returns>
        public static UInt128 operator -(UInt128 left, UInt128 right) {
            return new UInt128(left.hi - right.hi - ((left.lo < right.lo) ? 1UL : 0UL), unchecked(left.lo - right.lo));
        }

        /// <summary>Returns the remainder that results from dividing a UInt128 value by an unsigned long value.</summary>
        /// <param name="left">The value to be divided.</param>
        /// <param name="right">The value to divide by.</param>
        /// <returns>The remainder that results from the division.</returns>
        public static ulong operator %(UInt128 left, ulong right) {
            return left.Mod64(right);
        }

        //TODO replace with faster Mod128 implementation similar to Mod64
        /// <summary>Returns the remainder that results from dividing one UInt128 value by another.</summary>
        /// <param name="left">The value to be divided.</param>
        /// <param name="right">The value to divide by.</param>
        /// <returns>The remainder that results from the division.</returns>
        public static UInt128 operator %(UInt128 left, UInt128 right) {
            if (right == UInt128.Zero) return UInt128.Zero;
            if (right.IsULong) return left % right.lo;
            if (left.IsULong || left < right) return left;

            int bits = left.HighBitPosition() - right.HighBitPosition();
            UInt128 sub = right;
            sub <<= bits;
            for (; bits >= 0; bits--) {
                while (left >= sub) left -= sub;
                if (left < right) return left;
                sub = sub >> 1;
            }
            return 0;
        }

        private ulong Mod64(ulong denominator) {
            unchecked {
                if (denominator <= 1) return 0;
                if (denominator.IsPowerOf2()) return this.lo & (denominator - 1);
                ulong u1 = this.hi;
                ulong u0 = this.lo;
                //prevent incorrect results if divide would overflow
                if (u1 >= denominator) u1 -= ((u1 / denominator) * denominator);
                if (u1 == 0) return u0 % denominator;

                const ulong b = 1ul << 32;
                ulong un1, un0, vn1, vn0, q1, q0, un32, un21, un10, rhat, left, right;
                int s;
                s = denominator.LeadingZeroBits();
                denominator <<= s;
                un10 = u0 << s;
                un32 = (s == 0) ? u1 : (u1 << s) | (u0 >> (64 - s));
                un1 = un10 >> 32;
                un0 = (uint)un10;//un10 & 0xffffffff;
                vn1 = denominator >> 32;
                q1 = un32 / vn1;
                rhat = un32 - ((un32 / vn1) * vn1);// un32 % vn1;
                vn0 = (uint)denominator; //denominator & 0xffffffff;
                left = q1 * vn0;
                right = (rhat << 32) + un1;
                while ((left > right) || (q1 >= b)) {
                    q1--;
                    rhat += vn1;
                    if (rhat >= b) break;
                    left -= vn0;
                    right = (rhat << 32) | un1;
                }
                un21 = (un32 << 32) + (un1 - (q1 * denominator));
                q0 = un21 / vn1;
                rhat = un21 - ((un21 / vn1) * vn1);// un21 % vn1;
                left = q0 * vn0;
                right = (rhat << 32) | un0;
                while ((left > right) || (q0 >= b)) {
                    q0--;
                    rhat += vn1;
                    if (rhat >= b) break;
                    left -= vn0;
                    right = (rhat << 32) | un0;
                }
                return ((un21 << 32) + (un0 - (q0 * denominator))) >> s;
            }
        }

        private ulong DivMod64(ulong denominator, out ulong remainder) {
            unchecked {
                ulong u1 = this.hi;
                ulong u0 = this.lo;
                const ulong b = 1ul << 32;
                ulong un1, un0, vn1, vn0, q1, q0, un32, un21, un10, rhat, left, right;
                if (this.hi > denominator) return remainder = ulong.MaxValue;
                int s;
                s = denominator.LeadingZeroBits();
                denominator <<= s;
                vn1 = denominator >> 32;
                vn0 = denominator & 0xffffffff;
                if (s > 0) {
                    un32 = (u1 << s) | (u0 >> (64 - s));
                    un10 = u0 << s;
                } else {
                    un32 = u1;
                    un10 = u0;
                }
                un1 = un10 >> 32;
                un0 = un10 & 0xffffffff;
                q1 = un32 / vn1;
                rhat = un32 % vn1;
                left = q1 * vn0;
                right = (rhat << 32) + un1;
                while (true) {
                    if ((q1 >= b) || (left > right)) {
                        q1--;
                        rhat += vn1;
                        if (rhat < b) {
                            left -= vn0;
                            right = (rhat << 32) | un1;
                            continue;
                        }
                    }
                    break;
                }
                un21 = (un32 << 32) + (un1 - (q1 * denominator));
                q0 = un21 / vn1;
                rhat = un21 % vn1;
                left = q0 * vn0;
                right = (rhat << 32) | un0;
                while (true) {
                    if ((q0 >= b) || (left > right)) {
                        q0--;
                        rhat += vn1;
                        if (rhat < b) {
                            left -= vn0;
                            right = (rhat << 32) | un0;
                            continue;
                        }
                    }
                    break;
                }
                remainder = ((un21 << 32) + (un0 - (q0 * denominator))) >> s;
                q1 <<= 32;
                return q1 | q0;
            }
        }

        //private UInt128 DivMod128(UInt128 denominator, out UInt128 remainder) {
        //    if (denominator.hi == 0) {
        //        ulong rem;
        //        ulong result;
        //        if (this.hi < denominator.lo) {
        //            result = this.DivMod64(denominator.lo, out rem);
        //            remainder = new UInt128(0UL, rem);
        //            return new UInt128(0UL, result);
        //        }
        //        result = new UInt128(this.hi % denominator.lo, this.lo).DivMod64(denominator.lo, out rem);
        //        remainder = new UInt128(0UL, rem);
        //        return new UInt128(this.hi / denominator.lo, result);
        //    } else {
        //        int n = (int)denominator.hi.LeadingZeroBits();
        //        UInt128 v1 = denominator << n;
        //        UInt128 u1 = this >> 1;
        //        ulong rem, res;
        //        res = u1.DivMod64(v1.hi, out rem);
        //        var q1 = new UInt128(0UL, res);
        //        q1 >>= 63 - n;
        //        if ((q1.hi | q1.lo) != 0) {
        //            q1 = q1 - 1;
        //        }
        //        var result = q1 * denominator;
        //        remainder = this - q1;
        //        if (remainder > denominator) {
        //            result += 1;
        //            remainder -= denominator;
        //        }
        //        return result;
        //    }
        //}

        // If UInt128 is used standalone, without the rest of the SoftWx.Numerics library,
        // then the following methods from that library are needed, and included below.
    }
#if StandaloneUInt128
    internal static class SoftWxNumerics {
        public static int HighBitPosition(this ulong value) {
            uint high = (uint)(value >> 32);
            return (high != 0) ? 32 + HighBitPosition(high) : HighBitPosition((uint)value);
        }
        private static readonly byte[] DeBruijnLSBsSet = new byte[] {
            0, 9, 1, 10, 13, 21, 2, 29, 11, 14, 16, 18, 22, 25, 3, 30,
            8, 12, 20, 28, 15, 17, 24, 7, 19, 27, 23, 6, 26, 5, 4, 31
        };
        public static int HighBitPosition(this uint value) {
            if (value == 0) return -1;
            value |= value >> 1;
            value |= value >> 2;
            value |= value >> 4;
            value |= value >> 8;
            return DeBruijnLSBsSet[unchecked((value | value >> 16) * 0x07c4acddu) >> 27];
        }
        /// <summary>Returns the count of leading zero bits in the specified value.</summary>
        /// <remarks>Example: LeadingZeroBits(10) returns 4, i.e. 00001010 has 4 leading 0 bits.</remarks>
        /// <param name="value">The value whose leading zero bit count is desired.</param>
        /// <returns>The count of the value parameter's leading zero bits.</returns>
        public static int LeadingZeroBits(this ulong value) {
            return 63 - HighBitPosition(value);
        }
        /// <summary>Determines if the specified value is a power of 2.</summary>
        /// <param name="value">The value to be tested as a power of 2.</param>
        /// <returns>True if the value is a power of 2, otherwise false.</returns>
        public static bool IsPowerOf2(this ulong value) {
            return ((value & unchecked(value - 1UL)) == 0) && (value != 0);
        }
        /// <summary>Returns the most significant set bit position of the specified value,
        /// or -1 if no bits were set. The least significant bit position is 0.</summary>
        /// <remarks>Example: HighBitPosition(10) returns 3, i.e. high bit of 00001010 is position 3.</remarks>
        /// <param name="value">The value whose most significant bit position is desired.</param>
        /// <returns>The value parameter's most significant bit position.</returns>
        public static int HighBitPosition(this UInt128 value) {
            return (value.High != 0) ? 64 + HighBitPosition(value.High) : HighBitPosition(value.Low);
        }
    }
#endif
}

