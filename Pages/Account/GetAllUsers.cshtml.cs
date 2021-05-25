using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZamkDb.Models;

namespace ZamkDb.Pages.Account
{
    public class GetAllUsersModel : PageModel
    {
        private readonly ZamDbContext context;
        private readonly SignInManager<IdentityUser> signIn;

        [BindProperty] public Course Course { get; set; }

        //public IQueryable<IdentityUser> Users { get; set; }
        public IQueryable<Participant> Users { get; set; }

        public GetAllUsersModel(ZamDbContext context, SignInManager<IdentityUser> signIn)
        {
            this.context = context;
            this.signIn = signIn;
        }

        public void OnGet()
        {
            //Users= this.signIn.UserManager.Users;
            Users = context.Participants;
        }
    }
}
