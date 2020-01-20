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

            Assert.Matches("[A-ZÝÐÜÞÖÇ]{1}[a-zðüþöç]+ [A-ZÝÐÜÞÖÇ]{1}[a-zðüþöç]+", sut.FullName);
        }
    }
}
