namespace App.Logic
{
    using System.Threading;

    public class AtomicBoolean
    {
        private volatile int _value;

        public AtomicBoolean()
        {
        }

        public AtomicBoolean(bool initialValue)
        {
            this._value = initialValue ? 1 : 0;
        }

        public bool CompareAndSet(bool expect, bool update)
        {
            return Interlocked.CompareExchange(ref this._value, update ? 1 : 0, expect ? 1 : 0) == 1 == expect;
        }

        public bool Get()
        {
            return this._value == 1;
        }

        public bool GetAndSet(bool newValue)
        {
            return Interlocked.Exchange(ref this._value, newValue ? 1 : 0) == 1;
        }

        public void Set(bool newValue)
        {
            this._value = newValue ? 1 : 0;
        }

        public override string ToString()
        {
            return (this._value == 1).ToString();
        }
    }
}