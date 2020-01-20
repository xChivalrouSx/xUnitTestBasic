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
            sut.LastName = "�akar";

            Assert.Equal("Mert �akar", sut.FullName);
        }

        [Fact]
        public void HaveFullNameStartWithFirstName()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.FirstName = "Mert";
            sut.LastName = "�akar";

            Assert.StartsWith("Mert", sut.FullName);
        }

        [Fact]
        public void HaveFullNameEndWithLastName()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.FirstName = "Mert";
            sut.LastName = "�akar";

            Assert.EndsWith("�akar", sut.FullName);
        }

        [Fact]
        public void CalculateFullName_IgnoreCaseAssertExample()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.FirstName = "MERT";
            sut.LastName = "�AKAR";

            Assert.Equal("Mert �akar", sut.FullName, ignoreCase: true);
        }

        [Fact]
        public void CalculateFullName_SubstringAssertExample()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.FirstName = "Mert";
            sut.LastName = "�akar";

            Assert.Contains("t �a", sut.FullName);
        }

        [Fact]
        public void CalculateFullNameWithTitleCase()
        {
            PlayerCharacter sut = new PlayerCharacter();

            sut.FirstName = "Mert";
            sut.LastName = "�akar";

            Assert.Matches("[A-Z������]{1}[a-z�����]+ [A-Z������]{1}[a-z�����]+", sut.FullName);
        }
    }
}
