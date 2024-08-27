using JWTRoleAuthentication.CommonLayer.Models;
using System.Reflection.Metadata;

namespace JWTRoleAuthentication.Controllers
{
    public class ValidationHelper
    {
        public ValidationHelper()
        {

        }

        // validate model:
        public void ValidateModel(object model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("Model can not be null.");
            }
            var properties = model.GetType().GetProperties();
            properties.ToList().ForEach((prop) =>
            {
                var value = prop.GetValue(model);
                ValidateParameters(value, prop.Name, prop.PropertyType);
            });
        }

        public void ValidateParameters(object value, string propName, Type propType)
        {
            // null parameter value
            if (value == null)
            {
                throw new ArgumentNullException($"{propName} Cannot be null.");
            }
            // empty string
            if (propType == typeof(string) && string.IsNullOrWhiteSpace(value as string))
            {
                throw new ArgumentNullException($"{propName} can not be empty or whitespace. ");
            }
            // default datetime
            if (propType == typeof(DateTime) && (DateTime)value == default)
            {
                throw new ArgumentNullException($"{propName} date value cannot be default date.");
            }

            // empty guid
            if (propType == typeof(Guid) && (Guid)value == Guid.Empty)
            {
                throw new ArgumentNullException($"{propName} cannot be a empty Guid.");
            }

            // empty int
            //if(propType == typeof(int) && (!int.TryParse(value.ToString(), out )))
            //{
            //   throw new ArgumentNullException($"{propName} must be a integer value.");
            //}

            if (propType == typeof(int))
            {
                if (!int.TryParse(value.ToString(), out _))
                {
                    throw new ArgumentException($"{propName} must be a valid integer.");
                }
            }

            if (propType == typeof(float))
            {
                if (!float.TryParse(value.ToString(), out _))
                {
                    throw new ArgumentException($"{propName} must be a valid float value.");
                }
            }

            if (propType == typeof(double))
            {
                if (!double.TryParse(value.ToString(), out _))
                {
                    throw new ArgumentException($"{propName} must be a valid double value.");
                }
            }

            if (propType == typeof(bool))
            {
                if (!bool.TryParse(value.ToString(), out _))
                {
                    throw new ArgumentException($"{propName} must be a valid bool value.");
                }
            }
            if (propType == typeof(decimal))
            {
                if (!decimal.TryParse(value.ToString(), out _))
                {
                    throw new ArgumentException($"{propName} must be a valid decimal value.");
                }
            }
            if (propType == typeof(TimeZone))
            {
                if (!TimeSpan.TryParse(value.ToString(), out _))
                {
                    throw new ArgumentException($"{propName} must be a valid Time value.");
                }
            }
        }

        public void ValidateModelParameters(SampleDataTypes model)
        {

            if(model.Profile != null)
            {
                if(model.Profile is string)
                {
                    model.Profile = System.Text.Encoding.UTF8.GetBytes(model?.Profile.ToString());
                }
                else if(model.Profile is byte[]) 
                {
                    model.Profile = (byte[])model.Profile;
                }
            }
            //int age;
            if (model?.Age != null)
            {
                if (model.Age is string)
                {
                    model.Age = int.Parse(model.Age.Value.ToString());
                }
                else if (model.Age is int)
                {
                    model.Age = (int)model.Age;
                }

            }

            if (model?.Doublevalue != null)
            {
                if (model.Doublevalue is string)
                {
                    model.Doublevalue = double.Parse(model.Doublevalue.Value.ToString());
                }
                else if(model.Doublevalue is double)
                {
                    model.Doublevalue = (double)model.Doublevalue;
                }
            }
            if (model?.Salary != null)
            {
                if (model.Salary is string)
                {
                    model.Salary = float.Parse(model.Salary.Value.ToString());
                }
                else if(model.Salary is float)
                {   
                    model.Salary = (float)model.Salary;
                }
            }
            if (model?.Price != null)
            {
                if (model.Price is string)
                {
                    model.Price = decimal.Parse(model.Price.Value.ToString());
                }
                else if(model.Price is decimal)
                {
                    model.Price = (decimal)model.Price;
                }
            }

            if (model?.TimeSpanValue != null)
            {
                if (model.TimeSpanValue is string)
                {
                    model.TimeSpanValue = TimeSpan.Parse(model.TimeSpanValue.Value.ToString());
                }
                else if(model.TimeSpanValue is TimeSpan)
                {
                    model.TimeSpanValue = (TimeSpan)model.TimeSpanValue;
                }
            }
            if (model?.DateOfBirth != null)
            {
                if (model.DateOfBirth is string)
                {
                    model.DateOfBirth = DateTime.Parse(model.DateOfBirth.Value.ToString());
                }
                else if (model.DateOfBirth is DateTime)
                {
                    model.DateOfBirth = (DateTime)model.DateOfBirth; 
                }
            }
            if (model?.JoinDate != null)
            {
                if (model.DateOfBirth is string)
                {
                    model.JoinDate = DateTime.Parse(model.JoinDate.Value.ToString());
                }
                else if( model.JoinDate is DateTime)
                {
                    model.JoinDate = (DateTime)model.JoinDate;
                }
            }
            if(model?.IsActive != null)
            {
                if(model.IsActive is string)
                {
                    model.IsActive = bool.Parse(model.IsActive.Value.ToString());
                }else if(model.IsActive is bool)
                {
                    model.IsActive = (bool)model.IsActive;
                }
            }
        }

    }
}   
