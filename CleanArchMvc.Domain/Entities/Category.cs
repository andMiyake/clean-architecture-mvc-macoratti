﻿using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : EntityBase
    {
        public string Name { get; private set; }

        public Category(string name)
        {
            ValidateDomain(name);
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value");
            Id = id;
            ValidateDomain(name);
        }

        public ICollection<Product> Products { get; set; }

        public void Update(string name)
        {
            ValidateDomain(name);
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name, too short, minimum 3 characters");

            Name = name;
        }

        //public int Id { get; private set; }

        //private string _name;
        //public string Name
        //{
        //    get { return _name; }
        //    private set
        //    {
        //        ValidateCategoryName(value);
        //        _name = value;
        //    }
        //}

        //public Category(string name)
        //{
        //    Name = name;
        //}

        //public Category(int id, string name)
        //{
        //    DomainExceptionValidation.When(id < 0, "Invalid Id value");
        //    Id = id;
        //    Name = name;
        //}

        //public ICollection<Product> Products { get; set; }

        //public void Update(string name)
        //{
        //    Name = name;
        //}

        //private void ValidateCategoryName(string name)
        //{
        //    DomainExceptionValidation.When(string.IsNullOrEmpty(name),
        //        "Invalid name. Name is required");

        //    DomainExceptionValidation.When(name.Length < 3,
        //        "Invalid name, too short, minimum of 3 characters");
        //}
    }
}
