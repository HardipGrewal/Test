using InterviewTask.Services;
using System;
using System.Collections;
using System.Collections.Generic;

namespace InterviewTask.Models
{
    public class HelperServiceModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TelephoneNumber { get; set; }

        public List<int> MondayOpeningHours { get; set; }
        public List<int> TuesdayOpeningHours { get; set; }
        public List<int> WednesdayOpeningHours { get; set; }
        public List<int> ThursdayOpeningHours { get; set; }
        public List<int> FridayOpeningHours { get; set; }
        public List<int> SaturdayOpeningHours { get; set; }
        public List<int> SundayOpeningHours { get; set; }
    }
    public class HelperServiceModelList : IEnumerable<HelperServiceModel>
    {
        private HelperServiceRepository[] _helper;
        public HelperServiceModelList(HelperServiceRepository[] pArray)
        {
            _helper = new HelperServiceRepository[pArray.Length];

            for (int i = 0; i < pArray.Length; i++)
            {
                _helper[i] = pArray[i];
            }
        }

        // Implementation for the GetEnumerator method.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public HelperEnum GetEnumerator()
        {
            return new HelperEnum(_helper);
        }

        IEnumerator<HelperServiceModel> IEnumerable<HelperServiceModel>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    // When you implement IEnumerable, you must also implement IEnumerator.
    public class HelperEnum : IEnumerator
    {
        public HelperServiceRepository[] _helper;

        // Enumerators are positioned before the first element
        // until the first MoveNext() call.
        int position = -1;

        public HelperEnum(HelperServiceRepository[] list)
        {
            _helper = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _helper.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public HelperServiceRepository Current
        {
            get
            {
                try
                {
                    return _helper[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}

