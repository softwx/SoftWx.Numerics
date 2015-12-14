using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftWx.Numerics {
    /// <summary>
    /// Extension methods for bit fiddling operations on numeric types.
    /// </summary>
    /// <remarks>Many of the bit fiddling methods are the result of benchmarking
    /// various alternate algorithms presented on Sean Eron Anderson's page
    /// http://graphics.stanford.edu/~seander/bithacks.html
    /// sometimes with minor improvements for C#, and choosing compact
    /// alternatives that perform well in C# for each data type.</remarks>
    public static class BitMath {
        /// <summary>Lookup table for bit position of most significant bit.</summary>
        internal static readonly byte[] msbPos256 = new byte[256];
        // bit position lookup table where all bits set after most significant bit
        internal static byte[] DeBruijnLSBsSet = new byte[] {
            0, 9, 1, 10, 13, 21, 2, 29, 11, 14, 16, 18, 22, 25, 3, 30,
            8, 12, 20, 28, 15, 17, 24, 7, 19, 27, 23, 6, 26, 5, 4, 31
        };
        // bit position lookup table where all bits zero after most significant bit
        internal static byte[] DeBruijnMSBSet = new byte[] {
            0, 1, 28, 2, 29, 14, 24, 3, 30, 22, 20, 15, 25, 17, 4, 8,
            31, 27, 13, 23, 21, 19, 16, 7, 26, 12, 18, 6, 11, 5, 10, 9
        };

        static BitMath() {
            msbPos256[0] = 8; // special value for when there are no set bits
            msbPos256[1] = 0;
            for (int i = 2; i < 256; i++) msbPos256[i] = (byte)(1 + msbPos256[i / 2]);
        }

        /// <summary>Returns the least significant set bit of the specified value.</summary>
        /// <remarks>Example: LowBit(10) returns 2, i.e. low bit of 00001010 is 00000010.</remarks>
        /// <param name="value">The value whose least significant bit is desired.</param>
        /// <returns>The value parameter's the least significant bit.</returns>
        public static byte LowBit(this byte value) {
            return (byte)(value & -value);
        }

        /// <summary>Returns the least significant set bit of the specified value.</summary>
        /// <remarks>Example: LowBit(10) returns 2, i.e. low bit of 00001010 is 00000010.</remarks>
        /// <param name="value">The value whose least significant bit is desired.</param>
        /// <returns>The value parameter's the least significant bit.</returns>
        public static sbyte LowBit(this sbyte value) {
            return (sbyte)(value & -value);
        }

        /// <summary>Returns the least significant set bit of the specified value.</summary>
        /// <remarks>Example: LowBit(10) returns 2, i.e. low bit of 00001010 is 00000010.</remarks>
        /// <param name="value">The value whose least significant bit is desired.</param>
        /// <returns>The value parameter's the least significant bit.</returns>
        public static ushort LowBit(this ushort value) {
            return (ushort)(value & -value);
        }

        /// <summary>Returns the least significant set bit of the specified value.</summary>
        /// <remarks>Example: LowBit(10) returns 2, i.e. low bit of 00001010 is 00000010.</remarks>
        /// <param name="value">The value whose least significant bit is desired.</param>
        /// <returns>The value parameter's the least significant bit.</returns>
        public static short LowBit(this short value) {
            return (short)(value & -value);
        }

        /// <summary>Returns the least significant set bit of the specified value.</summary>
        /// <remarks>Example: LowBit(10) returns 2, i.e. low bit of 00001010 is 00000010.</remarks>
        /// <param name="value">The value whose least significant bit is desired.</param>
        /// <returns>The value parameter's the least significant bit.</returns>
        public static uint LowBit(this uint value) {
            return value & unchecked(1u + ~value);
        }

        /// <summary>Returns the least significant set bit of the specified value.</summary>
        /// <remarks>Example: LowBit(10) returns 2, i.e. low bit of 00001010 is 00000010.</remarks>
        /// <param name="value">The value whose least significant bit is desired.</param>
        /// <returns>The value parameter's the least significant bit.</returns>
        public static int LowBit(this int value) {
            return (value & unchecked(-value));
        }

        /// <summary>Returns the least significant set bit of the specified value.</summary>
        /// <remarks>Example: LowBit(10) returns 2, i.e. low bit of 00001010 is 00000010.</remarks>
        /// <param name="value">The value whose least significant bit is desired.</param>
        /// <returns>The value parameter's the least significant bit.</returns>
        public static ulong LowBit(this ulong value) {
            return value & unchecked(1ul + ~value);
        }

        /// <summary>Returns the least significant set bit of the specified value.</summary>
        /// <remarks>Example: LowBit(10) returns 2, i.e. low bit of 00001010 is 00000010.</remarks>
        /// <param name="value">The value whose least significant bit is desired.</param>
        /// <returns>The value parameter's the least significant bit.</returns>
        public static long LowBit(this long value) {
            return value & unchecked(-value);
        }

        /// <summary>Returns the most significant set bit of the specified value.</summary>
        /// <remarks>Example: HighBit(10) returns 8, i.e. high bit of 00001010 is 00001000.</remarks>
        /// <param name="value">The value whose most significant bit is desired.</param>
        /// <returns>The value parameter's the most significant bit.</returns>
        public static byte HighBit(this byte value) {
            return (byte)(1 << msbPos256[value]);
        }

        /// <summary>Returns the most significant set bit of the specified value.</summary>
        /// <remarks>Example: HighBit(10) returns 8, i.e. high bit of 00001010 is 00001000.</remarks>
        /// <param name="value">The value whose most significant bit is desired.</param>
        /// <returns>The value parameter's the most significant bit.</returns>
        public static sbyte HighBit(this sbyte value) {
            return (sbyte)(1 << msbPos256[(byte)value]); // the cast to byte is not redundant (avoids sign bit extension)
        }

        /// <summary>Returns the most significant set bit of the specified value.</summary>
        /// <remarks>Example: HighBit(10) returns 8, i.e. high bit of 00001010 is 00001000.</remarks>
        /// <param name="value">The value whose most significant bit is desired.</param>
        /// <returns>The value parameter's the most significant bit.</returns>
        public static ushort HighBit(this ushort value) {
            uint val = value;
            if (val == 0) return 0;
            val |= val >> 1;
            val |= val >> 2;
            val |= val >> 4;
            val |= val >> 8;
            return (ushort)unchecked(((value >> 1) + 1));
        }

        /// <summary>Returns the most significant set bit of the specified value.</summary>
        /// <remarks>Example: HighBit(10) returns 8, i.e. high bit of 00001010 is 00001000.</remarks>
        /// <param name="value">The value whose most significant bit is desired.</param>
        /// <returns>The value parameter's the most significant bit.</returns>
        public static short HighBit(this short value) {
            return (short)HighBit((ushort)value);
        }

        /// <summary>Returns the most significant set bit of the specified value.</summary>
        /// <remarks>Example: HighBit(10) returns 8, i.e. high bit of 00001010 is 00001000.</remarks>
        /// <param name="value">The value whose most significant bit is desired.</param>
        /// <returns>The value parameter's the most significant bit.</returns>
        public static uint HighBit(this uint value) {
            if (value == 0) return 0;
            value |= value >> 1;
            value |= value >> 2;
            value |= value >> 4;
            value |= value >> 8;
            value |= value >> 16;
            return unchecked((value >> 1) + 1);
        }

        /// <summary>Returns the most significant set bit of the specified value.</summary>
        /// <remarks>Example: HighBit(10) returns 8, i.e. high bit of 00001010 is 00001000.</remarks>
        /// <param name="value">The value whose most significant bit is desired.</param>
        /// <returns>The value parameter's the most significant bit.</returns>
        public static int HighBit(this int value) {
            return (int)HighBit((uint)value);
        }

        /// <summary>Returns the most significant set bit of the specified value.</summary>
        /// <remarks>Example: HighBit(10) returns 8, i.e. high bit of 00001010 is 00001000.</remarks>
        /// <param name="value">The value whose most significant bit is desired.</param>
        /// <returns>The value parameter's the most significant bit.</returns>
        public static ulong HighBit(this ulong value) {
            if (value == 0) return 0;
            uint high = (uint)(value >> 32);
            return (high == 0) ? HighBit((uint)value) : HighBit(high) << 32;
        }

        /// <summary>Returns the most significant set bit of the specified value.</summary>
        /// <remarks>Example: HighBit(10) returns 8, i.e. high bit of 00001010 is 00001000.</remarks>
        /// <param name="value">The value whose most significant bit is desired.</param>
        /// <returns>The value parameter's the most significant bit.</returns>
        public static long HighBit(this long value) {
            return (long)HighBit((ulong)value);
        }

        /// <summary>Returns the least significant set bit position of the specified value,
        /// or 8 (one more than the bit position of the most significant bit) if no bits
        /// were set. The least significant bit position is 0.</summary>
        /// <remarks>Example: LowBitPosition(10) returns 1, i.e. low bit of 00001010 is position 1.</remarks>
        /// <param name="value">The value whose least significant bit position is desired.</param>
        /// <returns>The value parameter's least significant bit position.</returns>
        public static byte LowBitPosition(this byte value) {
            return msbPos256[value & -value];
        }

        /// <summary>Returns the least significant set bit position of the specified value,
        /// or 8 (one more than the bit position of the most significant bit) if no bits
        /// were set. The least significant bit position is 0.</summary>
        /// <remarks>Example: LowBitPosition(10) returns 1, i.e. low bit of 00001010 is position 1.</remarks>
        /// <param name="value">The value whose least significant bit position is desired.</param>
        /// <returns>The value parameter's least significant bit position.</returns>
        public static sbyte LowBitPosition(this sbyte value) {
            return (sbyte)msbPos256[value & -value];
        }

        /// <summary>Returns the least significant set bit position of the specified value,
        /// or 16 (one more than the bit position of the most significant bit) if no bits
        /// were set. The least significant bit position is 0.</summary>
        /// <remarks>Example: LowBitPosition(10) returns 1, i.e. low bit of 00001010 is position 1.</remarks>
        /// <param name="value">The value whose least significant bit position is desired.</param>
        /// <returns>The value parameter's least significant bit position.</returns>
        public static ushort LowBitPosition(this ushort value) {
            byte lsb = (byte)value;
            return (lsb == 0) ? (ushort)(8 + LowBitPosition((byte)(value >> 8))) : msbPos256[lsb & -lsb];
        }

        /// <summary>Returns the least significant set bit position of the specified value,
        /// or 16 (one more than the bit position of the most significant bit) if no bits
        /// were set. The least significant bit position is 0.</summary>
        /// <remarks>Example: LowBitPosition(10) returns 1, i.e. low bit of 00001010 is position 1.</remarks>
        /// <param name="value">The value whose least significant bit position is desired.</param>
        /// <returns>The value parameter's least significant bit position.</returns>
        public static short LowBitPosition(this short value) {
            return (short)LowBitPosition((ushort)value);
        }

        /// <summary>Returns the least significant set bit position of the specified value,
        /// or 32 (one more than the bit position of the most significant bit) if no bits
        /// were set. The least significant bit position is 0.</summary>
        /// <remarks>Example: LowBitPosition(10) returns 1, i.e. low bit of 00001010 is position 1.</remarks>
        /// <param name="value">The value whose least significant bit position is desired.</param>
        /// <returns>The value parameter's least significant bit position.</returns>
        public static uint LowBitPosition(this uint value) {
            return (value != 0) ? DeBruijnMSBSet[unchecked((value & (1u + ~value)) * 0x077cb531u) >> 27] : 32u;
        }

        /// <summary>Returns the least significant set bit position of the specified value,
        /// or 32 (one more than the bit position of the most significant bit) if no bits
        /// were set. The least significant bit position is 0.</summary>
        /// <remarks>Example: LowBitPosition(10) returns 1, i.e. low bit of 00001010 is position 1.</remarks>
        /// <param name="value">The value whose least significant bit position is desired.</param>
        /// <returns>The value parameter's least significant bit position.</returns>
        public static int LowBitPosition(this int value) {
            return (int)LowBitPosition((uint)value);
        }

        /// <summary>Returns the least significant set bit position of the specified value,
        /// or 64 (one more than the bit position of the most significant bit) if no bits
        /// were set. The least significant bit position is 0.</summary>
        /// <remarks>Example: LowBitPosition(10) returns 1, i.e. low bit of 00001010 is position 1.</remarks>
        /// <param name="value">The value whose least significant bit position is desired.</param>
        /// <returns>The value parameter's least significant bit position.</returns>
        public static ulong LowBitPosition(this ulong value) {
            uint uiVal = (uint)value;
            if (uiVal != 0) {
                return (ulong)DeBruijnMSBSet[unchecked((uiVal & (1u + ~uiVal)) * 0x077cb531u) >> 27];
            }
            return unchecked(32UL + (ulong)LowBitPosition((uint)(value >> 32)));
        }

        /// <summary>Returns the least significant set bit position of the specified value,
        /// or 64 (one more than the bit position of the most significant bit) if no bits
        /// were set. The least significant bit position is 0.</summary>
        /// <remarks>Example: LowBitPosition(10) returns 1, i.e. low bit of 00001010 is position 1.</remarks>
        /// <param name="value">The value whose least significant bit position is desired.</param>
        /// <returns>The value parameter's least significant bit position.</returns>
        public static long LowBitPosition(this long value) {
            return (long)LowBitPosition((ulong)value);
        }

        /// <summary>Returns the most significant set bit position of the specified value,
        /// or 8 (one more than the bit position of the most significant bit) if no bits
        /// were set. The least significant bit position is 0.</summary>
        /// <remarks>Example: HighBitPosition(10) returns 3, i.e. high bit of 00001010 is position 3.</remarks>
        /// <param name="value">The value whose most significant bit position is desired.</param>
        /// <returns>The value parameter's most significant bit position.</returns>
        public static byte HighBitPosition(this byte value) {
            return msbPos256[value];
        }

        /// <summary>Returns the most significant set bit position of the specified value,
        /// or 8 (one more than the bit position of the most significant bit) if no bits
        /// were set. The least significant bit position is 0.</summary>
        /// <remarks>Example: HighBitPosition(10) returns 3, i.e. high bit of 00001010 is position 3.</remarks>
        /// <param name="value">The value whose most significant bit position is desired.</param>
        /// <returns>The value parameter's most significant bit position.</returns>
        public static sbyte HighBitPosition(this sbyte value) {
            return (sbyte)msbPos256[(byte)value]; // the cast to byte is not redundant (avoids sign bit extension)
        }

        /// <summary>Returns the most significant set bit position of the specified value,
        /// or 16 (one more than the bit position of the most significant bit) if no bits
        /// were set. The least significant bit position is 0.</summary>
        /// <remarks>Example: HighBitPosition(10) returns 3, i.e. high bit of 00001010 is position 3.</remarks>
        /// <param name="value">The value whose most significant bit position is desired.</param>
        /// <returns>The value parameter's most significant bit position.</returns>
        public static ushort HighBitPosition(this ushort value) {
            int msb = (byte)(value >> 8);
            return (msb == 0) ? msbPos256[(byte)value] : (ushort)(8 + msbPos256[msb]);
            //if (value == 0) return 16;
            //uint val = (uint)value;
            //val |= val >> 1;
            //val |= val >> 2;
            //val |= val >> 4;
            //return DeBruijnLSBsSet[unchecked((val | val >> 8) * 0x07c4acddu) >> 27];
        }

        /// <summary>Returns the most significant set bit position of the specified value,
        /// or 16 (one more than the bit position of the most significant bit) if no bits
        /// were set. The least significant bit position is 0.</summary>
        /// <remarks>Example: HighBitPosition(10) returns 3, i.e. high bit of 00001010 is position 3.</remarks>
        /// <param name="value">The value whose most significant bit position is desired.</param>
        /// <returns>The value parameter's most significant bit position.</returns>
        public static short HighBitPosition(this short value) {
            return (short)HighBitPosition((ushort)value);
        }

        /// <summary>Returns the most significant set bit position of the specified value,
        /// or 32 (one more than the bit position of the most significant bit) if no bits
        /// were set. The least significant bit position is 0.</summary>
        /// <remarks>Example: HighBitPosition(10) returns 3, i.e. high bit of 00001010 is position 3.</remarks>
        /// <param name="value">The value whose most significant bit position is desired.</param>
        /// <returns>The value parameter's most significant bit position.</returns>
        public static uint HighBitPosition(this uint value) {
            if (value == 0) return 32;
            value |= value >> 1;
            value |= value >> 2;
            value |= value >> 4;
            value |= value >> 8;
            return DeBruijnLSBsSet[unchecked((value | value >> 16) * 0x07c4acddu) >> 27];
        }

        /// <summary>Returns the most significant set bit position of the specified value,
        /// or 32 (one more than the bit position of the most significant bit) if no bits
        /// were set. The least significant bit position is 0.</summary>
        /// <remarks>Example: HighBitPosition(10) returns 3, i.e. high bit of 00001010 is position 3.</remarks>
        /// <param name="value">The value whose most significant bit position is desired.</param>
        /// <returns>The value parameter's most significant bit position.</returns>
        public static int HighBitPosition(this int value) {
            return (int)HighBitPosition((uint)value);
        }

        /// <summary>Returns the most significant set bit position of the specified value,
        /// or 64 (one more than the bit position of the most significant bit) if no bits
        /// were set. The least significant bit position is 0.</summary>
        /// <remarks>Example: HighBitPosition(10) returns 3, i.e. high bit of 00001010 is position 3.</remarks>
        /// <param name="value">The value whose most significant bit position is desired.</param>
        /// <returns>The value parameter's most significant bit position.</returns>
        public static ulong HighBitPosition(this ulong value) {
            uint uiVal = (uint)(value >> 32);
            if (uiVal != 0) {
                return unchecked(32ul + (ulong)HighBitPosition(uiVal));
            }
            return (ulong)HighBitPosition((uint)value);
        }

        /// <summary>Returns the most significant set bit position of the specified value,
        /// or 64 (one more than the bit position of the most significant bit) if no bits
        /// were set. The least significant bit position is 0.</summary>
        /// <remarks>Example: HighBitPosition(10) returns 3, i.e. high bit of 00001010 is position 3.</remarks>
        /// <param name="value">The value whose most significant bit position is desired.</param>
        /// <returns>The value parameter's most significant bit position.</returns>
        public static long HighBitPosition(this long value) {
            return (long)HighBitPosition((ulong)value);
        }

        /// <summary>Returns the count of leading zero bits in the specified value.</summary>
        /// <remarks>Example: LeadingZeroBits(10) returns 4, i.e. 00001010 has 4 leading 0 bits.</remarks>
        /// <param name="value">The value whose leading zero bit count is desired.</param>
        /// <returns>The count of the value parameter's leading zero bits.</returns>
        public static byte LeadingZeroBits(this byte value) {
            if (value == 0) return 8;
            return (byte)(7 - HighBitPosition(value));
        }

        /// <summary>Returns the count of leading zero bits in the specified value.</summary>
        /// <remarks>Example: LeadingZeroBits(10) returns 4, i.e. 00001010 has 4 leading 0 bits.</remarks>
        /// <param name="value">The value whose leading zero bit count is desired.</param>
        /// <returns>The count of the value parameter's leading zero bits.</returns>
        public static sbyte LeadingZeroBits(this sbyte value) {
            if (value == 0) return 8;
            return (sbyte)(7 - HighBitPosition(value));
        }

        /// <summary>Returns the count of leading zero bits in the specified value.</summary>
        /// <remarks>Example: LeadingZeroBits(10) returns 4, i.e. 00001010 has 4 leading 0 bits.</remarks>
        /// <param name="value">The value whose leading zero bit count is desired.</param>
        /// <returns>The count of the value parameter's leading zero bits.</returns>
        public static ushort LeadingZeroBits(this ushort value) {
            if (value == 0) return 16;
            return (ushort)(15 - HighBitPosition(value));
        }

        /// <summary>Returns the count of leading zero bits in the specified value.</summary>
        /// <remarks>Example: LeadingZeroBits(10) returns 4, i.e. 00001010 has 4 leading 0 bits.</remarks>
        /// <param name="value">The value whose leading zero bit count is desired.</param>
        /// <returns>The count of the value parameter's leading zero bits.</returns>
        public static short LeadingZeroBits(this short value) {
            if (value == 0) return 16;
            return (short)(15 - HighBitPosition(value));
        }

        /// <summary>Returns the count of leading zero bits in the specified value.</summary>
        /// <remarks>Example: LeadingZeroBits(10) returns 4, i.e. 00001010 has 4 leading 0 bits.</remarks>
        /// <param name="value">The value whose leading zero bit count is desired.</param>
        /// <returns>The count of the value parameter's leading zero bits.</returns>
        public static uint LeadingZeroBits(this uint value) {
            if (value == 0) return 32;
            return 31u - HighBitPosition(value);
        }

        /// <summary>Returns the count of leading zero bits in the specified value.</summary>
        /// <remarks>Example: LeadingZeroBits(10) returns 4, i.e. 00001010 has 4 leading 0 bits.</remarks>
        /// <param name="value">The value whose leading zero bit count is desired.</param>
        /// <returns>The count of the value parameter's leading zero bits.</returns>
        public static int LeadingZeroBits(this int value) {
            if (value == 0) return 32;
            return 31 - HighBitPosition(value);
        }

        /// <summary>Returns the count of leading zero bits in the specified value.</summary>
        /// <remarks>Example: LeadingZeroBits(10) returns 4, i.e. 00001010 has 4 leading 0 bits.</remarks>
        /// <param name="value">The value whose leading zero bit count is desired.</param>
        /// <returns>The count of the value parameter's leading zero bits.</returns>
        public static ulong LeadingZeroBits(this ulong value) {
            if (value == 0) return 64;
            return 63UL - HighBitPosition(value);
        }

        /// <summary>Returns the count of leading zero bits in the specified value.</summary>
        /// <remarks>Example: LeadingZeroBits(10) returns 4, i.e. 00001010 has 4 leading 0 bits.</remarks>
        /// <param name="value">The value whose leading zero bit count is desired.</param>
        /// <returns>The count of the value parameter's leading zero bits.</returns>
        public static long LeadingZeroBits(this long value) {
            if (value == 0) return 64;
            return 63L - HighBitPosition(value);
        }

        /// <summary>Returns the count of trailing zero bits in the specified value.</summary>
        /// <remarks>Example: TrailingZeroBits(10) returns 1, i.e. 00001010 has 1 trailing 0 bit.</remarks>
        /// <param name="value">The value whose trailing zero bit count is desired.</param>
        /// <returns>The count of the value parameter's trailing zero bits.</returns>
        public static byte TrailingZeroBits(this byte value) {
            return LowBitPosition(value);
        }

        /// <summary>Returns the count of trailing zero bits in the specified value.</summary>
        /// <remarks>Example: TrailingZeroBits(10) returns 1, i.e. 00001010 has 1 trailing 0 bit.</remarks>
        /// <param name="value">The value whose trailing zero bit count is desired.</param>
        /// <returns>The count of the value parameter's trailing zero bits.</returns>
        public static sbyte TrailingZeroBits(this sbyte value) {
            return LowBitPosition(value);
        }

        /// <summary>Returns the count of trailing zero bits in the specified value.</summary>
        /// <remarks>Example: TrailingZeroBits(10) returns 1, i.e. 00001010 has 1 trailing 0 bit.</remarks>
        /// <param name="value">The value whose trailing zero bit count is desired.</param>
        /// <returns>The count of the value parameter's trailing zero bits.</returns>
        public static ushort TrailingZeroBits(this ushort value) {
            return LowBitPosition(value);
        }

        /// <summary>Returns the count of trailing zero bits in the specified value.</summary>
        /// <remarks>Example: TrailingZeroBits(10) returns 1, i.e. 00001010 has 1 trailing 0 bit.</remarks>
        /// <param name="value">The value whose trailing zero bit count is desired.</param>
        /// <returns>The count of the value parameter's trailing zero bits.</returns>
        public static short TrailingZeroBits(this short value) {
            return LowBitPosition(value);
        }

        /// <summary>Returns the count of trailing zero bits in the specified value.</summary>
        /// <remarks>Example: TrailingZeroBits(10) returns 1, i.e. 00001010 has 1 trailing 0 bit.</remarks>
        /// <param name="value">The value whose trailing zero bit count is desired.</param>
        /// <returns>The count of the value parameter's trailing zero bits.</returns>
        public static uint TrailingZeroBits(this uint value) {
            return LowBitPosition(value);
        }

        /// <summary>Returns the count of trailing zero bits in the specified value.</summary>
        /// <remarks>Example: TrailingZeroBits(10) returns 1, i.e. 00001010 has 1 trailing 0 bit.</remarks>
        /// <param name="value">The value whose trailing zero bit count is desired.</param>
        /// <returns>The count of the value parameter's trailing zero bits.</returns>
        public static int TrailingZeroBits(this int value) {
            return LowBitPosition(value);
        }

        /// <summary>Returns the count of trailing zero bits in the specified value.</summary>
        /// <remarks>Example: TrailingZeroBits(10) returns 1, i.e. 00001010 has 1 trailing 0 bit.</remarks>
        /// <param name="value">The value whose trailing zero bit count is desired.</param>
        /// <returns>The count of the value parameter's trailing zero bits.</returns>
        public static ulong TrailingZeroBits(this ulong value) {
            return LowBitPosition(value);
        }

        /// <summary>Returns the count of trailing zero bits in the specified value.</summary>
        /// <remarks>Example: TrailingZeroBits(10) returns 1, i.e. 00001010 has 1 trailing 0 bit.</remarks>
        /// <param name="value">The value whose trailing zero bit count is desired.</param>
        /// <returns>The count of the value parameter's trailing zero bits.</returns>
        public static long TrailingZeroBits(this long value) {
            return LowBitPosition(value);
        }

        /// <summary>Returns the count of set bits in the specified value.</summary>
        /// <param name="value">The value whose bit count is desired.</param>
        /// <returns>The count of set bits in the specified value.</returns>
        public static byte BitCount(this byte value) {
            uint v = value;
            v = v - ((v >> 1) & 0x55u);
            v = (v & 0x33u) + ((v >> 2) & 0x33u);
            return (byte)((v + (v >> 4) & 0x0Fu));
        }

        /// <summary>Returns the count of set bits in the specified value.</summary>
        /// <param name="value">The value whose bit count is desired.</param>
        /// <returns>The count of set bits in the specified value.</returns>
        public static sbyte BitCount(this sbyte value) {
            return (sbyte)BitCount((byte)value);
        }

        /// <summary>Returns the count of set bits in the specified value.</summary>
        /// <param name="value">The value whose bit count is desired.</param>
        /// <returns>The count of set bits in the specified value.</returns>
        public static ushort BitCount(this ushort value) {
            return (ushort)BitCount((uint)value);
        }

        /// <summary>Returns the count of set bits in the specified value.</summary>
        /// <param name="value">The value whose bit count is desired.</param>
        /// <returns>The count of set bits in the specified value.</returns>
        public static short BitCount(this short value) {
            return (short)BitCount((ushort)value);
        }

        /// <summary>Returns the count of set bits in the specified value.</summary>
        /// <param name="value">The value whose bit count is desired.</param>
        /// <returns>The count of set bits in the specified value.</returns>
        public static uint BitCount(this uint value) {
            value = value - ((value >> 1) & 0x55555555u);
            value = (value & 0x33333333u) + ((value >> 2) & 0x33333333u);
            return ((value + (value >> 4) & 0xF0F0F0Fu) * 0x1010101u) >> (32-8);
        }

        /// <summary>Returns the count of set bits in the specified value.</summary>
        /// <param name="value">The value whose bit count is desired.</param>
        /// <returns>The count of set bits in the specified value.</returns>
        public static int BitCount(this int value) {
            return (int)BitCount((uint)value);
        }

        /// <summary>Returns the count of set bits in the specified value.</summary>
        /// <param name="value">The value whose bit count is desired.</param>
        /// <returns>The count of set bits in the specified value.</returns>
        public static ulong BitCount(this ulong value) {
            value = value - ((value >> 1) & 0x5555555555555555UL);
            value = (value & 0x3333333333333333UL) + ((value >> 2) & 0x3333333333333333UL);
            return ((value + (value >> 4) & 0x0F0F0F0F0F0F0F0FUL) * 0x0101010101010101UL) >> (63-8);
        }

        /// <summary>Returns the count of set bits in the specified value.</summary>
        /// <param name="value">The value whose bit count is desired.</param>
        /// <returns>The count of set bits in the specified value.</returns>
        public static long BitCount(this long value) {
            return (long)BitCount((ulong)value);
        }

        /// <summary>Returns the specified value with all bits reversed 
        /// (i.e. 01001101 is returned as 10110010).
        /// </summary>
        /// <param name="value">The value to be reversed.</param>
        /// <returns>The reversed bits of the specified value.</returns>
        public static byte ReverseBits(this byte value) {
            uint v = (uint)value;
            return (byte)(((v * 0x0802u & 0x22110u) | (v * 0x8020u & 0x88440u)) * 0x10101u >> 16);
        }

        /// <summary>Returns the specified value with all bits reversed 
        /// (i.e. 01001101 is returned as 10110010).
        /// </summary>
        /// <param name="value">The value to be reversed.</param>
        /// <returns>The reversed bits of the specified value.</returns>
        public static sbyte ReverseBits(this sbyte value) {
            return (sbyte)ReverseBits((byte)value);
        }

        /// <summary>Returns the specified value with all bits reversed 
        /// (i.e. 01001101 is returned as 10110010).
        /// </summary>
        /// <param name="value">The value to be reversed.</param>
        /// <returns>The reversed bits of the specified value.</returns>
        public static ushort ReverseBits(this ushort value) {
            uint val = value;
            val = ((val >> 1) & 0x5555u) | ((val & 0x5555u) << 1);
            val = ((val >> 2) & 0x3333u) | ((val & 0x3333u) << 2);
            val = ((val >> 4) & 0x0F0Fu) | ((val & 0x0F0Fu) << 4);
            return (ushort)(((val >> 8) & 0x00FF) | ((val & 0x00FF) << 8));
        }

        /// <summary>Returns the specified value with all bits reversed 
        /// (i.e. 01001101 is returned as 10110010).
        /// </summary>
        /// <param name="value">The value to be reversed.</param>
        /// <returns>The reversed bits of the specified value.</returns>
        public static short ReverseBits(this short value) {
            return (short)ReverseBits((ushort)value);
        }

        /// <summary>Returns the specified value with all bits reversed 
        /// (i.e. 01001101 is returned as 10110010).
        /// </summary>
        /// <param name="value">The value to be reversed.</param>
        /// <returns>The reversed bits of the specified value.</returns>
        public static uint ReverseBits(this uint value) { 
            value = ((value >> 1) & 0x55555555u) | ((value & 0x55555555u) << 1);
            value = ((value >> 2) & 0x33333333u) | ((value & 0x33333333u) << 2);
            value = ((value >> 4) & 0x0F0F0F0Fu) | ((value & 0x0F0F0F0Fu) << 4);
            value = ((value >> 8) & 0x00FF00FFu) | ((value & 0x00FF00FFu) << 8);
            return (value >> 16) | (value << 16);
        }

        /// <summary>Returns the specified value with all bits reversed 
        /// (i.e. 01001101 is returned as 10110010).
        /// </summary>
        /// <param name="value">The value to be reversed.</param>
        /// <returns>The reversed bits of the specified value.</returns>
        public static int ReverseBits(this int value) {
            return (int)ReverseBits((uint)value);
        }

        /// <summary>Returns the specified value with all bits reversed 
        /// (i.e. 01001101 is returned as 10110010).
        /// </summary>
        /// <param name="value">The value to be reversed.</param>
        /// <returns>The reversed bits of the specified value.</returns>
        public static ulong ReverseBits(this ulong value) {
            value = ((value >> 1) & 0x5555555555555555UL) | ((value & 0x5555555555555555UL) << 1);
            value = ((value >> 2) & 0x3333333333333333UL) | ((value & 0x3333333333333333UL) << 2);
            value = ((value >> 4) & 0x0F0F0F0F0F0F0F0FUL) | ((value & 0x0F0F0F0F0F0F0F0FUL) << 4);
            value = ((value >> 8) & 0x00FF00FF00FF00FFUL) | ((value & 0x00FF00FF00FF00FFUL) << 8);
            value = ((value >> 16) & 0x0000FFFF0000FFFFUL) | ((value & 0x0000FFFF0000FFFFUL) << 16);
            return (value >> 32) | (value << 32);
        }

        /// <summary>Returns the specified value with all bits reversed 
        /// (i.e. 01001101 is returned as 10110010).
        /// </summary>
        /// <param name="value">The value to be reversed.</param>
        /// <returns>The reversed bits of the specified value.</returns>
        public static long ReverseBits(this long value) {
            return (long)ReverseBits((ulong)value);
        }
    }
}