using System;

namespace Monopoly.DomainModel
{
    public class Die : IDie
    {
        private readonly Random _rand = new Random();
        private int _faceValue = -1;

        public void Roll()
        {
            _faceValue = _rand.Next(1, 6);
        }

        public int GetFaceValue()
        {
            return _faceValue;
        }
    }
}
