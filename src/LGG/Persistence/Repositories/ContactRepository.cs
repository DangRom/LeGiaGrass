﻿using LGG.Core.Models;
using LGG.Core.Repositories;
using System.Linq;

namespace LGG.Persistence.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _context;

        public ContactRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Contact Add(Contact contactEntity)
        {
            _context
                .Contacts
                .Add(contactEntity);
            _context.SaveChanges();

            return contactEntity;
        }

        /// <summary>
        /// Get by email address
        /// </summary>
        /// <returns>Contact Entity</returns>
        public Contact GetByEmail(string email)
        {
            return _context
                    .Contacts
                    .FirstOrDefault(x => x.Email == email);
        }
    }
}