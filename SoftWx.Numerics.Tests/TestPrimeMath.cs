
// Released under the MIT License the text of which appears at the end of this file.
// <authors> Steve Hatchett
using NUnit.Framework;

namespace SoftWx.Numerics.Tests {
    /// <summary></summary>
    [TestFixture]
    public class TestPrimeMath {
        [Test]
        public void Gcd0And0ShouldReturn0() {
            Assert.AreEqual(0, PrimeMath.Gcd((uint)0, (uint)0), "uint");
            Assert.AreEqual(0, PrimeMath.Gcd((int)0, (int)0), "int");
            Assert.AreEqual(0, PrimeMath.Gcd((ulong)0, (ulong)0), "ulong");
            Assert.AreEqual(0, PrimeMath.Gcd((long)0, (long)0), "long");
            Assert.AreEqual(UInt128.Zero, PrimeMath.Gcd((UInt128)0, (UInt128)0), "UInt128");
        }

        [Test]
        public void GcdNon0And0ShouldReturnNon0() {
            Assert.AreEqual(9, PrimeMath.Gcd((uint)0, (uint)9), "uint");
            Assert.AreEqual(9, PrimeMath.Gcd((int)0, (int)9), "int");
            Assert.AreEqual(9, PrimeMath.Gcd((ulong)0, (ulong)9), "ulong");
            Assert.AreEqual(9, PrimeMath.Gcd((long)0, (long)9), "long");
            Assert.AreEqual(9, PrimeMath.Gcd((uint)9, (uint)0), "uint");
            Assert.AreEqual(9, PrimeMath.Gcd((int)9, (int)0), "int");
            Assert.AreEqual(9, PrimeMath.Gcd((ulong)9, (ulong)0), "ulong");
            Assert.AreEqual(9, PrimeMath.Gcd((long)9, (long)0), "long");
            Assert.AreEqual((UInt128)9, PrimeMath.Gcd((UInt128)9, (UInt128)0), "UInt128");
        }

        [Test]
        public void GcdTwoPrimesShouldReturn1() {
            Assert.AreEqual(1, PrimeMath.Gcd((uint)23, (uint)101), "uint");
            Assert.AreEqual(1, PrimeMath.Gcd((int)23, (int)101), "int");
            Assert.AreEqual(1, PrimeMath.Gcd((ulong)23, (ulong)101), "ulong");
            Assert.AreEqual(1, PrimeMath.Gcd((long)23, (long)101), "long");
            Assert.AreEqual(UInt128.One, PrimeMath.Gcd((UInt128)23, (UInt128)101), "UInt128");
        }

        [Test]
        public void GcdNegativesShouldReturnSameAsPositive() {
            Assert.AreEqual(20, PrimeMath.Gcd((int)100, (int)80), "int pos");
            Assert.AreEqual(20, PrimeMath.Gcd((long)100, (long)80), "long pos");
            Assert.AreEqual(20, PrimeMath.Gcd((int)-100, (int)-80), "int neg");
            Assert.AreEqual(20, PrimeMath.Gcd((long)-100, (long)-80), "long neg");
            Assert.AreEqual(20, PrimeMath.Gcd((int)100, (int)-80), "int pos neg");
            Assert.AreEqual(20, PrimeMath.Gcd((long)100, (long)-80), "long pos neg");
            Assert.AreEqual(20, PrimeMath.Gcd((int)-100, (int)80), "int neg pos");
            Assert.AreEqual(20, PrimeMath.Gcd((long)-100, (long)80), "long neg pos");
        }

        [Test]
        public void IsCoPrime0And0ShouldReturnFalse() {
            Assert.AreEqual(false, PrimeMath.IsCoprime((uint)0, (uint)0), "uint");
            Assert.AreEqual(false, PrimeMath.IsCoprime((int)0, (int)0), "int");
            Assert.AreEqual(false, PrimeMath.IsCoprime((ulong)0, (ulong)0), "ulong");
            Assert.AreEqual(false, PrimeMath.IsCoprime((long)0, (long)0), "long");
            Assert.AreEqual(false, PrimeMath.IsCoprime((UInt128)0, (UInt128)0), "UInt128");
        }

        [Test]
        public void IsCoPrime0And1ShouldReturnTrue() {
            Assert.AreEqual(true, PrimeMath.IsCoprime((uint)0, (uint)1), "uint");
            Assert.AreEqual(true, PrimeMath.IsCoprime((int)0, (int)1), "int");
            Assert.AreEqual(true, PrimeMath.IsCoprime((ulong)0, (ulong)1), "ulong");
            Assert.AreEqual(true, PrimeMath.IsCoprime((long)0, (long)1), "long");
            Assert.AreEqual(true, PrimeMath.IsCoprime((UInt128)0, (UInt128)1), "UInt128");
        }

        [Test]
        public void IsCoPrime0AndNeg1ShouldReturnTrue() {
            Assert.AreEqual(true, PrimeMath.IsCoprime((int)0, (int)-1), "int");
            Assert.AreEqual(true, PrimeMath.IsCoprime((long)0, (long)-1), "long");
        }

        [Test]
        public void IsCoPrime1And1ShouldReturnTrue() {
            // 1/-1 are the only number coprime to itself
            Assert.AreEqual(true, PrimeMath.IsCoprime((uint)1, (uint)1), "uint");
            Assert.AreEqual(true, PrimeMath.IsCoprime((int)1, (int)1), "int");
            Assert.AreEqual(true, PrimeMath.IsCoprime((ulong)1, (ulong)1), "ulong");
            Assert.AreEqual(true, PrimeMath.IsCoprime((long)1, (long)1), "long");
            Assert.AreEqual(true, PrimeMath.IsCoprime((UInt128)1, (UInt128)1), "UInt128");
        }

        [Test]
        public void IsCoPrime1AndNeg1ShouldReturnTrue() {
            // 1/-1 are the only number coprime to itself
            Assert.AreEqual(true, PrimeMath.IsCoprime((int)1, (int)-1), "int");
            Assert.AreEqual(true, PrimeMath.IsCoprime((long)1, (long)-1), "long");
        }

        [Test]
        public void IsCoPrimeNeg1AndNeg1ShouldReturnTrue() {
            // 1/-1 are the only number coprime to itself
            Assert.AreEqual(true, PrimeMath.IsCoprime((int)-1, (int)-1), "int");
            Assert.AreEqual(true, PrimeMath.IsCoprime((long)-1, (long)-1), "long");
        }

        [Test]
        public void IsCoPrimeEqualNon1ValuesShouldReturnFalse() {
            Assert.AreEqual(false, PrimeMath.IsCoprime((uint)11, (uint)11), "uint");
            Assert.AreEqual(false, PrimeMath.IsCoprime((int)11, (int)11), "int");
            Assert.AreEqual(false, PrimeMath.IsCoprime((ulong)11, (ulong)11), "ulong");
            Assert.AreEqual(false, PrimeMath.IsCoprime((long)11, (long)11), "long");
            Assert.AreEqual(false, PrimeMath.IsCoprime((UInt128)11, (UInt128)11), "UInt128");
        }

        [Test]
        public void IsCoPrimeTwoPrimesShouldReturnTrue() {
            Assert.AreEqual(true, PrimeMath.IsCoprime((uint)11, (uint)13), "uint");
            Assert.AreEqual(true, PrimeMath.IsCoprime((int)11, (int)13), "int");
            Assert.AreEqual(true, PrimeMath.IsCoprime((ulong)11, (ulong)13), "ulong");
            Assert.AreEqual(true, PrimeMath.IsCoprime((long)11, (long)13), "long");
            Assert.AreEqual(true, PrimeMath.IsCoprime((UInt128)11, (UInt128)13), "UInt128");
        }

        [Test]
        public void IsCoPrimeTwoEvenValuesShouldReturnFalse() {
            Assert.AreEqual(false, PrimeMath.IsCoprime((uint)10, (uint)12), "uint");
            Assert.AreEqual(false, PrimeMath.IsCoprime((int)10, (int)12), "int");
            Assert.AreEqual(false, PrimeMath.IsCoprime((ulong)10, (ulong)12), "ulong");
            Assert.AreEqual(false, PrimeMath.IsCoprime((long)10, (long)12), "long");
            Assert.AreEqual(false, PrimeMath.IsCoprime((UInt128)10, (UInt128)12), "UInt128");
        }

        [Test]
        public void IsCoPrimeEqualNegValuesShouldReturnTrue() {
            Assert.AreEqual(false, PrimeMath.IsCoprime((int)-11, (int)-11), "int");
            Assert.AreEqual(false, PrimeMath.IsCoprime((long)-11, (long)-11), "long");
        }

        [Test]
        public void IsCoPrimeEqualButOppositeSignValuesShouldReturnTrue() {
            Assert.AreEqual(false, PrimeMath.IsCoprime((int)-11, (int)11), "int");
            Assert.AreEqual(false, PrimeMath.IsCoprime((long)-11, (long)11), "long");
        }

        [Test]
        public void IsCoPrimeSwappedArgOrderShouldReturnSameResult() {
            for (int i = 10; i < 20; i++) {
                for (int j = 20; j < 30; j++) {
                    Assert.AreEqual(PrimeMath.IsCoprime((uint)i, (uint)j), PrimeMath.IsCoprime((uint)j, (uint)i), "uint");
                    Assert.AreEqual(PrimeMath.IsCoprime((int)i, (int)j), PrimeMath.IsCoprime((int)j, (int)i), "int");
                    Assert.AreEqual(PrimeMath.IsCoprime((ulong)i, (ulong)j), PrimeMath.IsCoprime((ulong)j, (ulong)i), "ulong");
                    Assert.AreEqual(PrimeMath.IsCoprime((long)i, (long)j), PrimeMath.IsCoprime((long)j, (long)i), "long");
                    Assert.AreEqual(PrimeMath.IsCoprime((UInt128)(ulong)i, (UInt128)(ulong)j), PrimeMath.IsCoprime((UInt128)(ulong)j, (UInt128)(ulong)i), "UInt128");
                }
            }
        }

        [Test]
        public void NearestCoprimeFloor0And0UnsignedShouldReturn0() {
            Assert.AreEqual(0, PrimeMath.NearestCoprimeFloor((uint)0, (uint)0), "uint");
            Assert.AreEqual(0, PrimeMath.NearestCoprimeFloor((ulong)0, (ulong)0), "ulong");
            Assert.AreEqual(UInt128.Zero, PrimeMath.NearestCoprimeFloor((UInt128)0, (UInt128)0), "UInt128");
        }

        [Test]
        public void NearestCoprimeFloor0And0SignedShouldReturnNeg1() {
            Assert.AreEqual(-1, PrimeMath.NearestCoprimeFloor((int)0, (int)0), "int");
            Assert.AreEqual(-1, PrimeMath.NearestCoprimeFloor((long)0, (long)0), "long");
        }

        [Test]
        public void NearestCoprimeFloorNeg2And0ShouldReturn0() {
            Assert.AreEqual(0, PrimeMath.NearestCoprimeFloor((int)-2, (int)0), "int");
            Assert.AreEqual(0, PrimeMath.NearestCoprimeFloor((long)-2, (long)0), "long");
        }

        [Test]
        public void NearestCoprimeFloor1And1ShouldReturn1() {
            Assert.AreEqual(1, PrimeMath.NearestCoprimeFloor((uint)1, (uint)1), "uint");
            Assert.AreEqual(1, PrimeMath.NearestCoprimeFloor((int)1, (int)1), "int");
            Assert.AreEqual(1, PrimeMath.NearestCoprimeFloor((ulong)1, (ulong)1), "ulong");
            Assert.AreEqual(1, PrimeMath.NearestCoprimeFloor((long)1, (long)1), "long");
            Assert.AreEqual(UInt128.One, PrimeMath.NearestCoprimeFloor((UInt128)1, (UInt128)1), "UInt128");
        }

        [Test]
        public void NearestCoprimeFloor10And15ShouldReturn8() {
            Assert.AreEqual(8, PrimeMath.NearestCoprimeFloor((uint)10, (uint)15), "uint");
            Assert.AreEqual(8, PrimeMath.NearestCoprimeFloor((int)10, (int)15), "int");
            Assert.AreEqual(8, PrimeMath.NearestCoprimeFloor((ulong)10, (ulong)15), "ulong");
            Assert.AreEqual(8, PrimeMath.NearestCoprimeFloor((long)10, (long)15), "long");
            Assert.AreEqual((UInt128)8, PrimeMath.NearestCoprimeFloor((UInt128)10, (UInt128)15), "UInt128");
        }

        [Test]
        public void NearestCoprimeFloor10AndNeg15ShouldReturn8() {
            Assert.AreEqual(8, PrimeMath.NearestCoprimeFloor((int)10, (int)-15), "int");
            Assert.AreEqual(8, PrimeMath.NearestCoprimeFloor((long)10, (long)-15), "long");
        }

        [Test]
        public void NearestCoprimeFloorNeg10And15ShouldReturnNeg11() {
            Assert.AreEqual(-11, PrimeMath.NearestCoprimeFloor((int)-10, (int)15), "int");
            Assert.AreEqual(-11, PrimeMath.NearestCoprimeFloor((long)-10, (long)15), "long");
        }

        [Test]
        public void NearestCoprimeFloorNeg10AndNeg15ShouldReturnNeg11() {
            Assert.AreEqual(-11, PrimeMath.NearestCoprimeFloor((int)-10, (int)-15), "int");
            Assert.AreEqual(-11, PrimeMath.NearestCoprimeFloor((long)-10, (long)-15), "long");
        }

        [Test]
        public void NearestCoprimeCeiling0And0ShouldReturn1() {
            Assert.AreEqual(1, PrimeMath.NearestCoprimeCeiling((uint)0, (uint)0), "uint");
            Assert.AreEqual(1, PrimeMath.NearestCoprimeCeiling((int)0, (int)0), "int");
            Assert.AreEqual(1, PrimeMath.NearestCoprimeCeiling((ulong)0, (ulong)0), "ulong");
            Assert.AreEqual(1, PrimeMath.NearestCoprimeCeiling((long)0, (long)0), "long");
            Assert.AreEqual(UInt128.One, PrimeMath.NearestCoprimeCeiling((UInt128)0, (UInt128)0), "UInt128");
        }

        [Test]
        public void NearestCoprimeCeiling2And0ShouldReturn0() {
            Assert.AreEqual(0, PrimeMath.NearestCoprimeCeiling(2, (uint)0), "uint");
            Assert.AreEqual(0, PrimeMath.NearestCoprimeCeiling(2, (int)0), "int");
            Assert.AreEqual(0, PrimeMath.NearestCoprimeCeiling((ulong)2, (ulong)0), "ulong");
            Assert.AreEqual(0, PrimeMath.NearestCoprimeCeiling((long)2, (long)0), "long");
            Assert.AreEqual(UInt128.Zero, PrimeMath.NearestCoprimeCeiling((UInt128)2, (UInt128)0), "UInt128");
        }

        [Test]
        public void NearestCoprimeCeiling1And1ShouldReturn1() {
            Assert.AreEqual(1, PrimeMath.NearestCoprimeCeiling((uint)1, (uint)1), "uint");
            Assert.AreEqual(1, PrimeMath.NearestCoprimeCeiling((int)1, (int)1), "int");
            Assert.AreEqual(1, PrimeMath.NearestCoprimeCeiling((ulong)1, (ulong)1), "ulong");
            Assert.AreEqual(1, PrimeMath.NearestCoprimeCeiling((long)1, (long)1), "long");
            Assert.AreEqual(UInt128.One, PrimeMath.NearestCoprimeCeiling((UInt128)1, (UInt128)1), "UInt128");
        }

        [Test]
        public void NearestCoprimeCeiling10And15ShouldReturn11() {
            Assert.AreEqual(11, PrimeMath.NearestCoprimeCeiling((uint)10, (uint)15), "uint");
            Assert.AreEqual(11, PrimeMath.NearestCoprimeCeiling((int)10, (int)15), "int");
            Assert.AreEqual(11, PrimeMath.NearestCoprimeCeiling((ulong)10, (ulong)15), "ulong");
            Assert.AreEqual(11, PrimeMath.NearestCoprimeCeiling((long)10, (long)15), "long");
            Assert.AreEqual((UInt128)11, PrimeMath.NearestCoprimeCeiling((UInt128)10, (UInt128)15), "UInt128");
        }

        [Test]
        public void NearestCoprimeCeiling10AndNeg15ShouldReturn11() {
            Assert.AreEqual(11, PrimeMath.NearestCoprimeCeiling((int)10, (int)-15), "int");
            Assert.AreEqual(11, PrimeMath.NearestCoprimeCeiling((long)10, (long)-15), "long");
        }

        [Test]
        public void NearestCoprimeCeilingNeg10And15ShouldReturnNeg8() {
            Assert.AreEqual(-8, PrimeMath.NearestCoprimeCeiling((int)-10, (int)15), "int");
            Assert.AreEqual(-8, PrimeMath.NearestCoprimeCeiling((long)-10, (long)15), "long");
        }

        [Test]
        public void NearestCoprimeCeilingNeg10AndNeg15ShouldReturnNeg8() {
            Assert.AreEqual(-8, PrimeMath.NearestCoprimeCeiling((int)-10, (int)-15), "int");
            Assert.AreEqual(-8, PrimeMath.NearestCoprimeCeiling((long)-10, (long)-15), "long");
        }
    }
}
