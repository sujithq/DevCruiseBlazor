using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace DevCruise.Blazor.Shared
{
    public class Product
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string LargeImage { get; set; }
    }

    public class BasketItem
    {
        public string Title { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }

        public decimal Price { get; set; }

        public BasketItem()
        {

        }
    }

    public enum SizeEnum
    {
        XS,
        S,
        M,
        L,
        XL,
        XXL
    }

    public class AddressState
    {
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string ZipPostalCode { get; set; }
        public string Country { get; set; } = "BE";
    }

    public class AddressModel : AddressState, IDataErrorInfo, INotifyDataErrorInfo
    {


        public string this[string property] => GetErrors(property).FirstOrDefault<string>();
        public string Error => null;
        public bool HasErrors => GetErrors(null).Any();
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public IEnumerable GetErrors(string property)
        {
            if (property == null || property == nameof(AddressLine))
                if (string.IsNullOrEmpty(AddressLine))
                    yield return $"{nameof(AddressLine)} is mandatory";
            if (property == null || property == nameof(City))
                if (string.IsNullOrEmpty(City))
                    yield return $"{nameof(City)} is mandatory";
            if (property == null || property == nameof(Country))
                if (string.IsNullOrEmpty(Country))
                    yield return $"{nameof(Country)} is mandatory";
            if (property == null || property == nameof(StateProvince))
                if (string.IsNullOrEmpty(StateProvince))
                    yield return $"{nameof(StateProvince)} is mandatory";
            if (property == null || property == nameof(ZipPostalCode))
                if (string.IsNullOrEmpty(ZipPostalCode))
                    yield return $"{nameof(ZipPostalCode)} is mandatory";
        }
    }

    public class CheckoutBase
    {
        public string Email { get; set; }
        public string Phone { get; set; }

        public string CcName { get; set; }
        public string CcNumber { get; set; }

        public bool UseOtherBilling { get; set; }

        public string Month { get; set; } = "jan";
        public int Year { get; set; } = 2018;
        public int CVC { get; set; }
    }

    public class CheckoutState : CheckoutBase
    {
        public CheckoutState()
        {
            Billing = new AddressState();
            Shipping = new AddressState();
        }

        public AddressState Shipping { get; set; }
        public AddressState Billing { get; set; }

    }

    public class CheckoutModel : CheckoutBase, IDataErrorInfo, INotifyDataErrorInfo
    {
        public CheckoutModel()
        {
            Billing = new AddressModel();
            Shipping = new AddressModel();

        }
        public AddressModel Shipping { get; set; }
        public AddressModel Billing { get; set; }

        public CheckoutModel(CheckoutState value)
        {
            if (value == null)
                return;


            Email = value.Email;
            Phone = value.Phone;


            Shipping = new AddressModel
            {
                AddressLine = value.Shipping.AddressLine,
                City = value.Shipping.City,
                Country = value.Shipping.Country,
                ZipPostalCode = value.Shipping.ZipPostalCode,
                StateProvince = value.Shipping.StateProvince
            };

            UseOtherBilling = value.UseOtherBilling;

            Billing = new AddressModel
            {
                AddressLine = value.Billing.AddressLine,
                City = value.Billing.City,
                Country = value.Billing.Country,
                ZipPostalCode = value.Billing.ZipPostalCode,
                StateProvince = value.Billing.StateProvince
            };

            CcName = value.CcName;
            CcNumber = value.CcNumber;

            Month = value.Month;
            Year = value.Year;
            CVC = value.CVC;


        }
        public string this[string property] => GetErrors(property).FirstOrDefault<string>();

        public string Error => null;

        public bool HasErrors => GetErrors(null).Any();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string property)
        {
            if (property == null || property == nameof(Email))
                if (string.IsNullOrEmpty(Email))
                {yield return $"{nameof(Email)} is mandatory";}

            if (property == null || property == nameof(Phone))
                if (string.IsNullOrEmpty(Phone))
                {yield return $"{nameof(Phone)} is mandatory";}

            if (property == null || property == nameof(CcName))
                if (string.IsNullOrEmpty(CcName))
                {
                    yield return $"{nameof(CcName)} is mandatory";
                }

            if (property == null || property == nameof(CcNumber))
                if (string.IsNullOrEmpty(CcNumber))
                    yield return $"{nameof(CcNumber)} is mandatory";

            if (property == null || property == nameof(Month))
                if (string.IsNullOrEmpty(Month))
                    yield return $"{nameof(Month)} is mandatory";

            if (property == null || property == nameof(Year))
                if (Year <= 0)
                    yield return $"{nameof(Year)} should be > 0";

            if (property == null || property == nameof(CVC))
                if (CVC <= 0)
                    yield return $"{nameof(CVC)} should be > 0";
        }


        
    }
}
