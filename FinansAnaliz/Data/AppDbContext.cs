
using FinansAnaliz.Models;
using FinansAnaliz.Models.AnalizModel;
using FinansAnaliz.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinansAnaliz.Data
{
    public class AppDbContext:IdentityDbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Help> Helps { get; set; }
        public DbSet<EntryDate> EntryDates { get; set; }
        public DbSet<RasyoModel> RasyoModels { get; set; }
        public DbSet<TekliVeriModel> TekliVeriModels { get; set; }
        public DbSet<YapisalAnalizModel> YapisalAnalizModels { get; set; }
        public DbSet<Teminat> Teminats { get; set; }
        public DbSet<MizanGonderim> MizanGonderims { get; set; }
        public DbSet<Banka> Bankalar { get; set; }
        public DbSet<Rule> Rules { get; set; }
        public DbSet<RuleName> RuleNames { get; set; }
        public DbSet<RuleProblemCompany>  ruleProblemCompanies { get; set; }
        public DbSet<Settings> Settings { get; set; }

    }
}
