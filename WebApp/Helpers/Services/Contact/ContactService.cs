using Microsoft.EntityFrameworkCore;
using WebApp.Contexts;
using WebApp.Models.Entities;
using WebApp.ViewModels.ContactView;

namespace WebApp.Helpers.Services.Contact
{
    public class ContactService
    {
        #region private fields & constructors
        private readonly DataContext _context;

        public ContactService(DataContext context)
        {
            _context = context;
        }
        #endregion
        public async Task<bool> RegisterAsync(ContactFormViewModel model)
        {
            try
            {
                ContactEntity contactEntity = model;

                _context.Contacts.Add(contactEntity);
                await _context.SaveChangesAsync();

                return true;
            }
            catch { return false; }
        }
    }
}
