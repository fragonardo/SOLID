using System;

namespace PubSub
{
    public class Publisher
    {
        private event EventHandler<EventArgs> onChange = delegate {};
        
        public event EventHandler<EventArgs> OnChange
        {
            add
            {
                lock(onChange)
                {
                    onChange += value;
                }
            }

            remove
            {
                lock(onChange)
                {
                    onChange -= value;
                }
            }
        }
        
        public void OnRaise()
        {
            this.onChange(this, null);
        }
    }
}