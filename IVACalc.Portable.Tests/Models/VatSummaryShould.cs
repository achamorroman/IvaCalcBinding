﻿using System.Linq;
using IVACalc.Models;
using NUnit.Framework;

namespace IVACalc.Portable.Tests.Models
{
    [TestFixture]
    public class VatSummaryShould
    {
        [Test]
        public void Contain_all_legal_vats()
        {
            // Given
            const double amount = 100;
            const int units = 1;

            // When
            var vatSummary = new VatSummary(amount, units);

            // Then
            Assert.NotZero(vatSummary.VatInfos.Count());
        }
    }
}