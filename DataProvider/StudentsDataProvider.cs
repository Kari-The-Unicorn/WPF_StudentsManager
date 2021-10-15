﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using WPF_StudentsManager.Model;

namespace WPF_StudentsManager.DataProvider
{
    public class StudentsDataProvider
    { // Here it access Json file but it can also access database or rest service
        private static readonly string _customersFileName = "customers.json";
        public Task<IEnumerable<Student>> LoadStudentsAsync()
        {
            IEnumerable<Student> customerList;
            if (!File.Exists(_customersFileName))
            {
                customerList = new List<Student>
                {
                    new Student{FirstName="Julia",LastName="Began",IsActive=true},
                    new Student{FirstName="Megan",LastName="Negan",IsActive=true},
                    new Student{FirstName="Patrick",LastName="Swize"},
                    new Student{FirstName="Jen",LastName="Pollos",IsActive=true},
                    new Student{FirstName="Peter",LastName="Gabril"},
                    new Student{FirstName="Minnie",LastName="Morris"},
                    new Student{FirstName="Albert",LastName="Stein", IsActive=true},
                };
            }
            else
            {
                // Json from local file is read and list of students is deserialized from file
                var json = File.ReadAllText(_customersFileName);
                customerList = JsonConvert.DeserializeObject<List<Student>>(json);
            }
            // return customerList
            return Task.FromResult(customerList);
        }

        public Task SaveStudentsAsync(IEnumerable<Student> customers)
        {
            // customers is serialized as json string and is written to the local file
            var json = JsonConvert.SerializeObject(customers, Formatting.Indented);
            File.WriteAllText(_customersFileName, json);
            return Task.CompletedTask;
        }
    }
}