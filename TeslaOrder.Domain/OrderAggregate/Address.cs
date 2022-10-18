using System;
using System.Collections.Generic;
using System.Text;
using TeslaOrder.Domain.Abstractions;

namespace TeslaOrder.Domain.OrderAggregate
{
    /// <summary>
    /// 收获地址
    /// </summary>
    public class Address : ValueObject
    {
        public string Province { get; private set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string ZipCode { get; private set; }

        public Address() { }
        public Address(string province, string street, string city, string zipcode)
        {
            Province = province;
            Street = street;
            City = city;
            ZipCode = zipcode;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            // Using a yield return statement to return each element one at a time
            yield return Province;
            yield return Street;
            yield return City;
            yield return ZipCode;
        }
    }
}
