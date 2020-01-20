using System;
using Xunit;

namespace GameEngine.Tests
{
    public class PlayerCharacterShould
    {
        [Fact]
        public void BeInexperiencedWhenNew()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.True(sut.IsNoob);
        }

        [Fact]
        public void CalculateFullName() 
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.FirstName = "Mert";
            sut.LastName = "Çakar";

            Assert.Equal("Mert Çakar", sut.FullName);
        }

        [Fact]
        public void HaveFullNameStartWithFirstName()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.FirstName = "Mert";
            sut.LastName = "Çakar";

            Assert.StartsWith("Mert", sut.FullName);
        }

        [Fact]
        public void HaveFullNameEndWithLastName()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.FirstName = "Mert";
            sut.LastName = "Çakar";

            Assert.EndsWith("Çakar", sut.FullName);
        }

        [Fact]
        public void CalculateFullName_IgnoreCaseAssertExample()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.FirstName = "MERT";
            sut.LastName = "ÇAKAR";

            Assert.Equal("Mert Çakar", sut.FullName, ignoreCase: true);
        }

        [Fact]
        public void CalculateFullName_SubstringAssertExample()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.FirstName = "Mert";
            sut.LastName = "Çakar";

            Assert.Contains("t Ça", sut.FullName);
        }

        [Fact]
        public void CalculateFullNameWithTitleCase()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.FirstName = "Mert";
            sut.LastName = "Çakar";

            Assert.Matches("[A-ZİĞÜŞÖÇ]{1}[a-zğüşöç]+ [A-ZİĞÜŞÖÇ]{1}[a-zğüşöç]+", sut.FullName);
        }

        [Fact]
        public void StartWithDefaultHealth()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.Equal(100, sut.Health);
        }

        [Fact]
        public void StartWithDefaultHealth_NotEqualExample()
        {
            PlayerCharacter sut = new PlayerCharacter();

            Assert.NotEqual(0, sut.Health);
        }

        [Fact]
        public void IncreaseHealthAfterSleeping()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.Sleep();

            // Assert.True(sut.Health >= 101 && sut.Health <= 200);
            Assert.InRange(sut.Health, 101, 200);
        }
    }
}
