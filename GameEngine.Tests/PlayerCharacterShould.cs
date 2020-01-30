using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    public class PlayerCharacterShould : IDisposable
    {
        private readonly PlayerCharacter _sut;
        private readonly ITestOutputHelper _output;

        public PlayerCharacterShould(ITestOutputHelper output)
        {
            _output = output;

            _output.WriteLine("Creating new PlayerCharacter...");
            _sut = new PlayerCharacter();
        }

        public void Dispose()
        {
            _output.WriteLine("Disposing PlayerCharacter...");

            // _sut.Dispose();
        }

        [Fact]
        public void BeInexperiencedWhenNew()
        {
            Assert.True(_sut.IsNoob);
        }

        [Fact]
        public void CalculateFullName() 
        {
            _sut.FirstName = "Mert";
            _sut.LastName = "�akar";

            Assert.Equal("Mert �akar", _sut.FullName);
        }

        [Fact]
        public void HaveFullNameStartWithFirstName()
        {
            _sut.FirstName = "Mert";
            _sut.LastName = "�akar";

            Assert.StartsWith("Mert", _sut.FullName);
        }

        [Fact]
        public void HaveFullNameEndWithLastName()
        {
            _sut.FirstName = "Mert";
            _sut.LastName = "�akar";

            Assert.EndsWith("�akar", _sut.FullName);
        }

        [Fact]
        public void CalculateFullName_IgnoreCaseAssertExample()
        {
            _sut.FirstName = "MERT";
            _sut.LastName = "�AKAR";

            Assert.Equal("Mert �akar", _sut.FullName, ignoreCase: true);
        }

        [Fact]
        public void CalculateFullName_SubstringAssertExample()
        {
            _sut.FirstName = "Mert";
            _sut.LastName = "�akar";

            Assert.Contains("t �a", _sut.FullName);
        }

        [Fact]
        public void CalculateFullNameWithTitleCase()
        {
            _sut.FirstName = "Mert";
            _sut.LastName = "�akar";

            Assert.Matches("[A-Z������]{1}[a-z�����]+ [A-Z������]{1}[a-z�����]+", _sut.FullName);
        }

        [Fact]
        public void StartWithDefaultHealth()
        {
            Assert.Equal(100, _sut.Health);
        }

        [Fact]
        public void StartWithDefaultHealth_NotEqualExample()
        {
            Assert.NotEqual(0, _sut.Health);
        }

        [Fact]
        public void IncreaseHealthAfterSleeping()
        {
            _sut.Sleep();

            // Assert.True(sut.Health >= 101 && sut.Health <= 200);
            Assert.InRange(_sut.Health, 101, 200);
        }

        [Fact]
        public void NotHaveNickNameByDefault()
        {
            Assert.Null(_sut.Nickname);
        }

        [Fact]
        public void HaveALongBow()
        {
            Assert.Contains("Long Bow", _sut.Weapons);
        }

        [Fact]
        public void NotHaveAStaffOfWonder()
        {
            Assert.DoesNotContain("Staff Of Wonder", _sut.Weapons);
        }

        [Fact]
        public void HaveAtLeastOneKindOfSword()
        {
            Assert.Contains(_sut.Weapons, weapon => weapon.Contains("Sword"));
        }

        [Fact]
        public void HaveAllExpectedStartingWeapons()
        {
            List<string> expectedWeapons = new List<string> 
            {
                "Long Bow",
                "Short Bow",
                "Short Sword"
            };

            Assert.Equal(expectedWeapons, _sut.Weapons);
        }

        [Fact]
        public void HaveNoEmptyDefaultWeapons()
        {
            Assert.All(_sut.Weapons, weapon => Assert.False(string.IsNullOrWhiteSpace(weapon)));
        }

        [Fact]
        public void RaisesSleptEvent()
        {
            Assert.Raises<EventArgs>(
                handler => _sut.PlayerSlept += handler,
                handler => _sut.PlayerSlept -= handler,
                () => _sut.Sleep());
        }

        [Fact]
        public void RaisesPropertyChangeEvent()
        {
            Assert.PropertyChanged(_sut, "Health", () => _sut.TakeDamage(10));
        }

        [Theory]
        [InlineData(0, 100)]
        [InlineData(10, 90)]
        [InlineData(50, 50)]
        [InlineData(101, 1)]
        public void TakeDemage(int damage, int expectedHealth) 
        {
            _sut.TakeDamage(damage);

            Assert.Equal(expectedHealth, _sut.Health);
        }

        [Theory]
        [MemberData(nameof(InternalHealthDemageTestData.TestData), MemberType = typeof(InternalHealthDemageTestData))]
        public void TakeDemage_SharingTestDataExample(int damage, int expectedHealth)
        {
            _sut.TakeDamage(damage);

            Assert.Equal(expectedHealth, _sut.Health);
        }
    }
}
