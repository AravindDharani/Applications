using System;
namespace OnlineFoodDeliveryApplication
{
    public partial class List<Type>
    {
        private int _count;
        private int _capacity;
        public int Count { get{return _count;}  }

        public int Capacity { get{return _capacity;} }
        private Type[] _array;

        public Type this[int i] { get{return _array[i];} set{_array[i]=value;} }

        public List()
        {
            _count=0;
            _capacity=4;
            _array=new Type[_capacity];
        }

        public void Add(Type data)
        {
            if(_count==_capacity)
            {
                GrowSize();
            }
            _array[_count]=data;
            _count++;
        }

        public void GrowSize()
        {
                _capacity*=2;
                Type[] temp = new Type[_capacity];
                for(int i=0;i<_count;i++)
                {
                    temp[i]=_array[i];
                }
                _array=temp;
        }

        public void AddRange(List<Type> data)
        {
                _capacity=_count+data.Count+4;
                Type[] temp = new Type[_capacity];
                for(int i=0;i<_count;i++)
                {
                    temp[i]=_array[i];
                }
                int j=0;
                for(int i=_count;i<_count+data.Count;i++)
                {
                    temp[i]=data[j];
                    j++;
                }
                _array=temp;
                _count+=data.Count;
        }

    }
}